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
    public class ContactRemoveTests : AuthTestBase

    {
        [Test]
        public void ContactRemoveTest()
        {
            // использовать данные для контакта , если его нет 
            NameData contact = new NameData("Петр");
            contact.MiddleName = "ПЕтрович";
            contact.LastName = "Петров";

            app.Navigator.OpenPage();
            //app.Navigator.GoToContactPage();
            app.Contact.Remove(1, contact);
            //app.Contact
            //.SelectContact(1)
            //.RemoveContact();
                    //delete?
            Assert.IsTrue(Regex.IsMatch(app.Contact.CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            app.Contact.GoToHomePage();
            
        }


    }
}