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
        public virtual DateTime MonthTime { get; set; }
        public virtual int MarketingSpend { get; set; }
        public virtual bool RegionalTv { get; set; }
        public virtual bool NationalTv { get; set; }
        public virtual bool OverseasTv { get; set; }
        public virtual String WebsiteUrl { get; set; }
        public virtual int WebsiteVisitors { get; set; }
        public virtual String FacebookUrl { get; set; }
        public virtual String TwitterUrl { get; set; }
        public virtual String FlickrUrl { get; set; }
        public virtual String InstagramUrl { get; set; }
        public virtual String YoutubeUrl { get; set; }
        public virtual String VimeoUrl { get; set; }
        public virtual String PinterestUrl { get; set; }

        public virtual int HoursMonday { get; set; }
        public virtual int HoursTuesday { get; set; }
        public virtual int HoursWednesday { get; set; }
        public virtual int HoursThursday { get; set; }
        public virtual int HoursFriday { get; set; }
        public virtual int HoursSaturday { get; set; }
        public virtual int HoursSunday { get; set; }

        public virtual int Visitors { get; set; }
        public virtual int IncomeAdmissions { get; set; }
        public virtual int IncomeAdditional { get; set; }
        public virtual int VisitorsAdditional { get; set; }

    }
}
