using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class ProjectCreationTest 
    {
        [TestFixture]
        public class ProjectCreationTests : AuthTestBase
        {
            [Test]
            public void ProjectCreationTest()
            {
                List<ProjectData> projects = new List<ProjectData>();
                projects = app.api.GetProjects();

                ProjectData project = new ProjectData("test" + TestBase.GenerateRandomString(10));


                app.Navigator.GoToControlPanel();
                app.Navigator.GoToProjectControlPanel();
                app.Project.Create(project);


                List<ProjectData> newProjects = app.api.GetProjects();

                projects.Add(project);
                projects.Sort();
                newProjects.Sort();
                Assert.AreEqual(projects, newProjects);

            }
        }
    }
}
