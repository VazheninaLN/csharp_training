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
            List<GroupData> groupList = GroupData.GetAll();

            List<NameData> contactList = NameData.GetAll();
            //  если нет группы
            if (groupList.Count == 0)
            {
                app.Groups.Create(new GroupData("group1"));
                groupList = GroupData.GetAll();
            }
            // если нет контакта
            if (contactList.Count == 0)
            {
                app.Contact.Create(new NameData("name11", "name22"));
                contactList = NameData.GetAll();
            }

           
            int count = 0;
            //собираем контакты в группе
            foreach (GroupData g in groupList)
            {
                List<NameData> contactsInGroup = g.GetContacts();
                contactList.Sort();
                contactsInGroup.Sort();
                // не все контакты в группе
                if (contactList.Count()!=contactsInGroup.Count())
                {
                    NameData contact = contactList.Except(contactsInGroup).First();

                    List<NameData> oldList = g.GetContacts();
                    app.Contact.AddContactToGroup(contact, g);
                    List<NameData> newList = g.GetContacts();
                    oldList.Add(contact);
                    oldList.Sort();
                    newList.Sort();
                    Assert.AreEqual(oldList, newList);
                    break;
                }
                count++;

                
                if (count == groupList.Count())
                {
                    app.Contact.Create(new NameData("name1", "name2"));
                    contactList = NameData.GetAll();
                    NameData contact = contactList.Except(contactsInGroup).First();
                    List<NameData> oldList = g.GetContacts();
                    app.Contact.AddContactToGroup(contact, g);
                    List<NameData> newList = g.GetContacts();
                    oldList.Add(contact);
                    oldList.Sort();
                    newList.Sort();
                    Assert.AreEqual(oldList, newList);
                }

            }



        }
    }
}
