function JoinPage() {

    this.startOnJoinPage = function () {
        //casper.echo("base url is : " + casper.cli.options.baseUrl);
        casper.thenOpen(casper.cli.options.baseUrl + '/SendMail/RequestInvite');
    };

    // Send Pete an email
    this.join = function (emailAddress) {
        this.startOnJoinPage();
        this.checkPage();
        this.fillForm(emailAddress);
        this.submitForm();
    };

    // Are you on the right page?
    this.checkPage = function () {
        casper.waitForSelector("#Email", function () {
            casper.test.assertUrlMatch('/SendMail/RequestInvite', 'On the send mail page.');
            casper.test.assertExists('form', 'A form has been found on the page.');
        });
    };

    // Fill in the email box
    this.fillForm = function(emailAddress) {
        casper.waitForSelector("#Email", function() {
            casper.fillSelectors('form', {
                "input#Email": emailAddress,
            }, false);
        });
    };

    // Click on the submit button
    this.submitForm = function () {
        casper.then(function () {
            casper.click('form input[type="submit"]', 'Login submit button clicked.');
        });
    };

    // Check that it is an email address.
    this.checkUsernameValidation = function () {
        casper.waitForSelector("#Email", function () {
            casper.test.assertTextExists("Invalid Email Address", "Must use a valid email.");
        });
    }
}