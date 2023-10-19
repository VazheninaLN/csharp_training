﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    
        public class LoginHelper : HelperBase
        {
            public LoginHelper(ApplicationManager manager) : base(manager)
            {

            }

            public void Login(AccountData account)
            {
                if (IsLoggedIn())
                {
                    if (IsLoggedIn(account))
                    {
                        return;
                    }
                    Logout();
                }
                Type(By.Name("administrator"), account.Name);
                Type(By.Name("root"), account.Password);
                driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
            }

            public bool IsLoggedIn()
            {
                return IsElementPresent(By.XPath("//a[@id='logout-link']"));
            }
            public bool IsLoggedIn(AccountData account)
            {
                return IsLoggedIn() &&
                    GetLoggetUsername() == account.Name;
            }
            public string GetLoggetUsername()
            {
                string text = driver.FindElement(By.XPath("//span[@id='logged-in-user']")).Text;
                return text;
            }
            public void Logout()
            {
                if (IsLoggedIn())
                {
                    driver.FindElement(By.XPath("//a[@id='logout-link']")).Click();
                }

            }

        }

    
}
