using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace SeleniumTests
{
    /// <summary>
    /// There are a number of different approaches to getting a group of tests
    /// to behave in the same way.  A typical approach is to use a parent class
    /// which all the subclasses inherit from.  The parent class then uses a 
    /// constructor and destructor in place of setup and teardown.  This doesn't
    /// seem ideal to me since the destructor/teardown is controlled by the garbage
    /// collector rather than garanteed by the testing framework.
    /// </summary>
    public static class WebDriverFactory
    {
        /// <summary>
        /// The development machines all use this URL for testing, so it might not
        /// work on the Continuous Development server.
        /// </summary>
        public const string BaseUrl = "http://localhost:56107"; 
        public const int AjaxWait = 30;

        /// <summary>
        /// Method to provide a PhantomJs Driver.  The key parts here are to IgnoreSslErrors,
        /// since the configuration the development machines always generates an errror, and 
        /// to set the size to that of a Desktop so that no elements are hidden, since this
        /// testing is not intended to cover tablets and phones.
        /// </summary>
        /// <returns></returns>
        public static PhantomJSDriver GetPhantomJsDriver()
        {
            System.Diagnostics.Debug.WriteLine("Starting PhantomJs");
            var service = PhantomJSDriverService.CreateDefaultService();
            service.IgnoreSslErrors = true; // in development you get an SSL error.
            service.LoadImages = false; // for speed.
            service.ProxyType = "none";
            service.WebSecurity = false; // There is something on the page that uses XHR
            service.LocalToRemoteUrlAccess = true; // I get a time out without this, but not sure what it does.
            service.DiskCache = true; // Dunno what this does but I thought it might help.
            var driver = new PhantomJSDriver(service);
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 2, 30)); // the default is 0
            driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 2, 30));
            driver.Manage().Timeouts().SetScriptTimeout(new TimeSpan(0, 2, 30));
            driver.Manage().Window.Position = new Point(0, 0);
            driver.Manage().Window.Size = new Size(1366, 768);
            return driver;
        }

        public static FirefoxDriver GetFireFoxDriver()
        {
            System.Diagnostics.Debug.WriteLine("Starting FireFox");
            var driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30)); // the default is 0
            driver.Manage().Window.Position = new Point(0, 0);
            driver.Manage().Window.Size = new Size(1366, 768);
            return driver;
        }

        /// <summary>
        /// Method ot get rid of the IWebDriver from memory to be used in the 
        /// teardown for tests.
        /// </summary>
        /// <param name="driver"></param>
        public static void Kill(IWebDriver driver)
        {
            Debug.WriteLine("Killing Web Driver");
            if (driver == null) return;
            driver.Quit();
            driver.Dispose();
        }

        private static Dictionary<string, int> tests = new Dictionary<string, int>();
        /// <summary>
        /// Extension method (look out for "this" in the method signature) to add
        /// a screenshot method to an IWebDriver.  The screen shots are named after
        /// the class and method, and are incremented through the test.  In order to
        /// do this a Dictionary of the tests is kept (above) which is incremented
        /// each time a screenshot is taken.
        /// 
        /// The images are intended for debugging purposes and also as a demonstration 
        /// to the customer that the test completes (it is lighter weight than using
        /// a video).
        /// </summary>
        /// <param name="driver"></param>
        public static void ScreenShot(this IWebDriver driver)
        {
            // get call stack and calling method
            StackFrame stackFrame = new StackFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            string methodName = methodBase.Name;
            string className = methodBase.ReflectedType.Name;
            string fileName = String.Format("{0}.{1}.", className, methodName);
            if (!tests.ContainsKey(fileName)) tests.Add(fileName, 1);
            try
            {
                Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                int screenShotCounter = tests[fileName];
                screenShot.SaveAsFile(fileName + screenShotCounter + ".png", ImageFormat.Png);
                tests[fileName] = tests[fileName] + 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Some of the Ajax activity is a bit slow so wait for the new element to appear.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="byElement"></param>
        /// <param name="timeoutSeconds"></param>
        public static IWebElement WaitForAjaxElement(this IWebDriver driver, By byElement, double timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            IWebElement element = driver.FindElement(byElement);
            wait.Until(ElementIsClickable(byElement));
            return element;
        }

        /// <summary>
        /// Taken directly from http://stackoverflow.com/questions/16057031/webdriver-how-to-wait-until-the-element-is-clickable-in-webdriver-c-sharp
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        private static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }
    }
}

