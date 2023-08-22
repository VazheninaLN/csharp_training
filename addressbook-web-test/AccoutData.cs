using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test
{
    class AccoutData
    {
        private string Username = "";
        private string Password = "";
        
        public AccoutData(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public string Username
        {
            get
            {
                return Username;
            }
            set
            {
                Username=value;
            }
        }
        public string Password
        {
            get
            {
                return Password;
            }
            set
            {
                Password =value;
            }
        }
    

    }
}
