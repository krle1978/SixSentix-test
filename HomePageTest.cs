using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;
using Xunit.Abstractions;

namespace SixSentixTestApp
{
    public class HomePageTest
    {
        private readonly IWebDriver Driver;
        private readonly ITestOutputHelper output;
        private string HomeURL = @"https://www.sixsentix.com/";

        public ITestOutputHelper Output => output;

        public HomePageTest(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateTo(string HomeURL = @"https://www.sixsentix.com/")
        {
            Driver.Navigate().GoToUrl(HomeURL);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            IWebElement acceptCoockies = wait.Until((D)=> D.FindElement(By.ClassName("js-lcc-accept")));
            if (acceptCoockies.Displayed == true)
            {
                acceptCoockies.Click();
            }
            Driver.Manage().Window.Maximize();
        }
        public void EnsurePageLoad()
        {
            Assert.Equal("On-demand Software Testing Services |", Driver.Title);
            Assert.Equal(HomeURL, Driver.Url);
        }
        public void CarouselClickXPathOn() => Driver.FindElement(By.XPath("/html/body/main/div/section[6]/div/div/div[2]/button[1]")).Click();
        public void CarouselClickOn()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            IWebElement carouselClick = wait.Until((D) => D.FindElement(By.CssSelector("button.slick-next")));
            carouselClick.Click();
        }
        public void ITSpecialistClickOn() => Driver.FindElement(By.CssSelector("div.positions-wrap a")).Click();
        public void ApplyNowClick() => Driver.FindElement(By.CssSelector("a.button-primary")).Click();
        public void SayHalloClick() => Driver.FindElement(By.LinkText("Say hello")).Click();
        public string ReadText() => Driver.FindElement(By.ClassName("content-wrap")).Text;
        public void RequestProposalClick() => Driver.FindElement(By.CssSelector("li.request-proposal")).Click();
            
        public void ApplyForm()
        {
            Driver.FindElement(By.LinkText("Request a Proposal")).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            ApplyForm applyForm = new ApplyForm(Driver);
            applyForm.EnterFirstName();
            applyForm.EnterLastName();
            applyForm.EnterCompanyName();
            applyForm.EnterBusinessEmail();
            DemoHelper.Pause();
            applyForm.ChooseYourRole();
            applyForm.FillUpTextBox();
            DemoHelper.ScrollDownBy(Driver);
            applyForm.AcceptTermsXPath();
            applyForm.SubmitApp();
        }
        public void ApplyFormErrors()
        {
            Driver.FindElement(By.LinkText("Request a Proposal")).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            ApplyForm applyForm = new ApplyForm(Driver);
            applyForm.EnterFirstName();
            //applyForm.EnterLastNameInvalidXSS();
            applyForm.EnterCompanyName();
            //applyForm.EnterBusinessEmail();
            DemoHelper.Pause();
            DemoHelper.ScrollDownBy(Driver);
            applyForm.ChooseYourRole();
            DemoHelper.ScrollDownBy(Driver);
            applyForm.FillUpTextBox();
            //DemoHelper.ScrollDownBy(Driver);
            applyForm.AcceptTerms();
            applyForm.SubmitApp();
            DemoHelper.ScrollUpBy(Driver);

            wait.Until((d) => d.FindElements(By.ClassName("is-invalid")));
            ReadOnlyCollection<IWebElement> errorMessages = applyForm.FindErrorMessage();
            if (errorMessages.Count != 0)
            {
                Assert.Equal(2, errorMessages.Count);
            }
            DemoHelper.WebDriverWait(Driver);
            DemoHelper.ScrollUpBy(Driver, 800);
            DemoHelper.Pause(8000);
            }

        public void ApplyFormErrorsFixed()
        {
            ApplyForm applyForm = new ApplyForm(Driver);
            
            applyForm.FindAndCorrectEmptyFillds();

            DemoHelper.Pause();
        }

        public void InsightsFilterBy()
        {
            Driver.FindElement(By.ClassName("selection")).Click();
            DemoHelper.Pause();
            Driver.FindElement(By.XPath("/html/body/main/div/section[2]/div/div/div[1]/form/div/div/span[2]/span/span[2]/ul/li[2]")).Click();
            DemoHelper.Pause();
            DemoHelper.ScrollDownBy(Driver,800);
            DemoHelper.Pause();
        }
        public ReadOnlyCollection<IWebElement> InsightsBlogsTitle() => Driver.FindElements(By.TagName("h4"));
        
    }
}
