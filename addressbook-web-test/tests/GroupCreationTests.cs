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

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i< 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        

        [Test,TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
           
            app.Navigator.GoToGroupsPage();
           

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
