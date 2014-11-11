function MailinatorPage() {

    // Are you on the right page?
    this.checkSubject = function (mailBox, emailSubject) {
        casper.thenOpen('http://mailinator.com/inbox.jsp?to=' + mailinatorMailBox, function () {
            casper.echo(this.getTitle());
            casper.capture("crafty.jpg");
        });
    }
}