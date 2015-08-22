using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;

namespace Generic.SitecoreUtilities.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public class FieldUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetFieldValue(string fieldName)
        {
            return GetFieldValue(Sitecore.Context.Item, fieldName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetFieldValue(string itemID, string fieldName)
        {
            string value = String.Empty;

            Guid id = Guid.Empty;
            if (Guid.TryParse(itemID, out id))
            {
                Item item = Sitecore.Context.Database.GetItem(new ID(id));

                if (item != null)
                {
                    if (!String.IsNullOrEmpty(fieldName))
                    {
                        value = GetFieldValue(item, fieldName);
                    }
                }
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static string GetFieldValue(Item item, string fieldName)
        {
            string value = String.Empty;

            if (item != null)
            {
                Field field = item.Fields[fieldName];

                if (field != null)
                {
                    value = field.Value;
                }
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static Item GetReferenceFieldItem(Item item, string fieldName)
        {
            Item referenceItem = null;

            if (item != null)
            {
                ReferenceField field = item.Fields[fieldName];

                if (field != null)
                {
                    referenceItem = field.TargetItem;
                }
            }

            return referenceItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static Item GetReferenceFieldItem(string fieldName)
        {
            return GetReferenceFieldItem(Sitecore.Context.Item, fieldName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static List<Item> GetListFieldItems(string fieldName)
        {
            return GetListFieldItems(Sitecore.Context.Item, fieldName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static List<Item> GetListFieldItems(Item item, string fieldName)
        {
            List<Item> items = new List<Item>();

            if (item != null)
            {
                var field = item.Fields[fieldName];

                if (field != null)
                {
                    MultilistField listField = (MultilistField)field;

                    var listItems = listField.GetItems();

                    if (listItems.Any())
                    {
                        items.AddRange(listItems);
                    }
                }
            }

            return items;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetUrl(string fieldName)
        {
            return GetUrl(Sitecore.Context.Item, fieldName, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetUrl(Item item, string fieldName)
        {
            return GetUrl(item, fieldName, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string GetUrl(Item item, string fieldName, MediaUrlOptions options)
        {
            return GetUrl(item, fieldName, null, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string GetUrl(Item item, string fieldName, UrlOptions options)
        {
            return GetUrl(item, fieldName, options, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetUrl(Item item, string fieldName, UrlOptions urlOptions, MediaUrlOptions mediaUrlOptions)
        {
            string url = String.Empty;

            LinkField linkField = item.Fields[fieldName];

            if (linkField != null)
            {               
                if (linkField.IsMediaLink)
                {
                    MediaItem media = new MediaItem(linkField.TargetItem);
                    url = Sitecore.StringUtil.EnsurePrefix('/', null != mediaUrlOptions ? MediaManager.GetMediaUrl(media, mediaUrlOptions) : MediaManager.GetMediaUrl(media));
                }
                else if (linkField.IsInternal)
                {
                    Item targetItem = linkField.TargetItem;

                    if (targetItem != null)
                    {
                        url = null != urlOptions ? Sitecore.Links.LinkManager.GetItemUrl(linkField.TargetItem, urlOptions) : Sitecore.Links.LinkManager.GetItemUrl(linkField.TargetItem);
                    }
                    else
                    {
                        url = linkField.Url;
                    }
                }
            }

            return url;
        }
    }
}
