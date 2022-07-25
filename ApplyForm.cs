using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SixSentixTestApp
{
    public class ApplyForm
    {
        private readonly IWebDriver Driver;
        public ApplyForm(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnterFirstName() => Driver.FindElement(By.Name("first_name")).SendKeys("Rade");
        public void EnterLastName() => Driver.FindElement(By.Name("last_name")).SendKeys("Krstic");
        public void EnterLastNameInvalidXSS() => Driver.FindElement(By.Name("last_name")).SendKeys("<script>\n<Alert('Tested!')>\n<script>");
        public void EnterCompanyName() => Driver.FindElement(By.Name("company_name")).SendKeys("(Free lancer)");
        public void EnterBusinessEmail() => Driver.FindElement(By.Name("business_email")).SendKeys("krstic.rade@gmail.com");
        
        public void ChooseYourRole()
        {
            IWebElement yourRole = Driver.FindElement(By.Id("select2--container"));
            yourRole.Click(); 
            Driver.FindElement(By.XPath("/html/body/span/span/span[2]/ul/li[5]")).Click();
          
        }
        public ReadOnlyCollection<IWebElement> DisplayMenuElements() => Driver.FindElements(By.TagName("li"));
        public void FillUpTextBox() => Driver.FindElement(By.Name("message")).SendKeys("This is just Selenium test by Rade Krstic.");
        public void AcceptTerms()
        {
            WebDriverWait wait = DemoHelper.WebDriverWait(Driver);
            wait.Until((d) => d.FindElement(By.CssSelector("div.checkbox-wrap > label > span")));
            Driver.FindElement(By.CssSelector("div.checkbox-wrap > label > span")).Click();
        }
        public void AcceptTermsXPath() => Driver.FindElement(By.XPath("//*[@id='form']/div/form/div[2]/div[7]/div/label/span")).Click();
        public string SixSentixMoto() => Driver.FindElement(By.ClassName("content-inner-wrap")).Text;
        public string AcceptTermsText() => Driver.FindElement(By.XPath("//*[@id='form']/div/form/div[2]/div[7]/div/label/p")).Text;
        public ReadOnlyCollection<IWebElement> FindErrorMessage() => Driver.FindElements(By.CssSelector("div.is-invalid"));

        public List<string> errorsTextList()
        {
            List<string> errorsToTextList = new List<string>();
            ReadOnlyCollection<IWebElement> errorMessages = FindErrorMessage();
            for (int i = 0; i < errorMessages.Count; i++)
            {
                errorsToTextList.Add(errorMessages[i].Text);
            }
            return errorsToTextList;
        }

        public void FindAndCorrectEmptyFillds()
        {
            ReadOnlyCollection<IWebElement> errors = FindErrorMessage();
            IWebElement firstName = Driver.FindElement(By.CssSelector("input[name='first_name']"));
            IWebElement lastName = Driver.FindElement(By.CssSelector("input[name='last_name'"));
            IWebElement companyName = Driver.FindElement(By.CssSelector("input[name='company_name']"));
            IWebElement emailAddress = Driver.FindElement(By.CssSelector("input[name='business_email']"));
            foreach (var error in errors)
            {
                if (error.Text == "First name *")
                {
                    firstName.SendKeys("Rade");
                }
                else if (error.Text == "Last name *")
                {
                    lastName.SendKeys("Krstic");
                }
                else if (error.Text == "Business e-mail *")
                {
                    emailAddress.SendKeys("krstic.rade'gmail.com");
                }
                else if (error.Text == "Company name *")
                {
                    companyName.SendKeys("(Free lancerS)");
                }
                else break;
            }
            
        }
        public void SubmitApp() => Driver.FindElement(By.CssSelector("[type='submit']")).Click();
    }
}
