using addressbook_web_test.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook_web_test.tests
{
    public class ContactModifyTests : AuthTestBase

    {
        [Test]
        public void ContactModifyTest()
        {
          
            app.Navigator.OpenPage();
            //app.Navigator.GoToContactPage();

            NameData contact = new NameData("Петр");
            contact.MiddleName = "ПЕтрович";
            contact.LastName = "Петров";

            List<NameData> oldContact = app.Contact.GetContactList();
            if (app.Contact.IsContactPresent())
            {
                app.Contact.Modify(0, contact);
            }
            else 
            {
                NameData contactModify = new NameData("Сидоров", "Иван");
                app.Contact.Create(contactModify);
                app.Navigator.OpenPage();
                app.Contact.Modify(0, contact);
            }

            List<NameData> newContact = app.Contact.GetContactList();
            oldContact[0].FirstName= contact.FirstName;
            oldContact[0].LastName= contact.LastName;
            
            oldContact.Sort();
            newContact.Sort(); 

            Assert.AreEqual(oldContact, newContact);

        }


    }
}
