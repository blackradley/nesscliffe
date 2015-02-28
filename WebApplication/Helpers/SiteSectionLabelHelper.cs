using System;
using System.Web.Mvc;

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
            var helpIcon = htmlHelper.SiteHelpFor(help);
            return MvcHtmlString.Create(labelBuilder.ToString() + "&nbsp;" + helpIcon.ToString());
        }
    }
}