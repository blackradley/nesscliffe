using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess;

namespace WebApplication.Helpers
{
    public static class MonthSummaryIconsForHelper
    {
        struct IconProperties
        {
            public Boolean IsDisplayed;
            public String Description;
        }

        public static MvcHtmlString MonthSummaryIconsFor(this HtmlHelper htmlHelper, Month month)
        {
            var icons = new Dictionary<String, IconProperties>
            {
                // ATTENTION
                {
                    "Marketing", new IconProperties
                    {
                        IsDisplayed = month.MarketingEffort > 0,
                        Description = month.MarketingEffort + " hours of marketing effort"
                    }
                },
                {
                    "Website", new IconProperties
                    {
                        IsDisplayed = month.WebsiteVisitors > 0,
                        Description = month.WebsiteVisitors + " website visitors"
                    }
                },
                // ARRIVING
                {
                    "Arriving", new IconProperties
                    {
                        IsDisplayed = month.VisitorsGeneral > 0,
                        Description = month.VisitorsGeneral + " visitors"
                    }
                },
                // SHOPPING
                {
                    "ShoppingYes", new IconProperties
                    {
                        IsDisplayed = month.IsRetail ?? false,
                        Description = "£" + month.IncomeRetail + " retail income"
                    }
                },
                {
                    "ShoppingNo", new IconProperties
                    {
                        IsDisplayed = !month.IsRetail ?? false,
                        Description = "No shop"
                    }
                },
                //REFRESHMENT
                {
                    "CateringYes", new IconProperties
                    {
                        IsDisplayed = month.IsRefreshment ?? false,
                        Description = "£" + month.IncomeRefreshment + " catering income"
                    }
                },
                {
                    "CateringNo", new IconProperties
                    {
                        IsDisplayed = !month.IsRefreshment ?? false,
                        Description = "No catering"
                    }
                },
                // DONATION
                {
                    "DonationYes", new IconProperties
                    {
                        IsDisplayed = month.IsDonationOpportunity ?? false,
                        Description ="£ " +  month.IncomeDonation + " donation income"
                    }
                },
                {
                    "DonationNo", new IconProperties
                    {
                        IsDisplayed = !month.IsDonationOpportunity ?? false,
                        Description = "No donation opportunities"
                    }
                },
                // EXPERIENCE
                {
                    "ExperienceYes", new IconProperties
                    {
                        IsDisplayed = month.IsAdditionalEvents ?? false,
                        Description ="£ " +  month.IncomeAdditionalEvents + " events income"
                    }
                },
                {
                    "ExperienceNo", new IconProperties
                    {
                        IsDisplayed = !month.IsAdditionalEvents ?? false,
                        Description = "No additional events"
                    }
                }

            };

            var spanBuilder = new TagBuilder("span");
            foreach (KeyValuePair<string, IconProperties> icon in icons)
            {
                if (icon.Value.IsDisplayed)
                {
                    var imgbuilder = new TagBuilder("img");
                    imgbuilder.MergeAttribute("src", "/Content/Images/Icons/" + icon.Key + ".png");
                    imgbuilder.MergeAttribute("width", "16");
                    imgbuilder.MergeAttribute("class", "icon");

                    var name = icon.Value.Description;
                    imgbuilder.MergeAttribute("title", name);
                    imgbuilder.MergeAttribute("alt", name);
                    spanBuilder.InnerHtml += imgbuilder.ToString(TagRenderMode.SelfClosing);
                }
            }
            return MvcHtmlString.Create(spanBuilder.ToString());
        }
    }
}