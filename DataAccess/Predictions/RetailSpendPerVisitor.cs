using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Predictions
{
    class RetailSpendPerVisitor
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
         * 
         * Residual standard error: 0.8556 on 343 degrees of freedom
         * (110 observations deleted due to missingness)
         * Multiple R-squared:  0.6308,	Adjusted R-squared:  0.6211 
         * F-statistic: 65.11 on 9 and 343 DF,  p-value: < 2.2e-16
         */ 
    }
}
