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
using System.Collections.Generic;

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
           
                
            SelectGroup(p);
            InitGroupModification();
            FillGroup(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }


        public GroupHelper Modify(GroupData groups ,GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();


            SelectGroup(groups.Id);
            InitGroupModification();
            FillGroup(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache=null;
            return this;
        }

        public GroupHelper Remove(int p)

        {
            manager.Navigator.GoToGroupsPage();
            
             SelectGroup(p);
             RemoveGroup();
             ReturnToGroupPage();
            return this;
           
        }

        public GroupHelper Remove(GroupData groups)

        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(groups.Id);
            RemoveGroup();
            ReturnToGroupPage();
            return this;

        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }
        public bool IsGroupPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
            //return IsElementPresent(By.XPath("//tr[@class = 'odd' or @name = 'entry']"));
        
        }


        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache=null;
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
            groupCache=null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click(); ;
            return this;
        }
        private List<GroupData> groupCache = null;


        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    
                    groupCache.Add(new GroupData(element.Text)
                    { Id=element.FindElement(By.TagName("input")).GetAttribute("value") });
                }

            }
                       
            return new List<GroupData> (groupCache);

        }

        public int GetGroupCount()
        {
             return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
