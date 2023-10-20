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
               

                app.Navigator.GoToControlPanel();
                app.Navigator.GoToProjectControlPanel();
                app.Project.Remove();
               
            }
        }
    }
}
