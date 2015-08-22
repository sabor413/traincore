using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Templates;

namespace Training.Utilities.Basecore.References
{
    /// <summary>
    /// A central list of item GUIDs. Because this is a multi-site installation, no items apart from global settings items
    /// are referenced.
    /// </summary>
    public class ItemReferences
    {
        #region Queries

        private static readonly string queryAncestorOrSelfByTemplate = "ancestor-or-self::*[@@templateid='{0}']";

        #endregion

        #region Settings Items

        public static Item SettingsHeadings { get { return Sitecore.Context.Database.GetItem(new ID("{444CDDCD-497B-4505-BD76-D0E71C452629}")); } }
        public static Item Samples { get { return Sitecore.Context.Database.GetItem(new ID("{F185C049-BA44-491A-8DE0-B9CC382A758B}")); } }
        public static Item SampleWidget { get { return Sitecore.Context.Database.GetItem(new ID("{79DF8FFB-508C-4768-8E75-F8BA92886ECE}")); } }
        public static Item SampleHolidayImage { get { return Sitecore.Context.Database.GetItem(new ID("{F373F551-FBC1-42B3-85CE-2C0F7EC63087}")); } }
        public static Item InvalidSurname { get { return Sitecore.Context.Database.GetItem(new ID("{40864D59-6D0E-4384-8CD7-B92611D60588}")); } }
        public static Item InvalidName { get { return Sitecore.Context.Database.GetItem(new ID("{6FF3E10B-E1CB-4534-927F-4DBB81AF22CC}")); } }

        #endregion

        #region Query Items

        /// <summary>
        /// 
        /// </summary>
        public static Item SiteRoot
        {
            get
            {
                return Sitecore.Context.Item.Axes.SelectSingleItem(String.Format(queryAncestorOrSelfByTemplate, TemplateReferences.SiteFolder.ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item SiteHome
        {
            get
            {
                return Sitecore.Context.Item.Axes.SelectSingleItem(String.Format(queryAncestorOrSelfByTemplate, TemplateReferences.Home.ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item Global
        {
            get
            {
                return SiteRoot.Children.Where(x => x.TemplateID == TemplateReferences.Global).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item Terrains
        {
            get
            {
                return Global.Children.Where(x => x.TemplateID == TemplateReferences.TerrainsFolder).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item HolidayTypes
        {
            get
            {
                return Global.Children.Where(x => x.TemplateID == TemplateReferences.HolidayTypesFolder).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item BookingsRoot
        {
            get
            {
                return SiteRoot.Children.Where(x => x.TemplateID == TemplateReferences.BookingsFolder).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Item BookingsPage
        {
            get
            {
                return SiteHome.Children.Where(x => x.TemplateID == TemplateReferences.BookingsPage).FirstOrDefault();
            }
        }

        /// <summary>
        /// We expect the 'Holidays' item to be a direct child of 'Home'. Using GetDescendants() is expensive on a large tree.
        /// </summary>
        public static Item HolidaysRoot
        {
            get
            {
                Item holidaysRoot = null;

                if (SiteHome != null)
                {
                    holidaysRoot = SiteHome.Children.Where(x => x.TemplateID == TemplateReferences.Holidays).FirstOrDefault();
                }

                return holidaysRoot;
            }
        }

        #endregion

    }
}
