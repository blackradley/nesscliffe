using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class SiteCircumstance
    {
        [Key, ForeignKey("Site")]
        public virtual Guid SiteId { get; set; }
        public virtual Site Site { get; set; }

        //// ONS Data
        public virtual Double AuthorityDensity { get; set; }
        public virtual Double WardDensity { get; set; }
        public virtual int WardApproximatedSocialGradeAllCategories { get; set; }
        public virtual int WardApproximatedSocialGradeAb { get; set; }
        public virtual int WardApproximatedSocialGradeC1 { get; set; }
        public virtual int WardApproximatedSocialGradeC2 { get; set; }
        public virtual int WardApproximatedSocialGradeDe { get; set; }

        //// Google Data
        public virtual String GooglePlaceId { get; set; }
        public virtual Double Latitude { get; set; }
        public virtual Double Longitude { get; set; }
        public virtual Double? GoogleRating { get; set; }
    }
}
