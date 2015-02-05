using System.Collections.Generic;

namespace DataAccess
{
    public class Units
    {
        public static readonly Dictionary<int, string> AreaIndoor = new Dictionary<int, string>
        {
            { 1, "Square Metres" },
            { 2, "Square Feet" }
        };

        public static readonly Dictionary<int, string> AreaOutdoor = new Dictionary<int, string>
        {
            { 1, "Square Metres" },
            { 2, "Square Feet" },
            { 3, "Acres" },
            { 4, "Hectares" }
        };

        public static readonly Dictionary<int, string> DistanceIndoor = new Dictionary<int, string>
        {
            { 1, "Metres" },
            { 2, "Feet" },
            { 3, "Paces"}
        };
    }
}