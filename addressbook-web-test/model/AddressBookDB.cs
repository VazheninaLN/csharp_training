using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using OpenQA.Selenium.DevTools.V113.Database;

namespace addressbook_web_test.model
{
    public class AddressBookDB :LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBookDB") { }

        public ITable<GroupData> Groups { get { return this.GetTable<GroupData>(); } }
        public ITable<NameData> Contacts { get { return this.GetTable<NameData>(); } }

        public ITable<GroupContactRelation> GCR { get { return this.GetTable<GroupContactRelation>(); } }
    }
}
