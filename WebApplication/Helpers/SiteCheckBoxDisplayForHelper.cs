using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebApplication.Helpers
{
    public static class SiteCheckBoxDisplayForHelper
    {
        public static MvcHtmlString SiteCheckBoxDisplayFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression)
        {
            //<div class="checkbox col-md-3 col-sm-6">
            //    <label>
            //        @Html.DisplayFor(model => model.Museum) @Html.DisplayNameFor(model => model.Museum)
            //    </label>
            //</div>
            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("checkbox col-md-3 col-sm-6");
            var labelbuilder = new TagBuilder("label");
            labelbuilder.InnerHtml += htmlHelper.DisplayFor(expression);
            labelbuilder.InnerHtml += " ";
            labelbuilder.InnerHtml += htmlHelper.LabelFor(expression);
            labelbuilder.InnerHtml += " ";
            divBuilder.InnerHtml += labelbuilder.ToString();
            return MvcHtmlString.Create(divBuilder.ToString());
        }
    }
}