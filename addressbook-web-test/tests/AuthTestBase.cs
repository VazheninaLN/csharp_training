using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using addressbook_web_test.appmanager;
using addressbook_web_test.model;
using NUnit.Framework;
using OpenQA.Selenium;


namespace addressbook_web_test.tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
            //второй уровень базового класса. выполняется логин
        {
            app.Auth.Login(new AccoutData("admin", "secret"));
        }
    }
}
