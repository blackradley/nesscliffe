phantom.page.injectJs('./Pages/Page.Join.js');
phantom.page.injectJs('./Pages/Page.Mailinator.js');

// Get the seconds from midnight, after a fews hours mailinator mailboxes are deleted
// so the mailboxes will not be there the next day.
var dateTimeNow = new Date();
var secondsFromMidnight = dateTimeNow.getSeconds() + (60 * dateTimeNow.getMinutes()) + (60 * 60 * dateTimeNow.getHours());

var joinPage = new JoinPage();

casper.test.begin('Join and check email', function (test) {

    // Make three mail box names
    var mailBoxes = [];
    for (var i = 1; i <= 3; i++) {
        mailBoxes.push((secondsFromMidnight + i + 'insight'));
    }

    casper.start(casper.cli.options.baseUrl);

    // Send three emails.
    casper.then(function sendEmails() {
        mailBoxes.forEach(function sendAnEmail(mailBox) {
            joinPage.join(mailBox + '@mailinator.com');
        });
    });

    // Wait a bit.
    casper.wait(1500);

    // Then see if the emails arrived.
    var success = 0;
    casper.then(function checkEmailArrival() {
        mailBoxes.forEach(function checkMailBox(mailBox) {
            casper.thenOpen('http://mailinator.com/inbox.jsp?to=' + mailBox, function () {
                var subject = this.fetchText('div .subject');
                if (subject.indexOf("Invitation Request") > -1) success = success + 1;
            });
        });
    });
    casper.then(function mainlySuccessful() {
        casper.test.assert(success >= 2, success + ' out of the 3 emails arrived.');
    });

    casper.run(function () {
        test.done();
    });
});
