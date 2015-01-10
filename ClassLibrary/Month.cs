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

        [Index(IsUnique = true)] 
        [Display(Name = "Month")]
        [Column(TypeName = "DateTime2")]
        public virtual DateTime MonthTime { get; set; }

        // Navigation properties to the data for each category
        //[Required]
        public virtual MonthAttention MonthAttention { get; set; }
        //[Required]
        public virtual MonthArrive MonthArrive { get; set; }
    }
}
