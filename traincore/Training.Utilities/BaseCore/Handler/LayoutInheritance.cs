using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Pipelines.InsertRenderings;
using Sitecore.Layouts;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore;
using System.Web;
using Sitecore.Web;
using Sitecore.Data;
using Sitecore.Events;
using Sitecore.Globalization;
using Sitecore.Data.Templates;
using Sitecore.Data.Managers;
using Sitecore.SecurityModel;

namespace Training.Utilities.BaseCore.Handlers
{
    /// <summary>
    /// Originally by the folks at Cognifide: http://www.cognifide.com/blogs/sitecore/complex-layouts-in-sitecore-using-standard-values-hierarchy/ 
    /// This is a handler that responds to the 'OnItemSaving' event. Corresponding .config in App_Data/Include/BaseCore/BaseCore.LayoutInheritance.config.
    /// 
    /// The purpose of this event is to check if the item being saved is a standard values item (a template's standard values), and if so,
    /// cascade any changes (more specifically, cascade the 'layout deltas', which store only changes) to the presentation details to any templates based on it.
    /// 
    /// For example - we might want to add a 'header' rendering to a base template that already contains a 'footer' rendering. This change
    /// will not be reflected in child templates (unless they only inherit presentation details and do not have *any* set on their own
    /// standard values) unless the layout deltas are copied down.
    /// 
    /// For more information about layout deltas, see: http://sdn.sitecore.net/upload/sitecore6/64/what%27s%20new%20in%20sc6.4-a4.pdf#search=%22layout%22
    /// </summary>
    public class LayoutInheritance
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnItemSaving(object sender, EventArgs args)
        {
            Item item = Event.ExtractParameter(args, 0) as Item;
            PropagateLayoutChanges(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void PropagateLayoutChanges(Item item)
        {
            if (item != null)
            {
                if (StandardValuesManager.IsStandardValuesHolder(item))
                {
                    Item oldItem = item.Database.GetItem(item.ID, item.Language, item.Version);

                    string layout = item[FieldIDs.LayoutField];

                    string oldLayout = oldItem[FieldIDs.LayoutField];

                    if (layout != oldLayout)
                    {
                        string delta = XmlDeltas.GetDelta(layout, oldLayout);

                        foreach (Template templ in TemplateManager.GetTemplate(item).GetDescendants())
                        {
                            ApplyDeltaToStandardValues(templ, delta, item.Language, item.Version, item.Database);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="delta"></param>
        /// <param name="language"></param>
        /// <param name="version"></param>
        /// <param name="database"></param>
        private void ApplyDeltaToStandardValues(Template template, string delta, Language language, Sitecore.Data.Version version, Database database)
        {
            if (Sitecore.Context.User.IsAdministrator)
            {
                if (template != null)
                {
                    if (!Sitecore.Data.ID.IsNullOrEmpty(template.StandardValueHolderId))
                    {
                        Item item = ItemManager.GetItem(template.StandardValueHolderId, language, version, database, SecurityCheck.Disable);

                        if (item != null)
                        {
                            Field field = item.Fields[FieldIDs.LayoutField];

                            if (!field.ContainsStandardValue)
                            {
                                try
                                {
                                    string newFieldValue = XmlDeltas.ApplyDelta(field.Value, delta);

                                    if (newFieldValue != field.Value)
                                    {
                                        item.Editing.BeginEdit();
                                        LayoutField.SetFieldValue(field, newFieldValue);
                                        item.Editing.EndEdit();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Sitecore.Diagnostics.Log.Error(ex.Message, this);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
