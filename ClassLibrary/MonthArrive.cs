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
    public class MonthArrive
    {
        [Key, ForeignKey("Month")]
        public virtual Guid Id { get; set; }
        // Navigation property back to the month
        public virtual Month Month { get; set; }

        #region ARRIVAL
        [Display(Name = "Monday", Description = "How many hours were you open on Monday?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursMonday { get; set; }
        [Display(Name = "Tuesday", Description = "How many hours were you open on Tuesday?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursTuesday { get; set; }
        [Display(Name = "Wednesday", Description = "How many hours were you open on Wednesday?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursWednesday { get; set; }
        [Display(Name = "Thursday", Description = "How many hours were you open on Thursday?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursThursday { get; set; }
        [Display(Name = "Friday", Description = "How many hours were you open on Friday?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursFriday { get; set; }
        [Display(Name = "Saturday", Description = "How many hours were you open on Saturday?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursSaturday { get; set; }
        [Display(Name = "Sunday", Description = "How many hours were you open on Sunday?")]
        [Range(minimum: 0, maximum: 24, ErrorMessage = "Enter between 0 and 24 hours")]
        public virtual float HoursSunday { get; set; }

        public virtual int Visitors { get; set; }
        public virtual float IncomeAdmissions { get; set; }
        public virtual float IncomeAdditional { get; set; }
        public virtual int VisitorsAdditional { get; set; }
        #endregion
    }

    
}
