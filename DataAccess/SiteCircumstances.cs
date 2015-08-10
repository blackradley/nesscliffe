using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class SiteCircumstances
    {
        [Key, ForeignKey("Site")]
        public virtual Guid Id { get; set; }
        // Navigation property back to the month
        public virtual Site Site { get; set; }

        public virtual decimal WardApproximatedSocialGradeC2 { get; set; }
        public virtual decimal GoogleRating { get; set; }
        public virtual decimal AuthorityDensity { get; set; }
    }
}
