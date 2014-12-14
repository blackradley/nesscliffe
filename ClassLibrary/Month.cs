using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Month
    {
        [Key]
        public virtual Guid Id { get; set; }
        // Foreign key
        public virtual Guid SiteId { get; set; }
        // Navigation property  
        public virtual Site Site { get; set; }

        [Display(Name = "Month")]
        public virtual DateTime MonthTime { get; set; }

        [Display(Name = "Marketing Spend", Description = "How much have you spent on marketing this month?")]
        [Range(0, 99999, ErrorMessage = "Area must be between 0 and 99999.")]
        [Required(ErrorMessage = "Please enter this month's marketing spend")]
        public virtual float MarketingSpend { get; set; }
        [Display(Name = "Regional TV", Description = "Has your site appeared on regional TV?")]
        public virtual bool RegionalTv { get; set; }
        [Display(Name = "National TV", Description = "Has your site appeared on national TV?")]
        public virtual bool NationalTv { get; set; }
        [Display(Name = "Overseas TV", Description = "Has your site appeared on TV in another country?")]
        public virtual bool OverseasTv { get; set; }
        public virtual String WebsiteUrl { get; set; }
        public virtual int WebsiteVisitors { get; set; }
        public virtual String FacebookUrl { get; set; }
        public virtual String TwitterUrl { get; set; }
        public virtual String FlickrUrl { get; set; }
        public virtual String InstagramUrl { get; set; }
        public virtual String YoutubeUrl { get; set; }
        public virtual String VimeoUrl { get; set; }
        public virtual String PinterestUrl { get; set; }

        public virtual int HoursMonday { get; set; }
        public virtual int HoursTuesday { get; set; }
        public virtual int HoursWednesday { get; set; }
        public virtual int HoursThursday { get; set; }
        public virtual int HoursFriday { get; set; }
        public virtual int HoursSaturday { get; set; }
        public virtual int HoursSunday { get; set; }

        public virtual int Visitors { get; set; }
        public virtual int IncomeAdmissions { get; set; }
        public virtual int IncomeAdditional { get; set; }
        public virtual int VisitorsAdditional { get; set; }

    }

    
}
