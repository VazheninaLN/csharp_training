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
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Group6");
            newData.Header = "Header6";
            newData.Footer = "Footer6";

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModificate = oldGroups[0];

            if (app.Groups.IsGroupPresent() != true) { app.Groups.Create(newData); }
            
            
            app.Groups.Modify(toBeModificate, newData);
           

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
                oldGroups[0].Name = newData.Name;
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id ==toBeModificate.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
            
        }
    }
}
