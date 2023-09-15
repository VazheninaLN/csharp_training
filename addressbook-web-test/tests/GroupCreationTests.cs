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
    public class GroupCreationTests : AuthTestBase
    {


        [Test]
        public void GroupCreationTest()
        {
           
            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("Group5");
            group.Header = "Header5";
            group.Footer = "Footer5";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            
            Assert.AreEqual(oldGroups.Count +1, app.Groups.GetGroupCount()); 

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            // если первая группа
            if (oldGroups.Count>0)
            {
                Assert.AreEqual(oldGroups, newGroups);
            }
         
        }
        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            //app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count +1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            if (oldGroups.Count>0)
            {
             Assert.AreEqual(oldGroups, newGroups);
            }; 

        }


    }
}
