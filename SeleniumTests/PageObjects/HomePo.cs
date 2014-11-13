using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace SeleniumTests.PageObjects
{
    public class HomePo : BasePo
    {
        public HomePo(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
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
