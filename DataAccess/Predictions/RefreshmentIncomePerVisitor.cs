using System;

namespace DataAccess.Predictions
{
    internal class RefreshmentIncomePerVisitor : IPrediction
    {
        /*
         * lm(formula = log(IncomeRefreshmentPerVisitor) ~ IsPark + IsHistoricHouse + 
         *     IsWorldHeritageSite + GoogleRating + AuthorityDensity + IncomeRetailPerVisitor + 
         *     IsVending + IsTableService + IsTeaAndCoffee + IsCakeAndBiscuit + 
         *     IsFullMeal + IsVegetarian + IsAlcohol, data = df.temp)
         *     
         * (Intercept)            -2.177394   0.201104 -10.827  < 2e-16 ***
         * IsPark1                 2.559747   0.402141   6.365 1.25e-09 ***
         * IsHistoricHouse1       -0.965542   0.171536  -5.629 5.92e-08 ***
         * IsWorldHeritageSite1   -2.588189   0.210210 -12.312  < 2e-16 ***
         * GoogleRating            0.145827   0.035562   4.101 5.94e-05 ***
         * AuthorityDensity        0.031766   0.004782   6.643 2.71e-10 ***
         * IncomeRetailPerVisitor  0.101346   0.009474  10.698  < 2e-16 ***
         * IsVending              -0.881318   0.170461  -5.170 5.54e-07 ***
         * IsTableService         -1.105066   0.218995  -5.046 9.92e-07 ***
         * IsTeaAndCoffee          1.498023   0.373481   4.011 8.47e-05 ***
         * IsCakeAndBiscuit       -1.189001   0.354924  -3.350 0.000962 ***
         * IsFullMeal              1.011851   0.165907   6.099 5.24e-09 ***
         * IsVegetarian            1.219496   0.225573   5.406 1.78e-07 ***
         * IsAlcohol              -0.654251   0.146422  -4.468 1.30e-05 ***
         * 
         * Residual standard error: 0.696 on 205 degrees of freedom
         * Multiple R-squared:  0.8146,	Adjusted R-squared:  0.8028 
         * F-statistic: 69.28 on 13 and 205 DF,  p-value: < 2.2e-16
         */

        private const double Intercept = -2.177394;
        private const double IsParkCoeff = 2.559747;
        private const double IsHistoricHouseCoeff = -0.965542;
        private const double IsWorldHeritageSiteCoeff = -2.588189;
        private const double GoogleRatingCoeff = 0.145827;
        private const double AuthorityDensityCoeff = 0.031766;
        private const double IncomeRetailPerVisitorCoeff = 0.101346;
        private const double IsVendingCoeff = -0.881318;
        private const double IsTableServiceCoeff = -1.105066;
        private const double IsTeaAndCoffeeCoeff = 1.498023;
        private const double IsCakeAndBiscuitCoeff = -1.189001;
        private const double IsFullMealCoeff = 1.011851;
        private const double IsVegetarianCoeff = 1.219496;
        private const double IsAlcoholCoeff = -0.654251;
        private const double ResidualStandardError = 0.696;



        public double Predicted
        {
            get { return Math.Exp(PredictionEquation); }
        }

        public double PredictedUpper
        {
            get
            { // Estimate the standard error of prediction by inflating it by 10%
                const double standardErrorOfPrediction = ResidualStandardError * 1.1;
                // t value for a 95% prediction interval with 205 degrees of freedom
                const double tValue = 1.97160351;
                const double marginOfError = standardErrorOfPrediction * tValue;
                return Math.Exp(PredictionEquation + marginOfError);
            }
        }

        private double PredictionEquation
        {
            get
            {
                var isPark = IsPark * IsParkCoeff;
                var isHistoricHouse = IsHistoricHouse * IsHistoricHouseCoeff;
                var isWorldHeritageSite = IsWorldHeritageSite * IsWorldHeritageSiteCoeff;
                var googleRating = GoogleRating * GoogleRatingCoeff;
                var authorityDensity = AuthorityDensity * AuthorityDensityCoeff;
                var incomeRetailPerVisitor = (IncomeRetail / VisitorsTotal) * IncomeRetailPerVisitorCoeff;
                var isVending = IsVending * IsVendingCoeff;
                var isTableService = IsTableService * IsTableServiceCoeff;
                var isTeaAndCoffee = IsTeaAndCoffee * IsTeaAndCoffeeCoeff;
                var isCakeAndBiscuit = IsCakeAndBiscuit * IsCakeAndBiscuitCoeff;
                var isFullMeal = IsFullMeal * IsFullMealCoeff;
                var isVegetarian = IsVegetarian * IsVegetarianCoeff;
                var isAlcohol = IsAlcohol * IsAlcoholCoeff;
                return Intercept + isPark + isHistoricHouse + isWorldHeritageSite + googleRating +
                    authorityDensity + incomeRetailPerVisitor + isVending + isTableService +
                    isTeaAndCoffee + isCakeAndBiscuit + isFullMeal + isVegetarian + isAlcohol;
            }
        }

        public int IsPark { get; set; }
        public int IsHistoricHouse { get; set; }
        public int IsWorldHeritageSite { get; set; }
        public double GoogleRating { get; set; }
        public double AuthorityDensity { get; set; }
        public double IncomeRetail { get; set; }
        public double VisitorsTotal { get; set; }
        public int IsVending { get; set; }
        public int IsTableService { get; set; }
        public int IsTeaAndCoffee { get; set; }
        public int IsCakeAndBiscuit { get; set; }
        public int IsFullMeal { get; set; }
        public int IsVegetarian { get; set; }
        public int IsAlcohol { get; set; }
    }
}
