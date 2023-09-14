using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            // использовать данные для контакта, если его нет 
            NameData contactRemove = new NameData("Петр", "Пeтрович", "Петров");

            app.Navigator.OpenPage();
            List<NameData> oldContact = app.Contact.GetContactList();

            if (app.Contact.IsContactPresent())
            {
                app.Contact.Remove(0);
                List<NameData> newContact = app.Contact.GetContactList();
                oldContact.RemoveAt(0);
                oldContact.Sort();
                newContact.Sort();

                Assert.AreEqual(oldContact, newContact);
            }
            else
            {
                // create new contact for remove
                app.Contact.Create(contactRemove);
                //delete
                app.Contact.Remove(0);
                app.Contact.GoToHomePage();
            }
            
        }


    }
}