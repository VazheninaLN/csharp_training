using addressbook_web_test.model;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography;

namespace addressbook_web_test.tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase

    {
        [Test]
        public void ContactCreationTest()
        {


            app.Navigator.GoToContactPage();
            NameData contact = new NameData("Иван");
            contact.MiddleName = "Иванович";
            contact.LastName = "Иванов";

            List<NameData> oldContact = app.Contact.GetContactList();

            
            app.Contact.Create(contact); 
            

            List<NameData> newContact= app.Contact.GetContactList();
            
            
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            //Assert.AreEqual(oldContact, newContact);

        }


    }
}


