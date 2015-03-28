
function SignInPage() {
    this.casper = casper;

    this.startOnSignInPage = function () {
        casper.echo("base url is : " + casper.cli.options.baseUrl);
        casper.start(casper.cli.options.baseUrl + 'Account/Login');
    };

    this.checkPage = function () {
        casper.then(function () {
            casper.waitForUrl('Account/Login', function() {
                casper.test.assertExists('form[id="sign-in"]', 'Sign in page form has been found');
            });
        });
    };

    this.fillForm = function (email, password) {
        casper.then(function () {
            this.fill('form[id="sign-in"]', {
                '#Email': email,
                '#Password': password
            }, false);

        });
    };

    this.typeForm = function (email, password) {
        casper.then(function () {
            this.sendKeys('#Email', email);
            this.sendKeys('#Password', password);
        });
    };

    this.submitForm = function () {
        casper.then(function () {
            this.click('form[id="sign-in"] #submit', 'Sign in submit button clicked');
        });
    };

};

module.exports = SignInPage;