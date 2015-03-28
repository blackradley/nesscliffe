var require = patchRequire(require);
var JoinPage = require("./Pages/join_page.js");
var ThanksPage = require("./Pages/thanks_page.js");
var Utilities = require("./Pages/utilities.js");

var joinPage = new JoinPage();
var thanksPage = new ThanksPage();
var utilities = new Utilities();

casper.test.begin('Ensure that a new user can join', {
    setUp: function (test) {
        casper.options.viewportSize = { width: 1024, height: 768 };
    },

    test: function (test) {
        joinPage.startOnJoinPage();
        joinPage.checkPage();
        var seconds = utilities.secondsFromMidnight();
        var emailAddress = "insight" + seconds + "@mailinator.com";
        console.log(emailAddress);
        joinPage.typeForm(emailAddress, "password");
        utilities.snap('JoinNewUser');
        joinPage.submitForm();
        // Email isn't present so you should still be on the ThanksPage
        // utilities.snap('Thanks');
        thanksPage.checkPage();
        casper.run(function () {
            test.done();
        });
    },

    tearDown: function(test) {
        // nothing
    }
});
