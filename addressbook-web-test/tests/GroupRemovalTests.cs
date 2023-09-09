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
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        { 
            //  эти данные использовать , если нет группы 
            GroupData newData = new GroupData("Group1");
            newData.Header = "Header1";
            newData.Footer = "Footer1";
           
            app.Navigator.GoToGroupsPage();
            app.Groups.Remove(1, newData);
           
        }


    }
}

