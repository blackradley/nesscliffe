using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.PageObjects
{
    public class BasePo
    {
        public IWebDriver driver;

        public BasePo() { }

        /// <summary>
        /// Using a base class to ensure that all the PageObjects initialize their elements.
        /// It is a bit of a Selenium thing.
        /// </summary>
        /// <param name="driver"></param>
        public BasePo(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// We're the Fakawi.
        /// </summary>
        public String Url
        {
            get { return driver.Url; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String PageSource
        {
            get { return driver.PageSource; }
        }
    }
}
