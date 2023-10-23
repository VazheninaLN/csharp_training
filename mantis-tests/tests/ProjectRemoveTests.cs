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
        public class ProjectRemovingTests : AuthTestBase
        {
            [Test]
            public void ProjectRemovingTest()
            {

                List<ProjectData> oldProjects = new List<ProjectData>();
                oldProjects = app.api.GetProjects();


                if (oldProjects.Count == 0)
                {
                   
                    app.api.CreateProject();
                    oldProjects = app.api.GetProjects();
                }

                app.Navigator.GoToControlPanel();
                app.Navigator.GoToProjectControlPanel();
                app.Project.Remove();

                List<ProjectData> newProjects = app.api.GetProjects();
                Assert.AreEqual(oldProjects.Count()-1, newProjects.Count());

            }
        }
    }
}
