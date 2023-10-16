using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
   public class RegistrationHelper :HelperBase
    {
        public RegistrationHelper (ApplicationManager manager) : base (manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegastrationForm();
            FillRegastrationForm(account);
            SubmitRegastration();
            string url = GetConfimationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillPasswordForm(string url , AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private string GetConfimationUrl(AccountData account)
        {
            string massage = manager.Mail.GetLastMail(account);
            Match match  =Regex.Match(massage, @"http://\S*");
            return match.Value;
        }

        private void OpenRegastrationForm()
        {
            driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

        private void SubmitRegastration()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillRegastrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-1.3.20/login_page.php";
        }
    }
}
