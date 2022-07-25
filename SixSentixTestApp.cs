using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SixSentixTestApp
{
    public class SixSentixTestApp
    {
        const string HomeURL = @"https://www.sixsentix.com/";
        private readonly ITestOutputHelper output;

        public SixSentixTestApp(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplication()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                var testPage = new HomePageTest(driver);
                testPage.NavigateTo();
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Application page has bin oppened.");
                string pageTitle = driver.Title;
                driver.Manage().Window.Maximize();
                DemoHelper.Pause();
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Title of the page is: {driver.Title}");
                testPage.EnsurePageLoad();
                DemoHelper.Pause();
                
            }
        }
        [Fact]
        public void ApplicationsFormFilling()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                var testPage = new HomePageTest(driver);
                ApplyForm applyForm = new ApplyForm(driver);
                testPage.NavigateTo();
                testPage.EnsurePageLoad();
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Applications form has bin oppened.");
                output.WriteLine( $"Text is:\n{testPage.ReadText()}\n");
                testPage.ApplyForm();
                DemoHelper.Pause();
                output.WriteLine($"");
                output.WriteLine($"Accept Terms text is:\n {applyForm.AcceptTermsText()}\n");
                output.WriteLine($"Moto of SixSentix company is:\n{applyForm.SixSentixMoto()}\n");
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Applications page has bin closed.");
                DemoHelper.Pause();
            }

        }
        [Fact]
        public void ApplicationsFormFillingWithErrorsAdnFixes()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var testPage = new HomePageTest(driver);
                ApplyForm applyForm = new ApplyForm(driver);
                testPage.NavigateTo();
                testPage.EnsurePageLoad();
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Applications form has bin oppened.");
                output.WriteLine($"Text is:\n{testPage.ReadText()}\n");
                testPage.ApplyFormErrors();
                DemoHelper.Pause();
                output.WriteLine($"");
                output.WriteLine($"Accept Terms text is:\n {applyForm.AcceptTermsText()}\n");
                output.WriteLine($"Moto of SixSentix company is:\n{applyForm.SixSentixMoto()}\n");
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Applications page has bin closed.");
                output.WriteLine($"Messages are asserted:");
                List<string> errorTextList = applyForm.errorsTextList();
                for (int i = 0; i < errorTextList.Count; i++)
                {
                    output.WriteLine(errorTextList[i].ToString());
                }
                DemoHelper.Pause();
                testPage.ApplyFormErrorsFixed();
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Errors had bin fixwd.");

            }

        }
        [Fact]
        public void AboutCompanyTestPage()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                AboutCompanyPage companyPageTesting = new AboutCompanyPage(driver);
                companyPageTesting.NavigateTo();
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Company Page has bin started testing.");
                DemoHelper.Pause();
                DemoHelper.ScrollPageDown(driver);
                DemoHelper.Pause();
                DemoHelper.ScrollDownBy(driver,800);
                DemoHelper.WebDriverWait(driver);
                DemoHelper.ScrollDownBy(driver, 800);
                DemoHelper.Pause(1500);
                DemoHelper.ScrollToTheTop(driver);
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Tester has choosen 'Insights' from drop Meny.");
                companyPageTesting.InsightsClick();
                DemoHelper.WebDriverWait(driver);
                DemoHelper.ScrollDownBy(driver, 1000);
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Tester scrolling down.");
                DemoHelper.WebDriverWait(driver);
                DemoHelper.ScrollDownBy(driver, 1000);

                DemoHelper.Pause();
                companyPageTesting.InsightsBlogClick();
                DemoHelper.WebDriverWait(driver);
                string blogTitle = companyPageTesting.BlogTitleChoose();
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Tester choose one Blog title: {blogTitle}.");
                output.WriteLine($"Article title is: {companyPageTesting.BlogTitleChoose()}");
                DemoHelper.Pause();
                DemoHelper.Pause();
                //ReadOnlyCollection<string> allTabs = driver.WindowHandles;
                //string homePageTab = allTabs[0];
                //string broschurePageTab = allTabs[1];
                //driver.SwitchTo().Window(broschurePageTab);
                //DemoHelper.Pause();
                //Assert.Equal("https://www.sixsentix.com/storage/160/Sixsentix-Brochure.pdf", driver.Url);
            }
        }
        [Fact]
        public void InsightsTestingPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                string insightsUrl = @"https://www.sixsentix.com/insights";
                HomePageTest homePage = new HomePageTest(driver);
                homePage.NavigateTo(insightsUrl);
                homePage.InsightsFilterBy();
                
                ReadOnlyCollection<IWebElement> blogTitleCollection = homePage.InsightsBlogsTitle();
                output.WriteLine("Titles are:");
                for (int i = 0; i < blogTitleCollection.Count; i++)
                {
                    output.WriteLine($"{i} = {blogTitleCollection[i].Text}");
                }
            }
        }
        [Fact]
        public void JobSearching()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                ApplyForm applyForm = new ApplyForm(driver);
                JobSearchingPages jobSearch = new JobSearchingPages(driver);
                output.WriteLine($"{DateTime.Now.ToLongTimeString()}: Test is started.");
                jobSearch.StartPage();
                output.WriteLine($"{DateTime.Now.ToLongTimeString()}: IT Specialist Test is started.");
                jobSearch.ITSpecialistPage();
                output.WriteLine($"{DateTime.Now.ToLongTimeString()}: Errors are:");
                List<string> errorTextList = applyForm.errorsTextList();
                for (int i = 0; i < errorTextList.Count; i++)
                {
                    output.WriteLine(errorTextList[i].ToString());
                }
                applyForm.FindAndCorrectEmptyFillds();
            }
            
        }
    }
}
