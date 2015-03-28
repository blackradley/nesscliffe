var require = patchRequire(require);
var SignInPage = require("./Pages/sign_in_page.js");
var SitesPage = require("./Pages/sites_page.js");
var NewSitePage = require("./Pages/new_site_page.js");
var Utilities = require("./Pages/utilities.js");

var signInPage = new SignInPage();
var sitesPage = new SitesPage();
var newSitePage = new NewSitePage();
var utilities = new Utilities();

// Sign in using the test user and add 4 months worth of data
casper.test.begin('Sign in the seeded user and add a site', {
    setUp: function (test) {
        casper.options.viewportSize = { width: 1024, height: 768 };
    },

    test: function (test) {
        signInPage.startOnSignInPage();
        signInPage.checkPage();
        // Sign in with the seeded user
        signInPage.typeForm("insightblackradley@mailinator.com", "password");
        utilities.snap('SignIn');
        signInPage.submitForm();
        // Should be on my sites page
        sitesPage.checkPage(); 
        utilities.snap('MySites');
        sitesPage.clickCreateSite();
        // Should be on the data entry page
        newSitePage.checkPage();
        var siteName = "Insight test " + utilities.secondsFromMidnight();
        utilities.snap('NewSite');
        newSitePage.fillForm(siteName, "SW1A 0AA");
        newSitePage.clickSaveNewSite();
        utilities.snap('NewSiteSaved');

        casper.run(function () {
            test.done();
        });
    },

    tearDown: function (test) {
        // nothing
    }
});
