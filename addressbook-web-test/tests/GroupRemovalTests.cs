using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_test.model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace addressbook_web_test.tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            //  эти данные использовать , если нет группы 
            GroupData newData = new GroupData("Group1");
            newData.Header = "Header1";
            newData.Footer = "Footer1";

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData tobeRemoved = oldGroups[0];

            app.Navigator.GoToGroupsPage();

            if (app.Groups.IsGroupPresent() != true) { app.Groups.Create(newData); }

            app.Groups.Remove(tobeRemoved);

           
            if (oldGroups.Count > 1)
            {
                Assert.AreEqual(oldGroups.Count -1, app.Groups.GetGroupCount());
                List<GroupData> newGroups = GroupData.GetAll();
                GroupData toBeRemoved = oldGroups[0];
                oldGroups.RemoveAt(0);
                oldGroups.Sort();
                newGroups.Sort();

                Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
                {
                    Assert.AreNotEqual(group.Id, toBeRemoved.Id);
                }
            }
        }
 
    }
}

