using System;

namespace DataAccess.Predictions
{
    internal class RetailIncomePerVisitor : IPrediction
    {
        /*
         * lm(formula = log(IncomeRetailPerVisitor) ~ VisitorsTotal + IsPayToEnter + 
         *     IsArtsCentre + IsMuseum + IsWebsitePresent + PayToShop + 
         *     ShopVisibleFromEntrance + IncomeRefreshmentPerVisitor + IsAdditionalEvents, 
         *     data = df.temp)
         *     
         * (Intercept)                 -6.020e-01  3.329e-01  -1.808 0.071468 .  
         * VisitorsTotal               -3.163e-05  8.617e-06  -3.671 0.000281 ***
         * IsPayToEnterTRUE             5.571e-01  1.092e-01   5.100 5.63e-07 ***
         * IsArtsCentre1                1.566e+00  3.044e-01   5.143 4.56e-07 ***
         * IsMuseum1                    7.083e-01  1.185e-01   5.977 5.70e-09 ***
         * IsWebsitePresentTRUE        -8.911e-01  2.545e-01  -3.502 0.000523 ***
         * PayToShop                    2.599e+00  3.105e-01   8.370 1.48e-15 ***
         * ShopVisibleFromEntrance     -8.132e-01  1.393e-01  -5.837 1.24e-08 ***
         * IncomeRefreshmentPerVisitor  9.686e-02  6.741e-03  14.369  < 2e-16 ***
         * IsAdditionalEvents1          9.262e-01  1.403e-01   6.604 1.53e-10 ***
         * Residual standard error: 0.8556 on 343 degrees of freedom
         * (110 observations deleted due to missingness)
         * Multiple R-squared:  0.6308,	Adjusted R-squared:  0.6211 
         * F-statistic: 65.11 on 9 and 343 DF,  p-value: < 2.2e-16
         */

        private const double Intercept = -6.020e-01;
        private const double VisitorsTotalCoeff = -3.163e-05;
        private const double IsPayToEnterCoeff = 5.571e-01;
        private const double IsArtsCentreCoeff = 1.566e+00;
        private const double IsMuseumCoeff = 7.083e-01;
        private const double IsWebsitePresentCoeff = -8.911e-01;
        private const double PayToShopCoeff = 2.599e+00;
        private const double ShopVisibleFromEntranceCoeff = -8.132e-01;
        private const double IncomeRefreshmentPerVisitorCoeff = 9.686e-02;
        private const double IsAdditionalEventsCoeff = 9.262e-01;
        private const double ResidualStandardError = 0.8556;

        public double Predicted
        {
            get { return Math.Exp(PredictionEquation); }
        }

        public double PredictedUpper
        {
            get
            { // Estimate the standard error of prediction by inflating it by 10%
                const double standardErrorOfPrediction = ResidualStandardError * 1.1;
                // t value for a 95% prediction interval with 343 degrees of freedom
                const double tValue = 1.96690426;
                const double marginOfError = standardErrorOfPrediction * tValue;
                return Math.Exp(PredictionEquation + marginOfError);
            }
        }

        private double PredictionEquation
        {
            get
            {
                var visitorsTotal = VisitorsTotal * VisitorsTotalCoeff;
                var isPayToEnter = IsPayToEnter * IsPayToEnterCoeff;
                var isArtsCentre = IsArtsCentre * IsArtsCentreCoeff;
                var isMuseum = IsMuseum * IsMuseumCoeff;
                var isWebsitePresent = IsWebsitePresent * IsWebsitePresentCoeff;
                var payToShop = PayToShop * PayToShopCoeff;
                var shopVisibleFromEntrane = ShopVisibleFromEntrance * ShopVisibleFromEntranceCoeff;
                var incomeRefreshmentPerVisitor = (IncomeRefreshment / VisitorsTotal) * IncomeRefreshmentPerVisitorCoeff;
                // In case either IncomeRefreshment or VisitorsTotal are zero (= infinity)
                incomeRefreshmentPerVisitor = Double.IsInfinity(incomeRefreshmentPerVisitor) ? 0.0 : incomeRefreshmentPerVisitor;
                // In case both IncomeRefreshment and VisitorsTotal are zero (= NAN)
                incomeRefreshmentPerVisitor = Double.IsNaN(incomeRefreshmentPerVisitor) ? 0.0 : incomeRefreshmentPerVisitor;
                var isAdditionalEvents = IsAdditionalEvents * IsAdditionalEventsCoeff;
                return Intercept + visitorsTotal + isPayToEnter + isArtsCentre + isMuseum +
                       isWebsitePresent + payToShop + shopVisibleFromEntrane + incomeRefreshmentPerVisitor +
                       isAdditionalEvents;
            }
        }

        // Default values for an 'typical' site
        public RetailIncomePerVisitor()
        {
            this.VisitorsTotal = 7632; // mean(df$VisitorsTotal)
            this.IsPayToEnter = 0;
            this.IsArtsCentre = 0;
            this.IsMuseum = 1;
            this.IsWebsitePresent = 1;
            this.PayToShop = 0;
            this.ShopVisibleFromEntrance = 1;
            this.IncomeRefreshment = 6993; // mean(df$IncomeRefreshment)
            this.IsAdditionalEvents = 0;
        }

        // Properties
        public double VisitorsTotal { get; set; }
        public int IsPayToEnter { get; set; }
        public int IsArtsCentre { get; set; }
        public int IsMuseum { get; set; }
        public int IsWebsitePresent { get; set; }
        public int PayToShop { get; set; }
        public int ShopVisibleFromEntrance { get; set; }
        public double IncomeRefreshment { get; set; }
        public int IsAdditionalEvents { get; set; }
    }
}
