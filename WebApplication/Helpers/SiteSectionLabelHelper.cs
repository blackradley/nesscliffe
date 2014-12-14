using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace WebApplication.Helpers
{
    public static class SiteSectionLabelHelper
    {
        public static MvcHtmlString SiteSectionLabel(this HtmlHelper htmlHelper, String text, String help)
        {
            //<label>About the Site</label>
            //<a href="#" data-toggle="tooltip" data-title="Check the boxes which apply to your site">
            //    <span class="glyphicon glyphicon-info-sign"></span>
            //</a>
            var labelBuilder = new TagBuilder("label");
            labelBuilder.SetInnerText(text);
            var aBuilder = new TagBuilder("a");
            aBuilder.MergeAttribute("href", "#");
            aBuilder.MergeAttribute("data-toggle", "tooltip");
            aBuilder.MergeAttribute("data-title", help);
            var spanBuilder = new TagBuilder("span");
            spanBuilder.AddCssClass("glyphicon glyphicon-info-sign");
            aBuilder.InnerHtml += spanBuilder.ToString();
            return MvcHtmlString.Create(labelBuilder.ToString() + "&nbsp;" + aBuilder.ToString());
        }
    }
}