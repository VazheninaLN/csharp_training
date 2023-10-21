using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagerHelper : HelperBase
    {
        public ProjectManagerHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Create(ProjectData project)
        {
            InitProjectCreation();
            driver.FindElement(By.XPath("//input[@id='project-name']")).SendKeys(project.Name);
            SubmitProjectCreation();

        }


        public ProjectManagerHelper InitProjectCreation()
        {
            
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            
            return this;
        }
        public ProjectManagerHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            return this;
        }
        //public List<ProjectData> GetProjects()
        //{
            //List<ProjectData> projects = new List<ProjectData>();
            //manager.Navigator.GoToControlPanel();
            //.Navigator.GoToProjectControlPanel();
           // ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tbody//tr//a"));
            //foreach (IWebElement element in elements)
            //{
            //    projects.Add(new ProjectData(element.Text));
           // }

            //return projects;

       // }

        public void Remove()
        {
            GoToProject();
            InitRemoveProject();
            SubmitRemoveProject();

        }

        public void GoToProject()
        {
            driver.FindElement(By.XPath("(//tbody//tr//td//a)[1]")).Click();
        }
        public void InitRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value = 'Удалить проект']")).Click();
        }
        public void SubmitRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value = 'Удалить проект']")).Click();
        }

    }
}
