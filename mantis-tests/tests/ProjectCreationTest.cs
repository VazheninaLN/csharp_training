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
               
                ProjectData project = new ProjectData("test" + TestBase.GenerateRandomString(3));
                app.Navigator.GoToControlPanel();
                app.Navigator.GoToProjectControlPanel();
                app.Project.Create(project);

               
            }
        }
    }
}
