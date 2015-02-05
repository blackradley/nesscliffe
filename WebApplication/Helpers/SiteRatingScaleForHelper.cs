using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Glimpse.Core.Extensions;


namespace WebApplication.Helpers
{
    public static class SiteRatingScaleForHelper
    {
        public static MvcHtmlString SiteRatingScaleFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression, Dictionary<int, string> scale, String minLabel, String maxLabel)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            var label = htmlHelper.LabelFor(expression, htmlAttributes: new { @for = name });
            var help = htmlHelper.SiteHelpFor(expression);

            var minLabelBuilder = new TagBuilder("label");
            minLabelBuilder.MergeAttribute("align", "left");
            minLabelBuilder.InnerHtml += minLabel;

            var maxLabelBuilder = new TagBuilder("label");
            maxLabelBuilder.MergeAttribute("align", "right");
            maxLabelBuilder.InnerHtml += maxLabel;

            var scaleDivBuilder = new TagBuilder("div");
            scaleDivBuilder.MergeAttribute("align", "center");
            scaleDivBuilder.InnerHtml += minLabel + "\n";
            foreach (var rating in scale)
            {
                var radioLabelBuilder = new TagBuilder("label");
                radioLabelBuilder.InnerHtml += htmlHelper.RadioButtonFor(expression, rating.Key, htmlAttributes: new { @title = rating.Value });
                scaleDivBuilder.InnerHtml += radioLabelBuilder + "\n";
            }
            scaleDivBuilder.InnerHtml += maxLabel + "\n";

            return new MvcHtmlString(label + "\n" + help + "\n " + scaleDivBuilder);
        }
    }
}