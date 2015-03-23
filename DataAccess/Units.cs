using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace DataAccess
{
    public class Units
    {
        public enum AreaIndoorEnum
        {
            [Display(Name = "Square Metres")]
            SquareMetres = 1,
            [Display(Name = "Square Feet")]
            SquareFeet = 2
        }

        public enum AreaOutdoorEnum
        {
            [Display(Name = "Square Metres")]
            SquareMetres = 1,
            [Display(Name = "Square Feet")]
            SquareFeet = 2,
            Acres = 3,
            Hectares = 4
        }

        public enum DistanceIndoorEnum
        {
            Metres = 1,
            Feet = 2,
            Paces = 3
        }
    }
}