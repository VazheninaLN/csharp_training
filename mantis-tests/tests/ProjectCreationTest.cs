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
                List<ProjectData> oldpProjects = new List<ProjectData>();
                oldpProjects = app.api.GetProjects();

                ProjectData project = new ProjectData("test" + TestBase.GenerateRandomString(10));


                app.Navigator.GoToControlPanel();
                app.Navigator.GoToProjectControlPanel();
                app.Project.Create(project);


                List<ProjectData> newProjects = app.api.GetProjects();

              
                Assert.AreEqual(oldpProjects.Count+1, newProjects.Count);

            }
        }
    }
}
