
function NotFoundPage() {
    this.casper = casper;

    this.checkPage = function () {
        casper.then(function () {
            casper.waitForSelector('h2', function () {
                casper.test.assertSelectorHasText('h2', 'The resource cannot be found.');
            });
        });
    };
};

module.exports = NotFoundPage;