using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test.model;
using NUnit.Framework;


namespace addressbook_web_test.tests
{
    [TestFixture]
    public class LoginTests:TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // подготовка  дл теста 
            app.Auth.Logout();
            //действия 
            AccoutData account= new AccoutData("admin", "secret");

            app.Auth.Login(account);
           //проверка 
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        public void LoginWithInValidCredentials()
        {
            // подготовка  дл теста 
            app.Auth.Logout();
            //действия 
            AccoutData account = new AccoutData("admin", "123456");

            app.Auth.Login(account);
            //проверка 
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }

    }
}
