
function SitesPage() {
    this.casper = casper;

    this.checkPage = function () {
        casper.then(function () {
            casper.waitForUrl('Sites', function() {
                casper.test.assertTitle('My Sites - Insight', 'Sites page has the correct title');
            });
        });
    };

    this.clickCreateSite = function () {
        casper.then(function () {
            this.click('#link-create-site', 'Create New Site link clicked');
        });
    };

    this.clickMonthsForFirstSite = function clickOnFirst() {
        casper.then(function () {
            this.click('tr:nth-of-type(2) a[name="link-months"]', 'Click on first months link');
        });
    };
};

module.exports = SitesPage;