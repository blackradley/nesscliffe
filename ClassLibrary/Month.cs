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
        // Foreign key
        public virtual Guid SiteId { get; set; }
        // Navigation property back to site
        public virtual Site Site { get; set; }

        [Display(Name = "Month")]
        public virtual DateTime MonthTime { get; set; }

        // Navigation properties to the data 
        [Required]
        public virtual MonthAttention MonthAttention { get; set; }
        //[Required]
        //public virtual MonthArrive MonthArrive { get; set; }
    }
}
