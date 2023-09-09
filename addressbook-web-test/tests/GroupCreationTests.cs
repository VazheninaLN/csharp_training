using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_test.model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


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

            app.Groups.Create(group);
         
        }
        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            //app.Navigator.GoToGroupsPage();
            app.Groups.Create(group);
               
        }


    }
}
