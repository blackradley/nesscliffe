using System.Security.Permissions;
using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace Tests.Selenium.PageObjects
{
    public class JoinPo : BasePo
    {
        public JoinPo(IWebDriver driver) : base(driver)
        {
            this.Driver = driver;
            driver.Navigate().GoToUrl(WebDriverFactory.BaseUrl + "/Account/Register");
            // Check that we're on the right page.
            if (!Url.Contains("/Account/Register"))
            {
                driver.ScreenShot();
                throw new NotTheRightPageException("This is not the join page it is " + Url);
            }
        }

        public JoinPo Join(string emailAddressText, string passwordText)
        {
            this.TypeEmailAddress(emailAddressText);
            this.TypePassword(passwordText);
            this.ClickAgree();
            this.ClickJoin();
            return this;
        }

        readonly By _emailAddress = By.Id("Email");
        public JoinPo TypeEmailAddress(string emailAddressText)
        {
            Driver.FindElement(_emailAddress).SendKeys(emailAddressText);
            return this;
        }

        readonly By _password = By.Id("Password");
        public JoinPo TypePassword(string passwordText)
        {
            Driver.FindElement(_password).SendKeys(passwordText);
            return this;
        }

        private readonly By _agree = By.Id("agree");
        public JoinPo ClickAgree()
        {
            Driver.FindElement(_agree).Click();
            return this;
        }

        readonly By _join = By.Id("submit");
        public JoinPo ClickJoin()
        {
            Driver.FindElement(_join).Click();
            return this;
        }
    }
}
