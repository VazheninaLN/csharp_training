using addressbook_web_test.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test.appmanager
{
    public class LoginHelper : HelperBase
    {
        //private IWebDriver driver;
        public LoginHelper(ApplicationManager manager) : base(manager)
        {

            //this.driver=driver;
        }

        public void Login(AccoutData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                { return; }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            
                      
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
        public bool IsLoggedIn()
 
        {
            return IsElementPresent(By.Name("logout"));
            
        }
        public bool IsLoggedIn(AccoutData account)
        {

            return IsLoggedIn()
                && GetLoggetUserName()==account.Username;
               
            
        }

        public string GetLoggetUserName()
        {
            string text =  driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length -2);
        }
    }


}
