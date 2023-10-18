using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]

        public void TestGroupCreation()
           
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData() { Name = "test" };
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();   
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}