using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace Training.Utilities.BaseCore.Examples
{
    /// <summary>
    /// 
    /// </summary>
    public class FieldTypeManager
    {
        Item item { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Field Field
        {
            get
            {
                Field field = item.Fields["Field Name"];

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MultilistField MultilistField
        {
            get
            {
                MultilistField multilistField = item.Fields["Field Name"];

                Item[] items = multilistField.GetItems();
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public LinkField LinkField
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckboxField CheckboxField
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateField DateField
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceField ReferenceField
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public FileField FileField
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ImageField ImageField
        {
            get
            {
                return null;
            }
        }   
    }
}
