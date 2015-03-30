
function MonthPage() {
    this.casper = casper;

    this.checkPage = function () {
        casper.then(function () {
            casper.waitForUrl(/Months\/Edit\/[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}/, function () {
                this.test.assertTitleMatch(/[a-zA-Z]{3,}\s[0-9]{4}\s-\sInsight/, 'Single month page has the correct title');
            });
        });
    };

};

module.exports = MonthPage;