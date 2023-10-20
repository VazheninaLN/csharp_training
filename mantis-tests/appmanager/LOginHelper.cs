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
                
               Type(By.Name("username"), account.Name);
               driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
               Type(By.Name("password"), account.Password);
               driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            }

           

        }

    
}
