// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
using addressbook_web_test.tests;
using System.IO;

namespace addressbook_test_data_generators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            for (int i=0; i < count; i++)
            {
                writer.WriteLine(String.Format("${0}", "${1}", "${2}",
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(100),
                    TestBase.GenerateRandomString(100) ));
            }
            writer.Close();
            
        }

     }
}