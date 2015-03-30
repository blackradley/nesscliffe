
function JoinPage() {
    this.casper = casper;

    this.startOnJoinPage = function () {
        casper.echo("base url is : " + casper.cli.options.baseUrl);
        casper.start(casper.cli.options.baseUrl + 'Account/Register');
    };

    this.checkPage = function () {
        casper.then(function () {
            casper.test.assertUrlMatch('Account/Register', 'Is on join page');
            casper.test.assertExists('form[id="register"]', 'Login page form has been found');
        });
    };

    this.fillForm = function (email, password) {
        casper.then(function () {
            this.fill('form[id="register"]', {
                '#Email': email,
                '#Password': password,
                '#agree': true
            }, false);
        });
    };

    this.typeForm = function (email, password) {
        casper.then(function () {
            this.sendKeys('#Email', email);
            this.sendKeys('#Password', password);
            this.click('#agree');
        });
    };

    this.submitForm = function () {
        casper.then(function () {
            this.click('form[id="register"] #submit', 'Join submit button clicked');
        });
    };

};

module.exports = JoinPage;