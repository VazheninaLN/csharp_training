using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        //protected StringBuilder verificationErrors;
        protected string baseURL;

       
        private bool acceptNextAlert = true;
        protected LoginHelper loginHelper;
        protected ProjectManagerHelper projectHelper;
        protected NavigationHelper navigationHelper;
       

       

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver= new FirefoxDriver();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            baseURL = "http://localhost/mantisbt-2.25.8/login_page.php";
            
            loginHelper = new LoginHelper(this);
            projectHelper = new ProjectManagerHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);

        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.8/login_page.php";
                app.Value=newInstance;
               
            }
            return app.Value;
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public ProjectManagerHelper Project
        {
            get{return projectHelper;}
        }
        public NavigationHelper Navigator
        {
            get { return navigationHelper; }
        }
        public LoginHelper Auth
        {
            get { return loginHelper;  }
           
        }


    }
}
