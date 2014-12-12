using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using SeleniumTests.PageObjects;

namespace SeleniumTests.Tests
{
    [TestClass]
    public class Join
    {
        IWebDriver _webDriver;
        private PageObjects.JoinPo _joinPo;

        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void FixtureSetup()
        {
            _webDriver = WebDriverFactory.GetPhantomJsDriver();
            _joinPo = new PageObjects.JoinPo(_webDriver);
        }

        /// <summary>
        /// Get the seconds from midnight, after a fews hours mailinator mailboxes are deleted
        /// so the mailboxes will not be there the next day.
        /// </summary>
        /// <returns></returns>
        private static int SecondsFromMidnight()
        {
            var dateTimeNow = DateTime.Now;
            var dateTimeThen = DateTime.Now.Date; // using Date gets you midnight.
            var timeSpan = dateTimeNow - dateTimeThen;
            var secondsFromMidnight = (int)Math.Round(timeSpan.TotalSeconds);
            return secondsFromMidnight;
        }

        /// <summary>
        /// Send emails to Alice, Bob and Carol etc...
        /// </summary>
        [TestMethod]
        public void Send_emails()
        {
            var names = new string[] { "Alice", "Bob", "Carol", "Dave", "Eve" };
            var mailBoxes = names.Select(n => n + "-" + SecondsFromMidnight()).ToList();
            foreach (var mailBox in mailBoxes)
            {
                var joinPo = new JoinPo(_webDriver);
                var emailAddress = mailBox + @"@mailinator.com";
                Trace.WriteLine(emailAddress);
                joinPo.Join(emailAddress);
                _webDriver.ScreenShot();
                Assert.IsTrue(_joinPo.PageSource.Contains("Request Thanks"));
            }
        }

        /// <summary>
        /// Confirm that the response screen shows after email is sent.
        /// </summary>
        [TestMethod]
        public void Join_screen_shows_thanks()
        {
            _joinPo.TypeEmailAddress("drbollins@hotmail.com");
            _joinPo.ClickJoin();
            Assert.IsTrue(_joinPo.PageSource.Contains("Request Thanks"));

        }

        /// <summary>
        /// 
        /// </summary>
        [TestCleanup]
        public void FixtureTearDown()
        {
            WebDriverFactory.Kill(_webDriver);
        }
    }
}