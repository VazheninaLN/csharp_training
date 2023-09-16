﻿using addressbook_web_test.model;
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
        public static IEnumerable<NameData> RandomContactDataProvider()
            
        {
            List<NameData> contact = new List<NameData>();
            for (int i = 0; i< 5; i++)
            {
                contact.Add(new NameData(GenerateRandomString(30))
                {
                    MiddleName = GenerateRandomString(30),
                    LastName = GenerateRandomString(30)
                });
            }
            return contact;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(NameData contact)
        {


            app.Navigator.GoToContactPage();
            

            List<NameData> oldContact = app.Contact.GetContactList();

            
            app.Contact.Create(contact);
            
            Assert.AreEqual(oldContact.Count+1, app.Contact.GetContactCount());

            List<NameData> newContact= app.Contact.GetContactList();
            
            
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }


    }
}


