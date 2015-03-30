using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace Tests.Selenium.PageObjects
{
    public class BasePo
    {
        public IWebDriver Driver;

        public BasePo() { }

        /// <summary>
        /// Using a base class to ensure that all the PageObjects initialize their elements.
        /// It is a bit of a Selenium thing.
        /// </summary>
        /// <param name="driver"></param>
        public BasePo(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// We're the Fakawi.
        /// </summary>
        public String Url
        {
            get { return Driver.Url; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String PageSource
        {
            get { return Driver.PageSource; }
        }
    }
}
