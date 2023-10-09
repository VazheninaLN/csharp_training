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
    public class ContactRemoveTests : ContactTestBase

    {
        [Test]
        public void ContactRemoveTest()
        {
            // использовать данные для контакта, если его нет 
            NameData contactRemove = new NameData("Петр", "Пeтрович", "Петров");

            app.Navigator.OpenPage();
            List<NameData> oldContact = NameData.GetAll();

            if (app.Contact.IsContactPresent()==false) { app.Contact.Create(contactRemove); }
            
            NameData toBeRemoved = oldContact[0];
            app.Contact.Remove(toBeRemoved);

            if (oldContact.Count>1)
            {
                Assert.AreEqual(oldContact.Count -1, app.Contact.GetContactCount());
                List<NameData> newContact = NameData.GetAll();
                oldContact.RemoveAt(0);
                oldContact.Sort();
                newContact.Sort();

                Assert.AreEqual(oldContact, newContact);
                foreach (NameData contact in newContact)
                {
                    Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
                }
            } 
        }


    }
}