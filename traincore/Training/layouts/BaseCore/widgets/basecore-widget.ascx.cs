using System;
using Sitecore.Data.Items;
using Training.Utilities.Basecore.Base;
using Training.Utilities.Basecore.References;

namespace Training.BaseCore.Layouts.Widgets {

    /// <summary>
    /// A horizonal widget that takes up one third of the width of the container. Programmatically dentical to 
    /// <see cref="Training.BaseCore.Layouts.Widgets.WidgetVertical"/> but uses a base class to achieve the same functionality.
    /// </summary>
    public partial class GeneralWidget : BaseWidget
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Item source = this.GetItem();

            if (source != null)
            {
                if (source.ID == Sitecore.Context.Item.ID)
                {
                    source = ItemReferences.SampleWidget;

                    WidgetHeading.DisableWebEditing = true;
                    WidgetText.DisableWebEditing = true;
                    WidgetLink.DisableWebEditing = true;
                    WidgetImage.DisableWebEditing = true;
                }

                WidgetHeading.Item = source;
                WidgetText.Item = source;
                WidgetLink.Item = source;
                WidgetImage.Item = source;
                WidgetImage.Visible = !HideImage;

                WidgetImage.CssClass = ImageOrientation;
            }
        }
    }
}