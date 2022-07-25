using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixSentixTestApp
{
    public class JobSearchingPages
    {
        private readonly IWebDriver Driver;
        private readonly string ITSpecURL = @"https://www.sixsentix.com/current-openings/it-specialist";

        public JobSearchingPages(IWebDriver driver)
        {
            Driver = driver;
        }
        public void StartPage()
        {
            HomePageTest homePageTest=new HomePageTest(Driver);
            homePageTest.NavigateTo();
            DemoHelper.Pause();
            DemoHelper.ScrollDownBy(Driver,1000);
            DemoHelper.Pause();
            DemoHelper.ScrollDownBy(Driver,800);
            DemoHelper.Pause();
            DemoHelper.ScrollDownBy(Driver, 800);
            DemoHelper.Pause();
            DemoHelper.ScrollDownBy(Driver, 1000);
            DemoHelper.Pause();
           
            homePageTest.CarouselClickOn();
            DemoHelper.Pause();
            homePageTest.CarouselClickOn();
            DemoHelper.Pause();
            homePageTest.CarouselClickOn();
            DemoHelper.Pause();
            DemoHelper.ScrollDownBy(Driver, 800);
            DemoHelper.Pause();
            homePageTest.ITSpecialistClickOn();
            DemoHelper.WebDriverWait(Driver);
            DemoHelper.ScrollDownBy(Driver, 1000);
            DemoHelper.Pause();
            DemoHelper.ScrollDownBy(Driver, 800);
            DemoHelper.Pause();
            DemoHelper.ScrollDownBy(Driver, 800);
            DemoHelper.Pause();
            DemoHelper.ScrollPageUp(Driver);
            DemoHelper.ScrollDownBy(Driver,200);
            homePageTest.SayHalloClick();
            DemoHelper.Pause();
        }
        public void ITSpecialistPage()
        {
            HomePageTest homePageTesting = new HomePageTest(Driver);
            DemoHelper.Pause();
            homePageTesting.SayHalloClick();
            DemoHelper.ScrollToTheTop(Driver);
            homePageTesting.RequestProposalClick();
            DemoHelper.Pause();
            homePageTesting.ApplyFormErrors();
            DemoHelper.Pause();
            
        }
    }
    
}
