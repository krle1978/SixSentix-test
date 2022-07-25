using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace SixSentixTestApp
{
    internal class DemoHelper
    {
        public static void Pause(int secondsToPause = 3000)
        {
            Thread.Sleep(secondsToPause);
        }
        public static WebDriverWait WebDriverWait(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait;
        }
        public static void ScrollDownBy(IWebDriver driver,int lang = 500)
        {
            string scrollLang = lang.ToString();
            string jsScrollDownPixel = $"window.scrollBy(0,{scrollLang});";
            ((IJavaScriptExecutor)driver).ExecuteScript(jsScrollDownPixel);
        }
        public static void ScrollUpBy(IWebDriver driver, int lang = 500)
        {
            string scrollLang = $"- {lang.ToString()}" ;
            string jsScrollUpPixel = $"window.scrollBy(0,{scrollLang});";
            ((IJavaScriptExecutor)driver).ExecuteScript(jsScrollUpPixel);
        }
        public static void ScrollToTheEnd(IWebDriver driver) =>
            driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.End);
        public static void ScrollToTheTop(IWebDriver driver) =>
            driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.Home);
        public static void ScrollPageDown(IWebDriver driver) =>
            driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.PageDown);
        public static void ScrollPageUp(IWebDriver driver) =>
            driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.PageUp);

    }
}
