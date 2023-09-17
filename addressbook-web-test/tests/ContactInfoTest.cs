using addressbook_web_test.model;

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
    public class ContactInfoTest: AuthTestBase

    {

        [Test]
        public void TestContactInformation()
        {
            NameData fromTable = app.Contact.GetContactInformationFromTable(0);
            NameData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhone, fromForm.AllPhone);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);

        }
        [Test]

        public void TestContactInformationDetals()
        {
            NameData fromDetals = app.Contact.GetContactInformationFromDetals(0);
            NameData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromDetals.AllDetals, fromForm.AllDetals);
           
        }

    }
}
