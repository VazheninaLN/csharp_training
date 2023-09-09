using addressbook_web_test.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace addressbook_web_test.appmanager
{
    public class GroupHelper : HelperBase
    {

        
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            
        }

        public GroupHelper Create (GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            UnitGroupCreation();
            FillGroup(group);
            SubmitGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            if (driver.Url=="http://localhost/addressbook/group.php"
                && IsElementPresent(By.Name("selected[]")))
            {
                
                SelectGroup(p);
            }
            else
            {
                UnitGroupCreation();
                FillGroup(newData);
                SubmitGroup(); 
            }
            InitGroupModification();
            FillGroup(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper Remove(int p, GroupData newData)

        {
            manager.Navigator.GoToGroupsPage();
            if (driver.Url=="http://localhost/addressbook/group.php"
                && IsElementPresent(By.Name("selected[]")))
            {
                SelectGroup(p);
                RemoveGroup();
            }
            else
            {
                UnitGroupCreation();
                FillGroup(newData);
                SubmitGroup();
            }
           
            ReturnToGroupPage();
            return this;
           
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }


        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroup(GroupData group)
        {
           
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            
            
            return this;
        }

        public GroupHelper UnitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click(); ;
            return this;
        }


    }
}
