using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    
        public class AuthTestBase : TestBase
        {
            [SetUp]
            public void SetupLogin()
            //второй уровень базового класса. выполняется логин
            {
                app.Auth.Login(new AccountData("administrator", "root"));
            }
        }
    
}
