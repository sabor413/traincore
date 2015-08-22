using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Generic.SitecoreUtilities.Parameters
{
    /// <summary>
    /// Generic utilities for fetching sublayout or rendering parameter values.
    /// </summary>
    public class ParameterUtils
    {
        /// <summary>
        /// Returns the value of a reference field as an item.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="parameterField"></param>
        /// <returns></returns>
        public static Item ReferencedItemGet(NameValueCollection parameters, string parameterField)
        {
            Item item = null;

            if (parameters != null)
            {
                string selected = parameters[parameterField];

                if (!String.IsNullOrEmpty(selected))
                {
                    Guid classItemGuid;
                    if (Guid.TryParse(selected, out classItemGuid))
                    {
                        item = Sitecore.Context.Database.GetItem(new ID(classItemGuid));
                    }
                }
            }

            return item;
        }

        /// <summary>
        /// Casts and returns parameter field value.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="parameterField"></param>
        /// <param name="itemFieldName"></param>
        /// <returns></returns>
        public static T FieldValueGet<T>(NameValueCollection parameters, string parameterField)
        {
            string c = String.Empty;

            if (parameters != null)
            {
                c = parameters[parameterField];
            }

            if (String.IsNullOrEmpty(c))
                return default(T);

            return CastAsType<T>(c);
        }

        /// <summary>
        /// Casts and returns a field value from a referenced item.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="parameterField"></param>
        /// <param name="itemFieldName"></param>
        /// <returns></returns>
        public static T ReferencedItemFieldValueGet<T>(NameValueCollection parameters, string parameterField, string itemFieldName)
        {
            string c = String.Empty;

            if (parameters != null)
            {
                Item item = ReferencedItemGet(parameters, parameterField);

                if (item != null)
                {
                    Field fieldValue = item.Fields[itemFieldName];

                    if (fieldValue != null)
                    {
                        c = fieldValue.Value;
                    }
                }
            }

            if (String.IsNullOrEmpty(c))
                return default(T);
            
            return CastAsType<T>(c);
        }

        /// <summary>
        /// Casts string value as specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private static T CastAsType<T>(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                try
                {
                    // NOTE: Couldn't convert string directly to bool, quick fix for now
                    if (default(T) is bool)
                    {
                        int i = 0;

                        int.TryParse(value, out i);

                        return (T)Convert.ChangeType(i, typeof(T));
                    }

                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch
                {
                    Sitecore.Diagnostics.Log.Error("Could not cast value to specified type", typeof(ParameterUtils));
                    return default(T);
                }                
            }

            return default(T);
        }
    }
}
