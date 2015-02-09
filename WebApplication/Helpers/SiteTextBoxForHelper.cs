using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebApplication.Helpers
{
    public static class SiteTextBoxForHelper
    {
        /// <summary>
        /// Extension method to provide consistent check box layouts.
        /// </summary>
        public static MvcHtmlString SiteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TValue>> expression)
        {
            //@Html.LabelFor(model => model.WebsiteUrl, htmlAttributes: new { @for = "WebsiteUrl" })
            //@Html.SiteHelpFor(model => model.WebsiteUrl)
            //@Html.EditorFor(model => model.WebsiteUrl, new { htmlAttributes = new { @class = "form-control", @name = "WebsiteUrl", @style = "max-width: 500px;" } })
            //@Html.ValidationMessageFor(model => model.WebsiteUrl)
            string name = ExpressionHelper.GetExpressionText(expression);
            var label = htmlHelper.LabelFor(expression, htmlAttributes: new {@for = name});
            var help = htmlHelper.SiteHelpFor(expression);

            // Get the display name for the placeholder
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var displayName = metaData.DisplayName;
            // Attributes for the editor
            var htmlAttributes = new ViewDataDictionary
            {
                { "class", "form-control" }, 
                { "style", "max-width: 500px;" },
                { "name", name},
                { "placeholder", displayName}
            };
            var editor = htmlHelper.EditorFor(expression, new { htmlAttributes });
            var validation = htmlHelper.ValidationMessageFor(expression);
            return new MvcHtmlString(label + "\n" + help + "</br>" + editor + "\n" + validation);
        }
    }
}