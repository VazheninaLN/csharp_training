﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_test.appmanager
    
{
    [TestFixture]
    public class ContactHelper : HelperBase
    {
       
        protected bool acceptNextAlert = true;
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
           
        }

        public ContactHelper Create(NameData contact)
        {
            manager.Navigator.GoToPageAddContact();

            FillContact(contact);
            SubmitContact();
            GoToHomePage();
            return this;
      
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToContactPage();
            
            SelectContact(p);
            RemoveContact();
            driver.SwitchTo().Alert().Accept();

            //GoToHomePage();
            return this;

        }

        public ContactHelper Modify(int p, NameData newData)
        {
            manager.Navigator.GoToContactPage();
            // выбрать контакт
              SelectContact(p);
                // нажать  Edit
             InitContactModification(p);
             FillContact(newData);
            //нажать update
            SubmitContactModification();
            
            GoToHomePage();
            return this;

        }

        public ContactHelper FillContact(NameData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("firstname"), contact.NickName);
            Type(By.Name("middlename"), contact.Photo);
            Type(By.Name("lastname"), contact.Title);
            Type(By.Name("firstname"), contact.Company);
            Type(By.Name("middlename"), contact.Address);
            Type(By.Name("lastname"), contact.Thome);
            Type(By.Name("firstname"), contact.Tmobile);
            Type(By.Name("middlename"), contact.Twork);
            Type(By.Name("lastname"), contact.Tfax);
            Type(By.Name("firstname"), contact.Email1);
            Type(By.Name("middlename"), contact.Email2);
            Type(By.Name("lastname"), contact.Email3);
            Type(By.Name("firstname"), contact.HomePage);
            Type(By.Name("middlename"), contact.Bday);
            Type(By.Name("lastname"), contact.Bmonth);
            Type(By.Name("firstname"), contact.Byears);
            Type(By.Name("middlename"), contact.Aday);
            Type(By.Name("lastname"), contact.Amonth);
            Type(By.Name("firstname"), contact.Ayears);
            Type(By.Name("middlename"), contact.Group);
            Type(By.Name("lastname"), contact.SecAddress);
            Type(By.Name("middlename"), contact.SecHome);
            Type(By.Name("lastname"), contact.SecNotes);
            return this;
        }

        public bool IsContactPresent()
        {
            return IsElementPresent(By.XPath("//tr[@class = 'odd' or @name = 'entry']"));
        }
        public ContactHelper SelectContact(int index)
        {
            //driver.FindElement(By.Id("" +(index+1)+"")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            //driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index) + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache =null;
            return this;
        }

        public ContactHelper GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        

        public ContactHelper RemoveContact()
        {
            //driver.FindElement(By.Name("delete")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache =null;
            return this;
        }
        

        public ContactHelper InitContactModification(int index)
        {

           // driver.FindElement(By.XPath("(//form[@name='MainForm']//img[@title='Edit'])[" + (index+1) + "]")).Click();
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache =null;
            return this;
        }



        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        private List<NameData> contactCache = null;
        public List<NameData> GetContactList()
        {
            if (contactCache == null)
            { contactCache =  new List<NameData>();
                manager.Navigator.GoToContactPage();
                // собираем имя и фамилию из таблицы.


                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@class = 'odd' or @name = 'entry']"));
                int count = 0;
                foreach (IWebElement element in elements)
                {
                    count++;
                    
                 
                    //contactCache.Add(new NameData(element.FindElement(By.XPath("//tr[@class = 'odd' or @name = 'entry'][" + (count) + "]//td[2]")).Text,
                    //element.FindElement(By.XPath("//tr[@class = 'odd' or @name = 'entry'][" + (count) + "]//td[3]")).Text));
                    contactCache.Add(
                    new NameData(element.FindElement(By.XPath("//tr[@class = 'odd' or @name = 'entry'][" + count + "]//td[2]")).Text,
                    element.FindElement(By.XPath("//tr[@class = 'odd' or @name = 'entry'][" + count + "]//td[3]")).Text){ 
                         Id=element.FindElement(By.TagName("input")).GetAttribute("value")});
                }

            }

            return new List<NameData>(contactCache);

        }

        public int GetContactCount()
        {
             return driver.FindElements(By.XPath("//tr[@class = 'odd' or @name = 'entry']")).Count;
        }

        public NameData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenPage();
             IList<IWebElement>  cells =driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhone = cells[5].Text;


            return new NameData(lastName, firstName)
            {
                
                Address = address,
                AllPhone= allPhone,
                AllEmail= allEmail,
            };

            
        }

        public NameData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenPage();
            InitContactModification(index);
            string firstName =driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new NameData(lastName, firstName)
            {
                Address = address,
                Thome = homePhone,
                Tmobile = mobilePhone,
                Twork = workPhone,
                Email1=email1,
                Email2=email2,
                Email3 =email3,
            };

            
        }
    }
}
