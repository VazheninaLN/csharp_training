﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_test.model;
using NUnit.Framework;

namespace addressbook_web_test.tests
{
    [TestFixture]
    public class GroupModificationTests :TestBase
    {
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Group6");
            newData.Header = "Header6";
            newData.Footer = "Footer6";

            app.Groups.Modify(1, newData);


        }
    }
}
