var require = patchRequire(require);
var MonthPage = require("./Pages/month_page.js");
var SignInPage = require("./Pages/sign_in_page.js");
var SitesPage = require("./Pages/sites_page.js");
var NotFoundPage = require("./Pages/not_found_page.js");
var Utilities = require("./Pages/utilities.js");

var monthPage = new MonthPage();
var signInPage = new SignInPage();
var sitesPage = new SitesPage();
var notFoundPage = new NotFoundPage();
var utilities = new Utilities();

// Sign in using the test user and add 4 months worth of data
casper.test.begin('Access month not present unauthenticated and authenticated', {
    setUp: function (test) {
        casper.options.viewportSize = { width: 1024, height: 768 };
    },

    test: function (test) {
        monthPage.startOnMonthPage('397ad3b3-ecb3-4d79-befb-9d62c541de88');
        // Not authenticated so should end up on login page
        signInPage.checkPage();
        signInPage.typeForm("insightblackradley@mailinator.com", "password");
        signInPage.submitForm();
        // Should be on my sites page
        sitesPage.checkPage();
        monthPage.goToMonth('397ad3b3-ecb3-4d79-befb-9d62c541de88');
        // Should be on not found page
        utilities.snap('A');
        notFoundPage.checkPage();

        casper.run(function () {
            test.done();
        });
    },

    tearDown: function (test) {
        // nothing
    }
});
