using System;
using System.Collections.Specialized;
using System.Web.UI;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Training.Utilities.Basecore.Base;
using System.Collections.Generic;
using System.Linq;
using Training.Utilities.Basecore.References;
using Generic.SitecoreUtilities.Fields;

namespace Training.BaseCore.Layouts.Widgets {

    /// <summary>
    /// A vertical widget used on the holiday page. Uses the same base class as 
    /// <see cref="Training.BaseCore.Layouts.Widgets.WidgetQuarter"/> with some added functionality.
    /// </summary>
    public partial class WidgetHolidaySummary : BaseWidget
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Item source = GetItem();

            if (source.TemplateID == TemplateReferences.Holiday)
            {
                SummaryHeading.Item = source;

                ReferenceField type = source.Fields["Type"];

                if (type != null)
                {
                    if (type.TargetItem != null)
                    {
                        txtType.Item = type.TargetItem;
                    }
                }

                ReferenceField difficulty = source.Fields["Difficulty"];

                if (difficulty != null)
                {
                    if (difficulty.TargetItem != null)
                    {
                        txtDifficulty.Item = difficulty.TargetItem;
                    }
                }

                MultilistField terrains = source.Fields["Terrain"];

                if (terrains != null)
                {
                    var terrainItems = terrains.GetItems();

                    if (terrainItems.Any())
                    {
                        litTerrain.Text = string.Join(", ", terrainItems.Select(x => FieldRenderer.Render(x, "Text", "disable-web-editing=true")).ToList());
                    }
                }
            }
        }      
    }
}