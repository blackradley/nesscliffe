using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [Table("MonthsAttention")]
    public class MonthAttention : Month
    {
        //[Key, ForeignKey("Month")]
        //public virtual Guid Id { get; set; }
        // Navigation property back to the month
        //public virtual Month Month { get; set; }

        #region ATTENTION
        [Display(Name = "Marketing Spend", Description = "How much have you spent on marketing this month?")]
        [Range(0, 99999, ErrorMessage = "Area must be between 0 and 99999")]
        [Required(ErrorMessage = "Please enter this month's marketing spend")]
        public virtual Nullable<float> MarketingSpend { get; set; }
        [Display(Name = "Regional TV", Description = "Has your site appeared on regional TV?")]
        public virtual bool RegionalTv { get; set; }
        [Display(Name = "National TV", Description = "Has your site appeared on national TV?")]
        public virtual bool NationalTv { get; set; }
        [Display(Name = "Overseas TV", Description = "Has your site appeared on TV in another country?")]
        public virtual bool OverseasTv { get; set; }
        [Display(Name = "Website Url", Description = "Has your web site address?")]
        public virtual String WebsiteUrl { get; set; }
        [Display(Name = "Website Visitors", Description = "How many visitors did your website get?")]
        public virtual Nullable<int> WebsiteVisitors { get; set; }
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

    }

    
}
