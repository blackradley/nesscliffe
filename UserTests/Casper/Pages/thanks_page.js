
function ThanksPage() {
    this.casper = casper;


    this.checkPage = function () {
        casper.then(function () {
            casper.test.assertUrlMatch('Account/Thanks', 'Is on join page');
            casper.test.assertTitle('Welcome to Insight - Insight', 'Thanks page has the correct title');
        });
    };

    this.clickMySites = function () {
        casper.then(function () {
            this.click('#link-my-sites', 'My sites link clicked');
        });
    };

};

module.exports = ThanksPage;