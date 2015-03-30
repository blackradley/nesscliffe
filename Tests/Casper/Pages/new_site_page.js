
function NewSitePage() {
    this.casper = casper;

    this.checkPage = function () {
        casper.then(function () {
            casper.waitForUrl('Sites/Create', function () {
                casper.test.assertTitle('New Site - Insight', 'New Site page has the correct title');
            });
        });
    };

    // Fill the form if the submit button is present
    this.fillForm = function (name, postcode) {
        casper.then(function () {
            casper.waitForSelector("#submit",
                function pass() {
                    this.sendKeys('#Name', name); // Required field
                    this.sendKeys('#Postcode', postcode); // Required field
                    this.click('#IsMuseum');
                    this.click('#IsGallery');
                    this.click('#IsPark');
                    this.click('#IsHistoricHouse');
                    this.fillSelectors('form#site-create', {
                        '#AreaIndoor': 77,
                        '#AreaIndoorUnits': 1,
                        '#AreaOutdoor': 12,
                        '#AreaOutdoorUnits': 3
                    }, false);
                },
                function fail() {
                    test.fail("Did not load element #Submit");
                }
            );
        });
    };

    this.clickSaveNewSite = function () {
        casper.then(function () {
            casper.click('#submit', 'New Site save button clicked');
        });
    };
};

module.exports = NewSitePage;