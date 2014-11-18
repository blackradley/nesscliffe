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
        public virtual String Postcode { get; set; }
        public virtual ICollection<Month> Months { get; set; }
 
    }
}
