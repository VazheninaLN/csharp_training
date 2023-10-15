using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_test_white
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]

        public void TestGroupCreation()
           
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData() { Name = "white" };
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();   
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}