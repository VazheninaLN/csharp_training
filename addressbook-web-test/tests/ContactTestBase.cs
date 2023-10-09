using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test.model;
using NUnit.Framework;


namespace addressbook_web_test.tests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS_CONTACT)
            {
                List<NameData> fromUI = app.Contact.GetContactList();
                List<NameData> fromDB = NameData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }

    }
}
