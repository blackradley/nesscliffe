using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Tests.Selenium.PageObjects;

namespace Tests.Selenium.Tests
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
        public void StartJoin()
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
            Console.Write(_webDriver.Title);
            //_webDriver.ScreenShot();
            const String emailAddress = @"insightblackradley@mailinator.com";
            const String password = "pa55worD";
            joinPo.TypeEmailAddress(emailAddress);
            //joinPo.Join(emailAddress, password);

            // Still on the join page
            // Assert.IsTrue(_joinPo.PageSource.Contains("Enter your email and choose a password"));
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