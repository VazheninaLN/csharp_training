using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test.model;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_test.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Group6");
            newData.Header = "Header6";
            newData.Footer = "Footer6";

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            if (app.Groups.IsGroupPresent())
            { app.Groups.Modify(0, newData); }
            else
            {
                GroupData newGroupM = new GroupData ("Group7", "Header7", "Footer7");
                app.Groups.Create(newData);
                app.Groups.Modify(0, newGroupM);

            }

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
                oldGroups[0].Name = newData.Name;
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id ==oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
            
        }
    }
}
