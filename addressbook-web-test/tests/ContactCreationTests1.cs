using addressbook_web_test.model;

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_test.model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_test.tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase

    {
        [Test]
        public void GroupCreationTest()
        {

            app.Navigator.GoToContactPage();
            NameData contact = new NameData("Иван");
            contact.MiddleName = "Иванович";
            contact.LastName = "Иванов";

            app.Contact.Create(contact);

        }


    }
}


