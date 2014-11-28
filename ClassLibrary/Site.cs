using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public class Site
    {

        public virtual Guid Id { get; set; }
        public virtual Guid UserId { get; set; }

        [Display(Name = "Site Name")]
        [Required(ErrorMessage = "Name is required")]
        public virtual String Name { get; set; }
        [Display(Name = "Postcode")]
        [Required(ErrorMessage = "Postcode is required")]
        public virtual String Postcode { get; set; }

        public virtual bool Museum { get; set; }
        [Display(Name = "ACE Accredited Museum")]
        public virtual bool Accreditation { get; set; }
        public virtual bool Castle { get; set; }
        [Display(Name = "Historic House")]
        public virtual bool HistoricHouse { get; set; }

        [Display(Name = "Arts Centre")]
        public virtual bool ArtsCentre { get; set; }
        public virtual bool Gallery { get; set; }
        [Display(Name = "Indoor Area")]
        public virtual int AreaIndoor { get; set; }
        public virtual int AreaIndoorUnits { get; set; }
        public static readonly Dictionary<int, string> AreaIndoorUnitType = new Dictionary<int, string>
        {
            { 1, "Square Feet" },
            { 2, "Square Metres" }
        };

        [Display(Name = "World Heritage Site")]
        public virtual bool WorldHeritageSite { get; set; }
        [Display(Name = "Open Air")]
        public virtual bool OpenAir { get; set; }
        public virtual int AreaOutdoor { get; set; }
        public virtual int AreaOutdoorUnits { get; set; }
        public static readonly Dictionary<int, string> AreaOutdoorUnitType = new Dictionary<int, string>
        {
            { 1, "Hectares" },
            { 2, "Acres" }
        };

        [Display(Name = "Heritage Site")]
        public virtual bool HeritageSite { get; set; }
        [Display(Name = "National Trust")]
        public virtual bool NationalTrust { get; set; }

        public virtual ICollection<Month> Months { get; set; }


    }
 
}
