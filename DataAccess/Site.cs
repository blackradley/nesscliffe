using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataAccess
{
    // TO DO: rework to match Dino Esposito's approach
    // http://devproconnections.com/entity-framework/domain-modeling-and-persistence-entity-framework-6

    public class Site
    {
        [Key]
        public virtual Guid Id { get; set; }
        // Navigation property
        public virtual ICollection<Month> Months { get; set; }

        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Site Name", Description = "The name of the site so you can identify it while you work.")] 
        [Required(ErrorMessage = "*")]
        public virtual String Name { get; set; }

        [Display(Name = "Postcode", Description = "Postcode of the site so we can find it on a map.")]
        [Required(ErrorMessage = "*")]
        public virtual String Postcode { get; set; }

        [Display(Name = "Museum", Description = "Does your site include a museum?")]
        public virtual bool IsMuseum { get; set; }
        [Display(Name = "ACE Accredited Museum", Description = "Do you have Arts Council of England Accreditation?")]
        public virtual bool IsAccredited { get; set; }
        [Display(Name = "Castle", Description = "Is there a castle or fortified house at your site?")]
        public virtual bool IsCastle { get; set; }
        [Display(Name = "Historic House", Description = "Is there a historic house or stately home at your site?")]
        public virtual bool IsHistoricHouse { get; set; }

        [Display(Name = "Arts Centre", Description = "Is your site an Arts Centre?")]
        public virtual bool IsArtsCentre { get; set; }
        [Display(Name = "Gallery", Description = "Is there an art gallery at your site?")]
        public virtual bool IsGallery { get; set; }

        [Display(Name = "World Heritage Site", Description = "Is your site in a UNESCO World Heritage Site?")]
        public virtual bool IsWorldHeritageSite { get; set; }
        [Display(Name = "Open Air", Description = "Does your site have open air displays and areas?")]
        public virtual bool IsOpenAir { get; set; }

        [Display(Name = "Heritage Site", Description = "Is your site a historical site, building or place important to the area's heritage.")]
        public virtual bool IsHeritageSite { get; set; }
        [Display(Name = "National Trust", Description = "Is your site part of the National Trust?")]
        public virtual bool IsNationalTrust { get; set; }
        [Display(Name = "Country Park", Description = "Is your site a country park or estate?")]
        public virtual bool IsPark { get; set; }
        [Display(Name = "Nature Reserve", Description = "Is your site a Nature Reserve?")]
        public virtual bool IsNatureReserve { get; set; }

        [Display(Name = "Indoor Area", Description = "How big is the indoor area which visitors can visit?  In square feet or square metres.")]
        [Range(0, 99999, ErrorMessage = "Area must be between 0 and 99999.")]
        public virtual int? AreaIndoor { get; set; }
        public virtual int AreaIndoorUnits { get; set; }
        public double AreaIndoorSquareMetres
        {
            get
            {
                double areaIndoorSquareMetres = AreaIndoor ?? 0;  // 0 if null.
                const int feet = (int)Units.AreaIndoorEnum.SquareFeet;
                if (this.AreaIndoorUnits == feet) areaIndoorSquareMetres = areaIndoorSquareMetres * 0.09290304;
                return areaIndoorSquareMetres;
            }
        }

        [Display(Name = "Outdoor Area", Description = "How big is the outdoor area which visitors can visit?  In square feet, square metres, hectares or acres.")]
        [Range(0, 99999, ErrorMessage = "Area must be between 0 and 99999.")]
        public virtual float? AreaOutdoor { get; set; }
        public virtual int AreaOutdoorUnits { get; set; }
    }

}
