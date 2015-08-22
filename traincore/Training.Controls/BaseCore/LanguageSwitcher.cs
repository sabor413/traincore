using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Web.UI;
using Training.Utilities.Basecore.Base;
using System.Web.UI;
using Sitecore.Data.Items;
using Training.Utilities.Basecore.References;
using Sitecore.Web.UI.WebControls;
using Training.Utilities.Basecore;
using Sitecore.Collections;
using Sitecore.Data.Managers;
using System.Globalization;
using Sitecore.Globalization;

namespace Training.Controls.BaseCore
{
    /// <summary>
    /// A set of gallery slides, each with with a heading, text, and a link. Interchangeable with
    /// <see cref="Training.Controls.BaseCore.Banner"/>
    /// </summary>
    public class LanguageSwitcher : WebControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        protected override void DoRender(HtmlTextWriter output)
        {
            LanguageCollection languageCollection = LanguageManager.GetLanguages(Sitecore.Context.Database);

            output.BeginRender();

            if (languageCollection.Any())
            {
                output.AddAttribute(HtmlTextWriterAttribute.Class, "pickLanguage");
                output.RenderBeginTag(HtmlTextWriterTag.P);

                foreach (Language language in languageCollection)
                {
                    Sitecore.Data.ID contextLanguageId = LanguageManager.GetLanguageItemId(language, Sitecore.Context.Database);
                    Item contextLanguage = Sitecore.Context.Database.GetItem(contextLanguageId);

                    string iso = contextLanguage.Fields["Regional Iso Code"].Value;
                    if (string.IsNullOrEmpty(iso))
                    {
                        iso = contextLanguage["Iso"];
                    }
                    output.AddAttribute(HtmlTextWriterAttribute.Href, String.Format("?sc_lang={0}", iso));
                    output.RenderBeginTag(HtmlTextWriterTag.A);
                    output.WriteLine(FieldRenderer.Render(contextLanguage, "Display Image", "mw=20"));
                    output.RenderEndTag();
                }

                output.RenderEndTag();
            }

            output.EndRender();
        }
    }
}
