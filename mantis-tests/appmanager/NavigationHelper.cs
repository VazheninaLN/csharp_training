using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace mantis_tests
{
    
        public class NavigationHelper : HelperBase
        {
            public string baseURL;
            public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
            {

                this.baseURL = baseURL;
            }
        
        public void GoToControlPanel()
            {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.8/my_view_page.php");
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
        }
            public void GoToProjectControlPanel()

            {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.8/manage_overview_page.php");
            driver.FindElement(By.LinkText("Управление проектами")).Click();
                //driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.8/manage_proj_page.php']")).Click();
            }
        }


    
}
