using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test.appmanager;
using addressbook_web_test.model;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_test.tests
{
    public class TestBase
    {
        //protected IWebDriver driver;
        //protected StringBuilder verificationErrors;
        //protected string baseURL;
        //protected LoginHelper loginHelper;
        //protected NavigationHelper navigator;
        //protected GroupHelper groupHelper;

        protected ApplicationManager app;


        [SetUp]
        protected void SetupTest()
        {
            //driver = new FirefoxDriver();
            //baseURL = "http://localhost";
            //verificationErrors = new StringBuilder();

            app = new ApplicationManager();
            app.Navigator.OpenPage();
            app.Auth.Login(new AccoutData("admin", "secret"));
        }

        [TearDown]
        protected void TeardownTest()
        {
            app.Stop();

            //Assert.AreEqual("", verificationErrors.ToString());
        }

        



    }
}
