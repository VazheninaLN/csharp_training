using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<ProjectData> GetProjects()
        {
            
            List<ProjectData> projects = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            Mantis.ProjectData[] projectsMantis = client.mc_projects_get_user_accessible("administrator", "root");
            
            foreach (Mantis.ProjectData proj in projectsMantis)
            {
                projects.Add(new ProjectData(proj.name)
                {
                    Id = proj.id,
                    Description = proj.description
                });
            }
            return projects;
        }
        public void CreateProject()
        {
          

            Mantis.ProjectData projectMantis = new Mantis.ProjectData();
            projectMantis.name = "Project" + TestBase.GenerateRandomString(10);


            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            client.mc_project_add("administrator", "root", projectMantis);
        }
    }
}