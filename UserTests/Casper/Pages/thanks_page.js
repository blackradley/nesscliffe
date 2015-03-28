
function ThanksPage() {
    this.casper = casper;

    this.checkPage = function () {
        casper.then(function () {
            casper.waitForUrl('Account/Thanks', function () {
                casper.test.assertTitle('Welcome to Insight - Insight', 'Thanks page has the correct title');
            });
        });
    };

    this.clickMySites = function () {
        casper.then(function () {
            this.click('#link-my-sites', 'My sites link clicked');
        });
    };
};

module.exports = ThanksPage;