using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    public class ContactModifyTests : ContactTestBase

    {
        [Test]
        public void ContactModifyTest()
        {
          
            app.Navigator.OpenPage();
            

            NameData contactM= new NameData("Петр");
            contactM.MiddleName = "ПЕтрович";
            contactM.LastName = "Петров";
           
            List<NameData> oldContact = NameData.GetAll();
            //NameData oldData = oldContact[0];
            NameData tobeModify = oldContact[0];

            if (app.Contact.IsContactPresent() ==false) { app.Contact.Create(contactM); }
           
                app.Contact.Modify(tobeModify, contactM);
              
            Assert.AreEqual(oldContact.Count, app.Contact.GetContactCount());
            List<NameData> newContact = NameData.GetAll();
            oldContact[0].FirstName= contactM.FirstName;
            oldContact[0].LastName= contactM.LastName;
            
            oldContact.Sort();
            newContact.Sort(); 

            Assert.AreEqual(oldContact, newContact);

            foreach (NameData contact in newContact)
            {
                if (contactM.Id == tobeModify.Id)
                { 
                  Assert.AreEqual(contact.FirstName, contactM.FirstName);
                  Assert.AreEqual(contact.LastName, contactM.LastName);
                }
             
            }

        }


    }
}
