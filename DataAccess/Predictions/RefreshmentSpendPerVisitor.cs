using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Predictions
{
    class RefreshmentSpendPerVisitor
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
    }
}
