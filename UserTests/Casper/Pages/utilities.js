//var require = patchRequire(require);
//var x = require('casper').selectXPath;

function Utilities() {
    this.casper = casper;
    this.snap = function(fileName) {
        casper.then(function() {
            this.capture(fileName + '.png');
        });
    };

    this.secondsFromMidnight = function() {
        var dateTimeNow = new Date();
        var secondsFromMidnight = dateTimeNow.getSeconds() + (60 * dateTimeNow.getMinutes()) + (60 * 60 * dateTimeNow.getHours());
        return secondsFromMidnight;
    };
};

module.exports = Utilities;
