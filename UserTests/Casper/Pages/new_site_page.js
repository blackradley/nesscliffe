
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
                    this.sendKeys('#Name', name);
                    this.sendKeys('#Postcode', postcode);
                    this.sendKeys('#AreaIndoor', 78);
                    this.sendKeys('#AreaOutdoor', 700);
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