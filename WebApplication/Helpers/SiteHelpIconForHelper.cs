using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Helpers
{
    public static class SiteHelpIconForHelper
    {
        public static MvcHtmlString SiteHelpFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression)
        {
            //<a href="#" data-toggle="tooltip" data-title="How big is the indoor area which visitors can visit?  In hectares or acres.">
            //    <span class="glyphicon glyphicon-info-sign"></span>
            //</a>
            var aBuilder = new TagBuilder("a");
            aBuilder.MergeAttribute("href", "#");
            aBuilder.MergeAttribute("data-toggle", "tooltip");

            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            if (!string.IsNullOrEmpty(metaData.Description)) aBuilder.MergeAttribute("data-title", metaData.Description);

            var spanBuilder = new TagBuilder("span");
            spanBuilder.AddCssClass("glyphicon glyphicon-info-sign");
            aBuilder.InnerHtml += spanBuilder.ToString();

            return MvcHtmlString.Create(aBuilder.ToString());
        }
    }
}