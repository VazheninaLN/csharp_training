using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_test.appmanager
{
    [TestFixture]
    public class ContactHelper : HelperBase
    {
        //private IWebDriver driver;
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            //this.driver=driver;
        }

        public ContactHelper Create(NameData contact)
        {
            manager.Navigator.GoToContactPage();

            FillContact(contact);
            SubmitContact();
            GoToHomePage();
            return this;
      
        }


        public ContactHelper FillContact(NameData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Иван");
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys("Иванович");
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Иванов");
            //driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
    }
}
