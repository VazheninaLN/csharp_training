using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using addressbook_web_test.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_test.tests
{
    [TestFixture]
    public class ContactRemoveTests : TestBase

    {
        [Test]
        public void ContactRemoveTest()
        {
            app.Navigator.OpenPageHome();
            app.Navigator.GoToContactPage();
            app.Contact
            .SelectContact(1)
            .RemoveContact();
                    //delete?
            Assert.IsTrue(Regex.IsMatch(app.Contact.CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            app.Contact.GoToHomePage();
            
        }


    }
}