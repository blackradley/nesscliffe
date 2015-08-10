using System;
using System.Collections.Generic;

namespace DataAccess.Predictions
{
    class VisitorsTotal
    {
        /* 
         * lm(formula = log(VisitorsTotal) ~ Month + IsMuseum + IsCastle + 
         *      IsWorldHeritageSite + AreaIndoorMetres + IsWebsitePresent + 
         *      IsRefreshment, data = df.temp, na.action = na.omit)
         *      
         * (Intercept)           6.106e+00  4.078e-01  14.972  < 2e-16 ***
         * Month2                3.346e-01  2.917e-01   1.147  0.25239    
         * Month3                4.614e-01  2.948e-01   1.565  0.11878    
         * Month4                5.820e-01  2.882e-01   2.019  0.04452 *  
         * Month5                6.495e-01  2.882e-01   2.253  0.02509 *  
         * Month6                4.149e-01  2.882e-01   1.439  0.15128    
         * Month7                5.629e-01  2.882e-01   1.953  0.05193 .  
         * Month8                8.963e-01  2.882e-01   3.110  0.00209 ** 
         * Month9                4.963e-01  2.882e-01   1.722  0.08633 .  
         * Month10               7.036e-01  2.882e-01   2.441  0.01533 *  
         * Month11               3.365e-01  2.913e-01   1.155  0.24907    
         * Month12              -3.367e-02  2.913e-01  -0.116  0.90808    
         * IsMuseum1             1.217e+00  1.496e-01   8.133 1.92e-14 ***
         * IsCastle1             1.871e+00  4.594e-01   4.072 6.24e-05 ***
         * IsWorldHeritageSite1  9.016e-01  1.964e-01   4.590 6.99e-06 ***
         * AreaIndoorMetres      1.665e-04  2.556e-05   6.514 3.95e-10 ***
         * IsWebsitePresentTRUE -9.351e-01  3.199e-01  -2.923  0.00378 ** 
         * IsRefreshment1        9.860e-01  1.316e-01   7.492 1.14e-12 ***
         * 
         * Residual standard error: 0.9661 on 252 degrees of freedom
         * (360 observations deleted due to missingness)
         * Multiple R-squared:  0.6974,	Adjusted R-squared:  0.677 
         * F-statistic: 34.16 on 17 and 252 DF,  p-value: < 2.2e-16
         */
        private const double Intercept = 6.106e+00;
        private static readonly Dictionary<int, double> MonthCoeff = new Dictionary<int, double>
        {
           { 1, 0 },
           { 2, 3.346e-01 }, 
           { 3, 4.614e-01 },   
           { 4, 5.820e-01 }, 
           { 5, 6.495e-01 },
           { 6, 4.149e-01 },
           { 7, 5.629e-01 },
           { 8, 8.963e-01 },
           { 9, 4.963e-01 },
           { 10, 7.036e-01 },  
           { 11, 3.365e-01 },
           { 12, -3.367e-02 }
        };
        private const double IsMuseumCoeff = 1.217e+00;
        private const double IsCastleCoeff = 1.871e+00;
        private const double IsWorldHeritageSiteCoeff = 9.016e-01;
        private const double AreaIndoorMetresCoeff = 1.665e-04;
        private const double IsWebsitePresentCoeff = -9.351e-01;
        private const double IsRefreshmentCoeff = 9.860e-01;
        private const double ResidualStandardError = 0.9661;


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
                // Estimate the t value for a 95% prediction interval as 2
                const int tValue = 2;
                const double marginOfError = standardErrorOfPrediction * tValue;
                return Math.Exp(PredictionEquation + marginOfError);
            }
        }

        private double PredictionEquation
        {
            get
            {
                const double marginOfError = (ResidualStandardError * 1.1) * 2;
                var month = MonthCoeff[MonthNumber];
                var isMuseum = IsMuseum * IsMuseumCoeff;
                var isCastle = IsCastle * IsCastleCoeff;
                var isWorldHeritageSite = IsWorldHeritageSite * IsWorldHeritageSiteCoeff;
                var areaIndoorMetres = AreaIndoorSquareMetres * AreaIndoorMetresCoeff;
                var isWebsitePresent = IsWebsitePresent * IsWebsitePresentCoeff;
                var isRefreshment = IsRefreshment * IsRefreshmentCoeff;
                return Intercept + month + isMuseum + isCastle + isWorldHeritageSite +
                    areaIndoorMetres + isWebsitePresent + isRefreshment + marginOfError;
            }
        }

        // Properties. 
        public int MonthNumber { get; set; }
        public int IsMuseum { get; set; }
        public int IsCastle { get; set; }
        public int IsWorldHeritageSite { get; set; }
        public double AreaIndoorSquareMetres { get; set; }
        public int IsWebsitePresent { get; set; }
        public int IsRefreshment{ get; set; }
    }
}
