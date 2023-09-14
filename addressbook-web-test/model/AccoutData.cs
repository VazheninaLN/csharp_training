using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace addressbook_web_test.model
{
    public class AccoutData 
    {
        private string username;
        private string password;

        public AccoutData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }



        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


    }
}
