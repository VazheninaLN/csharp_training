﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test.appmanager;
using addressbook_web_test.model;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_test.tests
{
    public class TestBase
    {
        

        protected ApplicationManager app;


        [SetUp]
        protected void SetupApplicationManager()
        {
            //инициализация  ApplicationManager.первый уровень

            app = ApplicationManager.GetInstance();
           

        }

    }
}
