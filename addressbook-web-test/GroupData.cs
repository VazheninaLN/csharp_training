﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test
{
    class GroupData
    {
        private string name;
        private string header =  "";
        private string footer = "";


        public GroupData(string name)
        {
            this.name = name;
            
        }
        public GroupData (string name,string header, string footer)
        {
          this.name = name;
            this.header = header;
            this.footer= footer;
        }
        public string name
        {
            get
            {
                return name;
            }

            set { name=value; }
        }
        public string header
        {
            get
            {
                return header;
            }

            set { header=value; }
        }
        public string footer
        {
            get
            {
                return footer;
            }

            set { footer=value; }
        }
    }
}
