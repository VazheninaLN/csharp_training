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
        protected bool acceptNextAlert = true;
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            //this.driver=driver;
        }

        public ContactHelper Create(NameData contact)
        {
            manager.Navigator.GoToPageAddContact();

            FillContact(contact);
            SubmitContact();
            GoToHomePage();
            return this;
      
        }

        public ContactHelper Remove(int p, NameData contact)
        {
            manager.Navigator.GoToContactPage();
            if (driver.Url=="http://localhost/addressbook/"
               && IsElementPresent(By.Name("selected[]")))
            {
                SelectContact(p);
               RemoveContact();
            }
            else
            {
                FillContact(contact);
                SubmitContact();
            }
            
            //GoToHomePage();
            return this;

        }

        public ContactHelper Modify(int p, NameData newData)
        {
            manager.Navigator.GoToContactPage();
            if (driver.Url=="http://localhost/addressbook/"
               && IsElementPresent(By.Name("selected[]")))
            {
                SelectContact(p);
                // нажать  Edit
                InitContactModification();
                FillContact(newData);
                //нажать update
                SubmitContactModification();
            }
            else
            {
                FillContact(newData);
                SubmitContact();
            }
            GoToHomePage();
            return this;

        }

        public ContactHelper FillContact(NameData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            
            //driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.Id("1")).Click();
            //driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
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
        

        public ContactHelper RemoveContact()
        {
            //driver.FindElement(By.Name("delete")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }



        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    
}
}
