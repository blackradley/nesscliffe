var JoinPage = require("./pages/join_page.js");
var joinPage = new JoinPage(casper);

casper.test.begin('Test join ' + casper.cli.options.baseUrl, {
    setUp: function (test) {
        casper.options.viewportSize = { width: 1024, height: 768 };
    },

    test: function (test) {
        joinPage.startOnJoinPage();
        joinPage.checkPage();
        joinPage.typeForm("insightblackradley@mailinator.com", "pa55worD");
        casper.then(function () { this.capture("join_form.png"); });
        joinPage.submitForm();
        joinPage.checkPage();
        casper.run(function () {
            
            test.done();
        });
    },

    tearDown: function(test) {
        // nothing
    }
});
