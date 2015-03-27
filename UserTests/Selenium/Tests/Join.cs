using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using UserTests.Selenium.PageObjects;

namespace UserTests.Selenium.Tests
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
            //_webDriver = WebDriverFactory.GetPhantomJsDriver();
            _webDriver = WebDriverFactory.GetFireFoxDriver();
            _joinPo = new PageObjects.JoinPo(_webDriver);
        }

        /// <summary> 
        /// Join using an address that is already included.
        /// </summary>
        [TestMethod]
        public void Join_User_Already_Present()
        {
            var joinPo = new JoinPo(_webDriver);
            const String emailAddress = @"insightblackradley@mailinator.com";
            const String password = "pa55worD";
            joinPo.Join(emailAddress, password);
            _webDriver.ScreenShot();
            // Still on the join page
            Assert.IsTrue(_joinPo.PageSource.Contains("Enter your email and choose a password"));
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