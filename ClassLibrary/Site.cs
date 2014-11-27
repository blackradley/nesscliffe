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
        public virtual bool Castle { get; set; }
        public virtual bool Gallery { get; set; }

        [Display(Name = "World Heritage Site")]
        public virtual bool WorldHeritageSite { get; set; }

        [Display(Name = "Historic House")]
        public virtual bool HistoricHouse { get; set; }

        [Display(Name = "Historic Site")]
        public virtual bool HistoricSite { get; set; }

        [Display(Name = "Open Air")]
        public virtual bool OpenAir { get; set; }

        [Display(Name = "Arts Council England Museum Accredited")]
        public virtual bool Accreditation { get; set; }
        public virtual int AreaIndoor { get; set; }
        public virtual int AreaOutdoor { get; set; }
        public virtual ICollection<Month> Months { get; set; }
 
    }
}
