using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ClassLibrary;
using Microsoft.Ajax.Utilities;

namespace WebApplication.Helpers
{
    public static class SiteSummaryIconsForHelper
    {
        public static MvcHtmlString SiteSummaryIconsFor(this HtmlHelper htmlHelper, Site site)
        {
            var icons = new Dictionary<string, Boolean>
            {
                {"IsMuseum", site.IsMuseum},
                {"IsAccredited", site.IsAccredited},
                {"IsCastle", site.IsCastle},
                {"IsHistoricHouse", site.IsHistoricHouse},
                {"IsArtsCentre", site.IsArtsCentre},
                {"IsGallery", site.IsGallery},
                {"IsWorldHeritageSite", site.IsWorldHeritageSite},
                {"IsOpenAir", site.IsOpenAir},
                {"IsHeritageSite", site.IsHeritageSite},
                {"IsNationalTrust", site.IsNationalTrust}
            };
            var divBuilder = new TagBuilder("div");
            foreach (KeyValuePair<string, bool>icon in icons)
            {
                if (icon.Value) // is true then spit out the HTML for the icon
                {
                    var imgbuilder = new TagBuilder("img");
                    imgbuilder.MergeAttribute("src", "/Content/Images/Icons/" + icon.Key + ".png");
                    imgbuilder.MergeAttribute("width", "16");

                    var name = icon.Key;
                    Attribute attribute = site.GetAttributeFrom<DisplayAttribute>(icon.Key);
                    if (attribute != null) name = site.GetAttributeFrom<DisplayAttribute>(icon.Key).Name;

                    imgbuilder.MergeAttribute("title", name);
                    imgbuilder.MergeAttribute("alt", name);
                    divBuilder.InnerHtml += imgbuilder.ToString(TagRenderMode.SelfClosing);
                }
            }
            return MvcHtmlString.Create(divBuilder.ToString());
        }
    }
}