using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    internal class ProjectRemoveTests
    {
        [TestFixture]
        public class ProjectRemovingTests : TestBase
        {
            [Test]
            public void ProjectRemovingTest()
            {
                List<ProjectData> projects = new List<ProjectData>();
                projects = app.Project.GetProjects();

                if (projects.Count == 0)
                {
                    ProjectData newProject = new ProjectData("test" + TestBase.GenerateRandomString(3));
                    app.Navigator.GoToControlPanel();
                    app.Navigator.GoToProjectControlPanel();
                    app.Project.Create(newProject);
                    projects = app.Project.GetProjects();
                }
                app.Navigator.GoToControlPanel();
                app.Navigator.GoToProjectControlPanel();
                app.Project.Remove();
               
            }
        }
    }
}
