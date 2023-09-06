using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace addressbook_web_test.model
{
    public class NameData
    {
        private string firstname;
        private string middlename = "";
        private string lastname = "";

        public NameData(string firstname)
        {
            this.firstname = firstname;

        }
        public NameData(string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
        }
        public string FirstName
        {
            get
            {
                return firstname;
            }

            set { firstname = value; }
        }
        public string MiddleName
        {
            get
            {
                return middlename;
            }

            set { middlename = value; }
        }
        public string LastName
        {
            get
            {
                return lastname;
            }

            set { lastname = value; }
        }
    }

}

