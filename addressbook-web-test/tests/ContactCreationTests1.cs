using addressbook_web_test.model;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace addressbook_web_test.tests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase


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

        public static IEnumerable<NameData> ContactDataFromXmlFile()
        {
            return (List<NameData>)new XmlSerializer(typeof(List<NameData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<NameData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<NameData>>(File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(NameData contact)
        {


            app.Navigator.GoToContactPage();
            

            List<NameData> oldContact = NameData.GetAll();

            
            app.Contact.Create(contact);
            
            Assert.AreEqual(oldContact.Count+1, app.Contact.GetContactCount());

            List<NameData> newContact = NameData.GetAll();
            
            
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }
        
        

    }
}


