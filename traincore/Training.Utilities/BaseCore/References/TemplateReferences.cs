using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generic.SitecoreUtilities.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Templates;
using Training.Utilities.BaseCore;

namespace Training.Utilities.Basecore.References
{
    /// <summary>
    /// A central list of item GUIDs. Because this is a multi-site installation, no items apart from global settings items
    /// are referenced.
    /// </summary>
    public class TemplateReferences
    {


#region TemplateIDs        
        public static TemplateID Home { get { return new TemplateID(new ID("{6D33B111-0B0C-42AF-BC95-A4EEF0B91750}")); } }
        public static TemplateID SiteFolder { get { return new TemplateID(new ID("{049E2391-BAA5-4612-B344-FD1D22223AE3}")); } }
        public static TemplateID Gallery { get { return new TemplateID(new ID("{F0CF43A6-8032-4F53-B097-1BA81AA050FE}")); } }
        public static TemplateID GalleryItem { get { return new TemplateID(new ID("{66EE22F4-5739-4B2B-B872-B47AA0E757FD}")); } }
        public static TemplateID Holidays { get { return new TemplateID(new ID("{DD26EA6A-C8E4-4E6E-A45C-577A07C3D7B4}")); } }
        public static TemplateID Holiday { get { return new TemplateID(new ID("{2215329C-3E5D-4592-A831-1D4E651DE34C}")); } }
        public static TemplateID HolidayDate { get { return new TemplateID(new ID("{5A87E692-6E40-46FE-8AB4-84ECA154E9C1}")); } }
        public static TemplateID HolidayDates { get { return new TemplateID(new ID("{5498CFEF-FBA7-4448-83D7-5EFFB5649767}")); } }
        public static TemplateID Itinerary { get { return new TemplateID(new ID("{EC705A7F-B1DD-46AC-9EEF-0E377B31A740}")); } }
        public static TemplateID BookingsFolder { get { return new TemplateID(new ID("{33EE182A-80B3-46B6-9917-6820E066A82D}")); } }
        public static TemplateID Booking { get { return new TemplateID(new ID("{8AF0B408-19D7-4913-B28A-53EE44E4EBCC}")); } }
        public static TemplateID BookingsPage { get { return new TemplateID(new ID("{8662FF25-9E18-443A-BC06-78FA0E8DD803}")); } }
        public static TemplateID NewsListing { get { return new TemplateID(new ID("{48540D51-A7BD-432B-9ECB-EFCFB5696715}")); } }
        public static TemplateID Global { get { return new TemplateID(new ID("{5BB6C72C-3183-4DAD-B7A7-3A91C2C87744}")); } }
        public static TemplateID TerrainsFolder { get { return new TemplateID(new ID("{6B8BBB22-D4E2-4E5C-8731-92CB87853C50}")); } }
        public static TemplateID HolidayTypesFolder { get { return new TemplateID(new ID("{E77B1BAF-1E86-485A-B478-1C2FAEC5298D}")); } }
        public static TemplateID QuoteText { get { return new TemplateID(new ID("{8FA0C456-7CDD-4C43-B367-8701508E934C}")); } }
        
        #endregion
    }
}
