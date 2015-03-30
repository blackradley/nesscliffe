
function MonthPage() {
    this.casper = casper;

    this.checkPage = function () {
        casper.then(function () {
            casper.waitForUrl(/Months\/Edit\/[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}/, function () {
                this.test.assertTitleMatch(/[a-zA-Z]{3,}\s[0-9]{4}\s-\sInsight/, 'Single month page has the correct title');
            });
        });
    };

    this.fillForm = function (baseNumber) {
        casper.then(function() {
            casper.waitForSelector("#submit",
                function pass() {
                    // It is easier to set the radio buttons with a click than in the fillSelectors
                    this.click('#IsRetail[value="true"]', 'Clicked on is shopping = yes');
                    this.click('#IsRefreshment[value="true"]', 'Clicked on is refreshment = yes');
                    this.click('#IsDonationOpportunity[value="true"]', 'Clicked on is donation = yes');
                    this.click('#IsAdditionalEvents[value="true"]', 'Clicked on is additional events = yes');

                    this.fillSelectors('form#month-edit', {
                        // Attention
                        '#MarketingEffort': baseNumber,
                        '#WebsiteVisitors': baseNumber,
                        '#RegionalNewsPaper': true,
                        '#WebsiteUrl': 'www.blackradley.com',
                        '#TwitterUrl': 'BlackRadley',
                        // Arriving
                        '#VisitorsGeneral': baseNumber * 10,
                        '#VisitorsMember': baseNumber * 9,
                        '#VisitorsSchool': baseNumber * 8,
                        '#IncomeAdmissions': baseNumber * 7,
                        '#VisitorsPercentNoFamily': baseNumber,
                        '#VisitorsPercentFamily': baseNumber,
                        '#VisitorsPercentChildren': baseNumber,
                        '#VisitorsPercentAdult': baseNumber,
                        '#VisitorsPercentRetired': baseNumber,
                        '#HoursMonday': 7,
                        '#HoursTuesday': 7,
                        '#HoursWednesday': 7,
                        '#HoursThursday': 7,
                        '#HoursFriday': 7,
                        '#HoursSaturday': 7,
                        '#HoursSunday': 7,
                        // Shopping
                        '#IncomeRetail': baseNumber * 6,
                        '#PayToShop': true,
                        '#ShopVisibleFromEntrance': false,
                        '#ExitViaShop': false,
                        '#DistanceToShop': baseNumber,
                        '#DistanceToShopUnits': 1,
                        '#AreaShop': baseNumber,
                        '#AreaShopUnits': 1,
                        '#NumberProducts': baseNumber,
                        '#PercentageRelatedProducts': 10,
                        // Refreshment
                        '#IncomeRefreshment': baseNumber * 5,
                        '#PayToRefreshment': true,
                        '#RefreshmentVisibleFromEntrance': true,
                        '#DistanceToRefreshment': baseNumber,
                        '#DistanceToRefreshmentUnits': 1,
                        '#NumberSeatsIndoors': baseNumber,
                        '#NumberSeatsOutside': baseNumber,
                        '#IsVending': false,
                        '#IsCafeteria': true,
                        '#IsTableService': true,
                        '#IsRefreshmentOutsideHours': true,
                        '#IsTeaAndCoffee': true,
                        '#IsCakeAndBiscuit': true,
                        '#IsLightMeals': true,
                        '#IsFullMeal': false,
                        '#IsOrganic ': false,
                        '#IsVegetarian': false,
                        '#IsGlutenFree': false,
                        '#IsAlcohol': false,
                        '#IsCateringInHouse': false,
                        '#IsCateringOutSourced': false,
                        // Donation
                        '#IncomeDonation': baseNumber * 4,
                        '#PayToDonate': false,
                        '#DonationVisibleFromEntrance': false,
                        '#DistanceToDonation': baseNumber,
                        '#DistanceToDonationUnits': 1,
                        '#NumberDonationOpportunities': 5,
                        // Experience
                        '#NumberAdditionalEvents': baseNumber,
                        '#NumberVisitorsAdditional': baseNumber * 3,
                        '#IncomeAdditionalEvents': baseNumber * 2,
                        '#NumberArtefacts': baseNumber * 11,
                        '#ArtefactsDisplay': baseNumber,
                        '#IsCollectionsOutstanding': true
                    }, false);
                },
                function fail() {
                    test.fail("Did not load element #Submit");
                }
            );
        });
    };

    this.clickSaveMonth = function () {
        casper.then(function () {
            casper.click('#submit', 'Month save button clicked');
        });
    };
};

module.exports = MonthPage;