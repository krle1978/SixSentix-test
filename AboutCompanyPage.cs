using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixSentixTestApp
{
    public class AboutCompanyPage
    {
        private readonly IWebDriver Driver;
        private readonly string aboutUs = @"https://www.sixsentix.com/life-at-sixsentix/about-us";

        public AboutCompanyPage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(aboutUs);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            IWebElement acceptCoockies = Driver.FindElement(By.ClassName("js-lcc-accept"));
            acceptCoockies.Click();
            Driver.Manage().Window.Maximize();
        }
        public ReadOnlyCollection<IWebElement> DisplayMenuElements() => Driver.FindElements(By.TagName("li"));
        public void InsightsClick()
        {
            ReadOnlyCollection<IWebElement> menuCollection = DisplayMenuElements();
            menuCollection[15].Click();
        }
        public void InsightsBlogClick() => Driver.FindElement(By.PartialLinkText("IT game plan:")).Click();
        public string BlogTitleChoose() => Driver.FindElement(By.CssSelector(".content-wrap>h1")).Text;
        public void RecourcesClick()
        {
            ReadOnlyCollection<IWebElement> menuCollection = DisplayMenuElements();
            menuCollection[11].Click();
        }
        public string InsigttsTextMoto() => Driver.FindElement(By.ClassName("content-wrap")).Text;
        public void BroschuresClickOn() => Driver.FindElement(By.XPath("/html/body/main/div/section[2]/div/div/div[2]/div[1]/div/a/span")).Click();
        public void WhitePapersClickOn() => Driver.FindElement(By.XPath("/html/body/main/div/section[2]/div/div/div[2]/div[3]/div/a/span")).Click();
    }
}
