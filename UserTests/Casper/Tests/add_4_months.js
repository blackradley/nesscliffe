var require = patchRequire(require);
var SignInPage = require("./Pages/sign_in_page.js");
var Utilities = require("./Pages/utilities.js");

var signInPage = new SignInPage();
var utilities = new Utilities();

// Sign in using the test user and add 4 months worth of data
casper.test.begin('Test sign in ' + casper.cli.options.baseUrl, {
    setUp: function (test) {
        casper.options.viewportSize = { width: 1024, height: 768 };
    },

    test: function (test) {
        signInPage.startOnSignInPage();
        signInPage.checkPage();
        signInPage.typeForm("insightblackradley@mailinator.com", "password");
        utilities.snap('SignIn');
        signInPage.submitForm();

        utilities.snap('Sites1');
        casper.run(function () {
            test.done();
        });
    },

    tearDown: function (test) {
        // nothing
    }
});
