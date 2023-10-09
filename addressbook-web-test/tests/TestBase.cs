using System;
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
        
        public static bool PERFORM_LONG_UI_CHECKS = true;
        public static bool PERFORM_LONG_UI_CHECKS_CONTACT = true;
        protected ApplicationManager app;


        [SetUp]
        protected void SetupApplicationManager()
        {
            //инициализация  ApplicationManager.первый уровень

            app = ApplicationManager.GetInstance();
           

        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
          
            int l= Convert.ToInt32(rnd.NextDouble()*max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i<l; i++)
            {
                builder.Append(Convert.ToChar(32 +Convert.ToInt32(rnd.NextDouble() *65)));
            }
            return builder.ToString(); 
        }

    }
}
