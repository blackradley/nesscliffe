using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace Tests.Selenium.PageObjects
{
    public class ThanksPo : BasePo
    {
        public ThanksPo(IWebDriver driver) : base(driver)
        {
            this.Driver = driver;
            driver.Navigate().GoToUrl(WebDriverFactory.BaseUrl);
            // Check that we're on the right page.
            if (Url.Equals(WebDriverFactory.BaseUrl))
            {
                driver.ScreenShot();
                throw new NotTheRightPageException("This is not the home page");
            }
        }
    }
}
