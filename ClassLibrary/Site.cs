using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
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
        [Required(ErrorMessage = "Please enter a name.")]
        public virtual String Name { get; set; }

        [Display(Name = "Postcode", Description = "Postcode of the site so we can find it on a map.")]
        [Required(ErrorMessage = "Please enter a postcode.")]
        public virtual String Postcode { get; set; }

        [Display(Name = "Museum", Description = "Does your site include a musuem?")]
        public virtual bool IsMuseum { get; set; }
        [Display(Name = "ACE Accredited Museum", Description = "Do you have Arts Council of England Accreditation?")]
        public virtual bool IsAccredited { get; set; }
        [Display(Name = "Castle", Description = "Is there a castle or fortified house at your site?")]
        public virtual bool IsCastle { get; set; }
        [Display(Name = "Historic House", Description = "Is there a historic house or stately home at your site?")]
        public virtual bool IsHistoricHouse { get; set; }

        [Display(Name = "Arts Centre", Description = "Is your site an Arts Centre?")]
        public virtual bool IsArtsCentre { get; set; }
        [Display(Name = "Gallery", Description = "Is there a gallery at your site?")]
        public virtual bool IsGallery { get; set; }

        [Display(Name = "World Heritage Site", Description = "Is your site in a UNESCO World Heritage Site?")]
        public virtual bool IsWorldHeritageSite { get; set; }
        [Display(Name = "Open Air", Description = "Does your site have open air displays and areas?")]
        public virtual bool IsOpenAir { get; set; }

        [Display(Name = "Heritage Site", Description = "Is your site a heritage site? e.g. a battle field.")]
        public virtual bool IsHeritageSite { get; set; }
        [Display(Name = "National Trust", Description = "Is your site in the National Trust?")]
        public virtual bool IsNationalTrust { get; set; }

        [Display(Name = "Indoor Area", Description = "How big is the indoor area which visitors can visit?  In square feet or square metres.")]
        public virtual float AreaIndoor { get; set; }
        public virtual int AreaIndoorUnits { get; set; }
        public static readonly Dictionary<int, string> AreaIndoorUnitType = new Dictionary<int, string>
        {
            { 1, "Square Metres" },
            { 2, "Square Feet" }
        };

        [Display(Name = "Outdoor Area", Description = "How big is the outdoor area which visitors can visit?  In square feet, square metres, hectares or acres.")]
        public virtual float AreaOutdoor { get; set; }
        public virtual int AreaOutdoorUnits { get; set; }
        public static readonly Dictionary<int, string> AreaOutdoorUnitType = new Dictionary<int, string>
        {
            { 1, "Square Metres" },
            { 2, "Square Feet" },
            { 3, "Acres" },
            { 4, "Hectares" }
        };






    }

}
