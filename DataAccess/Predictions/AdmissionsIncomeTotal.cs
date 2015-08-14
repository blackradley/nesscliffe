using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Predictions
{
    class AdmissionsIncomeTotal
    {
        /*
         * lm(formula = log(IncomeAdmissions) ~ VisitorsTotal + AreaIndoorMetres + 
         *     WardDensity + WardApproximatedSocialGradeC2 + MarketingEffort + 
         *     IsRefreshment, data = df.temp, na.action = na.omit)
         *     
         * (Intercept)                   2.171e+00  4.185e-01   5.188 1.68e-06 ***
         * VisitorsTotal                 7.821e-05  9.667e-06   8.090 6.83e-12 ***
         * AreaIndoorMetres              4.716e-04  5.663e-05   8.329 2.37e-12 ***
         * WardDensity                   6.290e-02  5.452e-03  11.538  < 2e-16 ***
         * WardApproximatedSocialGradeC2 1.524e+01  1.838e+00   8.287 2.84e-12 ***
         * MarketingEffort               2.800e-03  6.644e-04   4.214 6.76e-05 ***
         * IsRefreshment1                6.791e-01  1.699e-01   3.998 0.000145 ***
         * 
         * Residual standard error: 0.4234 on 77 degrees of freedom
         * (57 observations deleted due to missingness)
         * Multiple R-squared:  0.9252,	Adjusted R-squared:  0.9193 
         * F-statistic: 158.7 on 6 and 77 DF,  p-value: < 2.2e-16
         */
        private const double Intercept = 2.171e+00;
        private const double VisitorsTotalCoeff = 7.821e-05;
        private const double AreaIndoorMetresCoeff = 4.716e-04;
        private const double WardDensityCoeff = 6.290e-02;
        private const double WardApproximatedSocialGradeC2Coeff = 1.524e+01;
        private const double MarketingEffortCoeff = 2.800e-03;
        private const double IsRefreshmentCoeff = 6.791e-01;
        private const double ResidualStandardError = 0.4234;

        public double Predicted
        {
            get
            {
                return Math.Exp(PredictionEquation);
            }
        }

        public double PredictedUpper
        {
            get
            {
                // Estimate the standard error of prediction by inflating it by 10%
                const double standardErrorOfPrediction = ResidualStandardError * 1.1;
                // t value for a 95% prediction interval with 77 degrees of freedom
                const double tValue = 1.99125441;
                const double marginOfError = standardErrorOfPrediction * tValue;
                return Math.Exp(PredictionEquation + marginOfError);
            }
        }

        private double PredictionEquation
        {
            get
            {
                var visitorsTotal = VisitorsTotal * VisitorsTotalCoeff;
                var areaIndoorMetres = AreaIndoorSquareMetres * AreaIndoorMetresCoeff;
                var wardDensity = WardDensity * WardDensityCoeff;
                var wardApproximatedSocialGradeC2 = WardApproximatedSocialGradeC2 * WardApproximatedSocialGradeC2Coeff;
                var marketingEffortCoeff = MarketingEffort * MarketingEffortCoeff;
                var isRefreshment = IsRefreshment * IsRefreshmentCoeff;
                return Intercept + visitorsTotal + wardDensity + wardApproximatedSocialGradeC2 +
                    marketingEffortCoeff + areaIndoorMetres + isRefreshment;
            }
        }


        // Properties
        public int VisitorsTotal  { get; set; }
        public double AreaIndoorSquareMetres { get; set; }
        public double WardDensity { get; set; }
        public double WardApproximatedSocialGradeC2 { get; set; }
        public int MarketingEffort { get; set; }
        public int IsRefreshment { get; set; }
    }
}
