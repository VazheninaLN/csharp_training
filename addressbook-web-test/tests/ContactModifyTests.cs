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


              app.Contact.Modify(1, contact);



        }


    }
}
