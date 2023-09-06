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
    public class NavigationHelper : HelperBase
    {
        //private IWebDriver driver;
        private string baseURL;

        public NavigationHelper(ApplicationManager manager,string baseURL) : base(manager)
        {
            // this.driver=driver;
            this.baseURL = baseURL;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/group.php");
        }



        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
