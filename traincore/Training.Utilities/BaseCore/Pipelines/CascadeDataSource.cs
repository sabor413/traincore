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
using System.Collections.Specialized;
using Sitecore.Collections;
using Training.Utilities.Basecore.References;

namespace Training.Utilities.BaseCore.Pipelines
{
    /// <summary>
    /// This is an example of a pipeline. It has a corresponding .config file in
    /// App_Config/Include/BaseCore that patches it in *after* renderings are inserted.
    /// 
    /// The purpose of the pipeline is to look at the rendering, check if it has a data source
    /// set, and if not - and 'Cascade' is checked - find the SAME rendering (not the same type, but 
    /// the same instance of the same rendering, with the same UniqueID), and use its data source instead.
    /// 
    /// UniqueIDs will match on items based on the same template on the renderings set on the standard values
    /// of that template. For example, if a 'Booking Bump' rendering is set on all 'Holiday' standard values,
    /// it will have the same UniqueID on all instances of the 'Holiday' template.
    /// 
    /// The pipeline is useful if you want to set a datasource globally - e.g. the three footer widgets - rather
    /// than setting it on every page. The renderings are defined on a base template standard values, and all
    /// pages will consequently have them. The data source can then be set on the root item - or overriden per
    /// section if need be.
    /// </summary>
    public class CascadeDataSource : InsertRenderingsProcessor
    {
        protected readonly string QueryPrefix = "query:";
        protected readonly string Cascade = "Cascade";
        protected readonly string RemoteItem = "Cascade Item";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void Process(InsertRenderingsArgs args)
        {
            if (!args.HasRenderings) return;
            
            foreach (var rendering in args.Renderings)
            {
                SetRenderingDataSource(rendering);                
            }
        }

        /// <summary>
        /// Sets rendering data source based on cascaded value or the item specified.
        /// </summary>
        /// <param name="renderingReference"></param>
        private void SetRenderingDataSource(RenderingReference rendering)
        {
            var parameters = WebUtil.ParseQueryString(rendering.Settings.Parameters);

            if (DataSourceIsEmpty(rendering.Settings.DataSource) && parameters.ContainsKey(Cascade))
            {
                RenderingReference renderingOnOtherItem = null;

                var shouldCascade = parameters[Cascade];

                /* If not, check if 'cascade' is checked */

                if ("1".Equals(shouldCascade))
                {
                    RenderingReference remoteItemRendering = GetRemoteItemRendering(parameters, rendering);

                    /* Otherwise loop through ancestors */

                    if (remoteItemRendering == null)
                    {
                        renderingOnOtherItem = FindRenderingOnAncestor(Context.Item.Parent, rendering);

                        if (renderingOnOtherItem != null)
                        {
                            rendering.Settings.DataSource = renderingOnOtherItem.Settings.DataSource;
                        }
                    }
                    else
                    {
                        rendering.Settings.DataSource = remoteItemRendering.Settings.DataSource;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datasource"></param>
        /// <returns></returns>
        private bool DataSourceIsEmpty(string datasource)
        {
            if (!String.IsNullOrEmpty(datasource))
            {
                Guid guid = Guid.Empty;
                Item ds = null;

                if (Guid.TryParse(datasource, out guid))
                {
                    ds = Sitecore.Context.Database.GetItem(new ID(datasource));
                }
                else
                {
                    ds = Sitecore.Context.Database.GetItem(datasource);
                }

                if (ds != null)
                {
                    if (ds.Paths.IsDescendantOf(ItemReferences.Samples))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the matching rendering item on the remote item specified, if one has been specified.
        /// </summary>
        /// <returns></returns>
        private RenderingReference GetRemoteItemRendering(SafeDictionary<string> parameters, RenderingReference rendering)
        {
            RenderingReference renderingReference = null;

            var cascadeItem = parameters[RemoteItem];

            if (!String.IsNullOrEmpty(cascadeItem))
            {
                Guid itemReference = Guid.Empty;
                if (Guid.TryParse(cascadeItem, out itemReference))
                {
                    Item referenceItem = Sitecore.Context.Database.GetItem(new ID(itemReference));

                    if (referenceItem != null)
                    {
                        renderingReference = GetSameRenderingOnItem(referenceItem, rendering);
                    }
                }
            }

            return renderingReference;
        }

        /// <summary>
        /// Returns matching rendering on an ancestor item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="rendering"></param>
        /// <returns></returns>
        private static RenderingReference FindRenderingOnAncestor(Item item, RenderingReference rendering)
        {
            if (item == null) return null;

            var renderingOnParentItem = GetSameRenderingOnItem(item, rendering);
            
            if (renderingOnParentItem != null && renderingOnParentItem.Settings.DataSource != "")
            {
                return renderingOnParentItem;
            }

            return FindRenderingOnAncestor(item.Parent, rendering);
        }

        /// <summary>
        /// Get rendering on specified item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="rendering"></param>
        /// <returns></returns>
        private static RenderingReference GetSameRenderingOnItem(Item item, RenderingReference rendering)
        {
            LayoutField layoutField = item.Fields[FieldIDs.LayoutField];

            if (layoutField == null) return null;

            RenderingReference[] references = layoutField.GetReferences(Context.Device);

            if (references == null || references.Length == 0) return null;
            
            var renderingOnParentItem = references.FirstOrDefault(r => r.UniqueId == rendering.UniqueId);
            
            return renderingOnParentItem;
        }
    }
}
