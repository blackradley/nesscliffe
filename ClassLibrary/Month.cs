using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Display(Name = "Website Visitors", Description = "How many visitors did your website get?")]
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

        public virtual int Visitors { get; set; }
        public virtual float IncomeAdmissions { get; set; }
        public virtual float IncomeAdditional { get; set; }
        public virtual int VisitorsAdditional { get; set; }
        #endregion

        #region SHOPPING
        [Display(Name = "Retail Income", Description = "How much was your retail income this month?")]
        [Range(0, 99999, ErrorMessage = "Area must be between 0 and 99999")]
        public virtual int? RetailIncome { get; set; }
        [Display(Name = "Shop behind pay barrier?", Description = "Do visitors have to pay to get to the shop?")]
        public virtual bool PayToShop { get; set; }
        [Display(Name = "Shop visible from entrance?", Description = "Can you see the shop before you enter?")]
        public virtual bool ShopVisibleFromEntrance { get; set; }
        [Display(Name = "Exit through the shop?", Description = "Do visitors have leave via the shop?")]
        public virtual bool ExitViaShop { get; set; }
        #endregion
        
        #region REFRESHMENT
        #endregion
        
        #region DONATION
        #endregion
        
        #region EXPERIENCE
        #endregion
    }
}
