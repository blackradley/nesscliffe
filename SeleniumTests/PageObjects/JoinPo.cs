using System.Security.Permissions;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using SeleniumTests.Tests;

namespace SeleniumTests.PageObjects
{
    public class JoinPo : BasePo
    {
        public JoinPo(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(WebDriverFactory.BaseUrl + "/SendMail/RequestInvite");
            // Check that we're on the right page.
            if (!Url.Contains("/SendMail/RequestInvite"))
            {
                driver.ScreenShot();
                throw new NotTheRightPageException("This is not the join page it is " + Url);
            }
        }

        public JoinPo Join(string emailAddressText)
        {
            this.TypeEmailAddress(emailAddressText);
            this.ClickJoin();
            return this;
        }

        readonly By _emailAddress = By.Id("Email");
        public JoinPo TypeEmailAddress(string emailAddressText)
        {
            driver.FindElement(_emailAddress).SendKeys(emailAddressText);
            return this;
        }

        readonly By _join = By.Id("Join");
        public JoinPo ClickJoin()
        {
            driver.FindElement(_join).Click();
            return this;
        }
    }
}
