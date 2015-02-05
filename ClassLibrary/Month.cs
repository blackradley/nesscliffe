﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    [Table("Months")]
    public class Month
    {
        [Key]
        public virtual Guid Id { get; set; }
        // Foreign key and navigation property back to site
        public virtual Guid SiteId { get; set; }
        [ForeignKey("SiteId")]
        public virtual Site Site { get; set; }

        [Display(Name = "Month")]
        [Column(TypeName = "DateTime2")]
        public virtual DateTime MonthTime { get; set; }

        #region ATTENTION
        [Display(Name = "Marketing Spend", Description = "How much have you spent on marketing this month?")]
        [Range(0, 99999, ErrorMessage = "Area must be between 0 and 99999")]
        public virtual int? MarketingSpend { get; set; }
        [Display(Name = "Regional TV", Description = "Has your site appeared on regional TV?")]
        public virtual bool RegionalTv { get; set; }
        [Display(Name = "National TV", Description = "Has your site appeared on national TV?")]
        public virtual bool NationalTv { get; set; }
        [Display(Name = "Overseas TV", Description = "Has your site appeared on TV in another country?")]
        public virtual bool OverseasTv { get; set; }
        [Display(Name = "Website Url", Description = "What is your web site address?")]
        public virtual String WebsiteUrl { get; set; }
        [Display(Name = "Website Visitors", Description = "How many visitors did your website get this month?")]
        public virtual int? WebsiteVisitors { get; set; }
        [Display(Name = "Facebook Url", Description = "If you have a Facebook page, what it the address?")]
        public virtual String FacebookUrl { get; set; }
        [Display(Name = "Twitter Url", Description = "If you have a Twitter page, what it the address?")]
        public virtual String TwitterUrl { get; set; }
        [Display(Name = "Flickr Url", Description = "If you have a Flickr page, what it the address?")]
        public virtual String FlickrUrl { get; set; }
        [Display(Name = "Instagram Url", Description = "If you have an Instagram page, what it the address?")]
        public virtual String InstagramUrl { get; set; }
        [Display(Name = "Youtube Url", Description = "If you have a Youtube page, what it the address?")]
        public virtual String YoutubeUrl { get; set; }
        [Display(Name = "Vimeo Url", Description = "If you have a Vimeo page, what it the address?")]
        public virtual String VimeoUrl { get; set; }
        [Display(Name = "Pinterest Url", Description = "If you have a Pinterest page, what it the address?")]
        public virtual String PinterestUrl { get; set; }
        #endregion

        #region ARRIVING
        [Display(Name = "Visitor Numbers", Description = "How many visitors came to your site this month?")]
        public virtual int NumberVisitors { get; set; }
        [Display(Name = "Visitor Income", Description = "What was the income from visitors this month?")]
        public virtual int IncomeAdmissions { get; set; }
        [Display(Name = "Additional Events", Description = "How many additional events did you run at your site this month?")]
        public virtual int NumberAdditionalEvents { get; set; }
        [Display(Name = "Additional Events Numbers", Description = "How many visitors took part in additional events at your site this month?")]
        public virtual int NumberVisitorsAdditional { get; set; }
        [Display(Name = "Additional Events Income", Description = "What was the income from additional events this month?")]
        public virtual int IncomeAdditional { get; set; }

        [Display(Name = "Not with a Family", Description = "What percentage of visitors were not part of a family?")]
        public virtual int VisitorsPercentNoFamily { get; set; }
        [Display(Name = "Family", Description = "What percentage of visitors were part of a family?")]
        public virtual int VisitorsPercentFamily { get; set; }
        [Display(Name = "Retired", Description = "What percentage of visitors were retired?")]
        public virtual int VisitorsPercentRetired { get; set; }
        
        [Display(Name = "Monday", Description = "How many hours were you open on Mondays?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursMonday { get; set; }
        [Display(Name = "Tuesday", Description = "How many hours were you open on Tuesdays?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursTuesday { get; set; }
        [Display(Name = "Wednesday", Description = "How many hours were you open on Wednesdays?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursWednesday { get; set; }
        [Display(Name = "Thursday", Description = "How many hours were you open on Thursdays?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursThursday { get; set; }
        [Display(Name = "Friday", Description = "How many hours were you open on Fridays?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursFriday { get; set; }
        [Display(Name = "Saturday", Description = "How many hours were you open on Saturdays?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursSaturday { get; set; }
        [Display(Name = "Sunday", Description = "How many hours were you open on Sundays?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursSunday { get; set; }       
        #endregion

        #region SHOPPING
        [Display(Name = "Retail Income", Description = "How much was your retail income this month?")]
        public virtual int? IncomeRetail { get; set; }
        [Display(Name = "Shop behind pay barrier?", Description = "Do visitors have to pay to get to the shop?")]
        public virtual bool PayToShop { get; set; }
        [Display(Name = "Shop visible from entrance?", Description = "Can you see the shop before you enter?")]
        public virtual bool ShopVisibleFromEntrance { get; set; }
        [Display(Name = "Exit through the shop?", Description = "Do visitors have leave via the shop?")]
        public virtual bool ExitViaShop { get; set; }
        [Display(Name = "Distance to Shop", Description = "How far is it from the entrance to the shop?")]
        public virtual int? DistanceToShop { get; set; }
        public virtual int DistanceToShopUnits { get; set; }

        [Display(Name = "Area of Shop", Description = "How big is the shop?  In square feet or square metres.")]
        public virtual int? AreaShop { get; set; }
        public virtual int AreaShopUnits { get; set; }
        [Display(Name = "Number of Products", Description = "How many product lines does the shop have?")]
        public virtual int? NumberProducts { get; set; }
        [Display(Name = "Percentage Related Products", Description = "How many of those product lines are directly related to the site?")]
        public virtual int? PercentageRelatedProducts { get; set; }
        #endregion
        
        #region REFRESHMENT
        [Display(Name = "Catering Income", Description = "What was your catering income for this month?")]
        public virtual int? IncomeCatering { get; set; }
        [Display(Name = "Café behind pay barrier?", Description = "Do visitors have to pay to get to the café?")]
        public virtual bool PayToCafe { get; set; }
        [Display(Name = "Café visible from entrance?", Description = "Can you see the cafe before you enter the site?")]
        public virtual bool CafeVisibleFromEntrance { get; set; }
        [Display(Name = "Distance to Cafe", Description = "How far is it from the entrance to the café?")]
        public virtual int? DistanceToCafe { get; set; }
        public virtual int DistanceToCafeUnits { get; set; }
        [Display(Name = "Covers/Seats", Description = "How many people can the café seat?")]
        public virtual int? NumberCafeSeats { get; set; }
        [Display(Name = "Basserie and Bistro", Description = "Would you describe your café as a basserie or bistro style?")]
        public virtual bool IsBasserie { get; set; }
        [Display(Name = "Buffet and Smörgåsbord", Description = "Is your café buffet or smörgåsbord style?")]
        public virtual bool IsBuffet { get; set; }
        [Display(Name = "Café", Description = "Is your café just a regular café?")]
        public virtual bool IsCafe { get; set; }
        [Display(Name = "Cafeteria", Description = "Is your café cafeteria style?")]
        public virtual bool IsCafeteria { get; set; }
        [Display(Name = "Coffeehouse", Description = "Is your café really a kind of coffeehouse?")]
        public virtual bool IsCoffeehouse { get; set; }
        [Display(Name = "Destination Restaurant", Description = "Would you describe your cafe as a destination restaurant?")]
        public virtual bool IsDestinationRestaurant { get; set; }
        [Display(Name = "In House", Description = "Is the catering provided in house?")]
        public virtual bool IsCateringInHouse { get; set; }
        [Display(Name = "Out sourced to LA", Description = "Is the catering out sourced to the local authority?")]
        public virtual bool IsCateringOutToLocalAuthority { get; set; }
        [Display(Name = "Out sourced to Company", Description = "Is the catering out sourced to a private company?")]
        public virtual bool IsCateringOutToCompany { get; set; }
        #endregion
        
        #region DONATION
        [Display(Name = "Donation Opportunities", Description = "Do you provide visitors with opportunites to make donations?")]
        public virtual bool IsDonationOpportunity { get; set; }
        [Display(Name = "Donation Income", Description = "What was your income from donations for this month?")]
        public virtual int? IncomeDonation { get; set; }
        [Display(Name = "Distance to Donation", Description = "How far is it from the entrance to the first opportunity to make a donation?")]
        public virtual int? DistanceToDonation { get; set; }
        public virtual int DistanceToDonationUnits { get; set; }
        [Display(Name = "Number of Donation Boxes", Description = "How many donation opportunites does your site offer?")]
        public virtual int NumberDonationOpportunities { get; set; }
        #endregion
        
        #region EXPERIENCE
        [Display(Name = "Number of Artefacts", Description = "Approximately how many artefacts are in your collections?")]
        public virtual int? NumberArtefacts { get; set; }
        [Display(Name = "Artefacts on Display", Description = "Approximately what percentage of the artefacts are on display?")]
        public virtual int ArtefactsDisplay { get; set; }
        [Display(Name = "Outstanding Collections", Description = "Do you any collections designated 'Outstanding' by the Arts Council?")]
        public virtual bool IsCollectionOutstanding { get; set; }
        [Display(Name = "Outstanding Collections", Description = "How many collections are collections designated 'Outstanding' by the Arts Council?")]
        public virtual int NumberCollectionsOutstanding { get; set; }
        [Display(Name = "Describe your Programme", Description = "On this scale from niche interest to mass appeal?")]
        public virtual int ProgrammeMassAppeal { get; set; }
        #endregion
    }
}

