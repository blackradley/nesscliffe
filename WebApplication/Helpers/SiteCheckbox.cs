using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ClassLibrary;
using Microsoft.Ajax.Utilities;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace WebApplication.Helpers
{
    public static class SiteCheckboxHelper
    {
        public static MvcHtmlString SiteCheckbox<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string help)
        {
            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("checkbox col-md-3 col-sm-6");

            var labelbuilder = new TagBuilder("label");
            labelbuilder.InnerHtml += htmlHelper.EditorFor(expression);
            labelbuilder.InnerHtml += " ";
            labelbuilder.InnerHtml += htmlHelper.LabelFor(expression);
            labelbuilder.InnerHtml += " ";

            var aBuilder = new TagBuilder("a");
            aBuilder.MergeAttribute("href", "#");

            var spanBuilder = new TagBuilder("span");
            spanBuilder.AddCssClass("glyphicon glyphicon-info-sign");
            spanBuilder.MergeAttribute("data-toggle", "tooltip");
            spanBuilder.MergeAttribute("data-title", help);

            aBuilder.InnerHtml += spanBuilder.ToString(TagRenderMode.SelfClosing);
            labelbuilder.InnerHtml += aBuilder.ToString();
            divBuilder.InnerHtml += labelbuilder.ToString();

            return MvcHtmlString.Create(divBuilder.ToString());
        }
    }
}