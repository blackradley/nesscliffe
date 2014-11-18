using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Month
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime FirstDay { get; set; }
    }
}
