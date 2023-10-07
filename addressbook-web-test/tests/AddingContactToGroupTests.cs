using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test.model;
using NUnit.Framework;

namespace addressbook_web_test.tests
{
    public class AddingContactToGroupTests :AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        { 
            GroupData group  =  GroupData.GetAll()[0];
            List<NameData> oldList = group.GetContacts();
            NameData contact = NameData.GetAll().Except(oldList).First();

            app.Contact.AddContactToGroup(contact, group);

            List<NameData> newList = group.GetContacts();
            oldList.Add(contact);   
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
