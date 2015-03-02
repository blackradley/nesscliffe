using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebApplication.Helpers
{
    public static class SiteYesNoForHelper
    {
        /// <summary>
        ///     Extension method to provide consistent radio button layouts.
        /// </summary>
        public static MvcHtmlString SiteYesNoFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression)
        {
            //<div class="col-md-3 col-sm-6">
            //    @Html.LabelFor(model => model.IsRetail)
            //    <label>
            //        @Html.RadioButtonFor(model => model.IsRetail, "true") Yes
            //        @Html.RadioButtonFor(model => model.IsRetail, "false") No
            //    </label>
            //    <a href="#" data-toggle="tooltip" data-title="Is there a shop at your site?">
            //        <span class="glyphicon glyphicon-info-sign"></span>
            //    </a>
            //</div>
            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("col-md-3 col-sm-6");
            divBuilder.InnerHtml += htmlHelper.LabelFor(expression) + " ";

            var labelbuilder = new TagBuilder("label");
            labelbuilder.InnerHtml += " ";
            labelbuilder.InnerHtml += htmlHelper.RadioButtonFor(expression, "true") + " Yes ";
            labelbuilder.InnerHtml += htmlHelper.RadioButtonFor(expression, "false") + " No ";

            var helpIcon = " " + htmlHelper.SiteHelpFor(expression);
            var validation = " " + htmlHelper.ValidationMessageFor(expression);

            divBuilder.InnerHtml += labelbuilder.ToString();
            divBuilder.InnerHtml += helpIcon;
            divBuilder.InnerHtml += validation;
            return MvcHtmlString.Create(divBuilder.ToString());
        }
    }
}