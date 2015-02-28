using System.Web.Mvc;
using DataAccess;

namespace WebApplication.Helpers
{
    public static class MonthSummaryIconsForHelper
    {
        public static MvcHtmlString MonthSummaryIconsFor(this HtmlHelper htmlHelper, Month month)
        {
            var spanBuilder = new TagBuilder("span");

            bool shoppingYes = month.IsRetail ?? false;
            bool shoppingNo = !month.IsRetail ?? false;

            if (shoppingYes) // is true then spit out the HTML for the icon
            {
                var imgbuilder = new TagBuilder("img");
                imgbuilder.MergeAttribute("src", "/Content/Images/Icons/ShoppingYes.png");
                imgbuilder.MergeAttribute("width", "16");
                spanBuilder.InnerHtml += imgbuilder.ToString(TagRenderMode.SelfClosing);
            }

            if (shoppingNo) // is true then spit out the HTML for the icon
            {
                var imgbuilder = new TagBuilder("img");
                imgbuilder.MergeAttribute("src", "/Content/Images/Icons/ShoppingNo.png");
                imgbuilder.MergeAttribute("width", "16");
                spanBuilder.InnerHtml += imgbuilder.ToString(TagRenderMode.SelfClosing);
            }


            return MvcHtmlString.Create(spanBuilder.ToString());
        }
    }
}