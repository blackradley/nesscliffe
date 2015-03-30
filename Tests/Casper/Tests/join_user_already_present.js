var require = patchRequire(require);
var JoinPage = require("./Pages/join_page.js");
var Utilities = require("./Pages/utilities.js");

var joinPage = new JoinPage();
var utilities = new Utilities();

casper.test.begin('Ensure that the seeded user cannot join', {
    setUp: function (test) {
        casper.options.viewportSize = { width: 1024, height: 768 };
    },

    test: function (test) {
        joinPage.startOnJoinPage();
        joinPage.checkPage();
        joinPage.typeForm("insightblackradley@mailinator.com", "pa55worD");
        utilities.snap('JoinUserAlreadyPresent');
        joinPage.submitForm();
        // Email is already present so you should still be on the JoinPage
        joinPage.checkPage();
        casper.run(function () {
            test.done();
        });
    },

    tearDown: function(test) {
        // nothing
    }
});
