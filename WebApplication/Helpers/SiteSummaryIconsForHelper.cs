using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAccess;

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
                {"IsArtsCentre", site.IsArts},
                {"IsGallery", site.IsGallery},
                {"IsWorldHeritageSite", site.IsWorldHeritageSite},
                {"IsOpenAir", site.IsOpenAir},
                {"IsHeritageSite", site.IsHeritageSite},
                {"IsNationalTrust", site.IsNationalTrust},
                {"IsPark", site.IsPark},
                {"IsNatureReserve", site.IsNatureReserve}
            };
            var spanBuilder = new TagBuilder("span");
            foreach (KeyValuePair<string, bool>icon in icons)
            {
                if (icon.Value) // is true then spit out the HTML for the icon
                {
                    var imgbuilder = new TagBuilder("img");
                    imgbuilder.MergeAttribute("src", "/Content/Images/Icons/" + icon.Key + ".png");
                    imgbuilder.MergeAttribute("width", "16");
                    imgbuilder.MergeAttribute("class", "icon");

                    var name = icon.Key;
                    Attribute attribute = site.GetAttributeFrom<DisplayAttribute>(icon.Key);
                    if (attribute != null) name = site.GetAttributeFrom<DisplayAttribute>(icon.Key).Name;

                    imgbuilder.MergeAttribute("title", name);
                    imgbuilder.MergeAttribute("alt", name);
                    spanBuilder.InnerHtml += imgbuilder.ToString(TagRenderMode.SelfClosing);
                }
            }
            return MvcHtmlString.Create(spanBuilder.ToString());
        }
    }
}