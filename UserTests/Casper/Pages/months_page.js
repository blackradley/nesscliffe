
function MonthsPage() {
    this.casper = casper;

    this.checkPage = function () {
        casper.then(function () {
            casper.waitForUrl(/Months\/Index\/[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}/, function () {
                casper.test.assertTitle('Months - Insight', 'Months page has the correct title');
            });
        });
    };

    // The first month is either created with a button or edited with a link, hence the long CSS selector
    this.clickCreateFirstMonth = function () {
        casper.then(function () {
            this.click('tr:nth-of-type(2) td:last-child button, tr:nth-of-type(2) td:last-child a', 'Click on create or edit month link');
        });
    };
};

module.exports = MonthsPage;