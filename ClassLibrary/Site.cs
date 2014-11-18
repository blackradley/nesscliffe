using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Site
    {
        public virtual Guid Id { get; set; }
        public virtual String Owner { get; set; }
        public virtual String Name { get; set; }
        public virtual String Postcode { get; set; }
        public virtual bool Museum { get; set; }
        public virtual bool Castle { get; set; }
        public virtual bool Gallery { get; set; }
        public virtual bool WorldHeritageSite { get; set; }
        public virtual bool HistoricHouse { get; set; }
        public virtual bool HistoricSite { get; set; }
        public virtual bool OpenAir { get; set; }
        public virtual bool Accreditation { get; set; }
        public virtual int AreaIndoor { get; set; }
        public virtual int AreaOutdoor { get; set; }
        public virtual ICollection<Month> Months { get; set; }
 
    }
}
