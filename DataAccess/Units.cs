using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataAccess
{
    public static class Units
    {
        public static readonly Dictionary<int, string> AreaIndoor = Enum.GetValues(typeof(AreaIndoorEnum))
               .Cast<AreaIndoorEnum>()
               .ToDictionary(t => (int)t, t => t.DisplayName());
        public enum AreaIndoorEnum 
        {
            [Display(Name = "Square Metres")]
            SquareMetres = 1,
            [Display(Name = "Square Feet")]
            SquareFeet = 2
        }

        public static readonly Dictionary<int, string> AreaOutdoor = Enum.GetValues(typeof(AreaOutdoorEnum))
           .Cast<AreaOutdoorEnum>()
           .ToDictionary(t => (int)t, t => t.DisplayName());
        public enum AreaOutdoorEnum
        {
            [Display(Name = "Square Metres")]
            SquareMetres = 1,
            [Display(Name = "Square Feet")]
            SquareFeet = 2,
            [Display(Name = "Acres")]
            Acres = 3,
            [Display(Name = "Hectares")]
            Hectares = 4
        };

        public static readonly Dictionary<int, string> DistanceIndoor = Enum.GetValues(typeof(DistanceIndoorEnum))
           .Cast<DistanceIndoorEnum>()
           .ToDictionary(t => (int)t, t => t.DisplayName());
        public enum  DistanceIndoorEnum
        {
            [Display(Name = "Metres")]
            Metres = 1,
            [Display(Name = "Feet")]
            Feet = 2,
            [Display(Name = "Paces")]
            Paces = 3
        };
    }
}