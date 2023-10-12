using addressbook_web_test.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test.tests
{
    public class RemovingContactToGroupTest : AuthTestBase

    {
        [Test]
        public void TestRemovingContactToGroup()
        {

            List<GroupData> groups = GroupData.GetAll();
            GroupData group = new GroupData();
            NameData contactForRemove = new NameData();
            List<NameData> oldList = new List<NameData>();
            int count = 0;
            foreach (GroupData g in groups)
            {
                List<NameData> contactsInGroup = g.GetContacts();
                if (contactsInGroup.Count > 0)
                {
                    contactForRemove = contactsInGroup[0];
                    group = g;
                    oldList = group.GetContacts();
                    break;
                }
                count++;
                if (count == groups.Count)
                {
                    NameData contactForAdd = NameData.GetAll()[0];
                    GroupData groupForAdd = GroupData.GetAll()[0];
                    app.Contact.AddContactToGroup(contactForAdd, groupForAdd);
                    contactForRemove = contactForAdd;
                    group = groupForAdd;
                    oldList = group.GetContacts();
                }
            }

            app.Contact.RemoveContatFromGroup(contactForRemove, group);

            List<NameData> newList = group.GetContacts();
            oldList.Remove(contactForRemove);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }
}
