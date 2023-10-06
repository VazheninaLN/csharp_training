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
using addressbook_web_test.model;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel =Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;

namespace addressbook_test_data_generators
{
    internal class Program
    {
        static void Main(string[] args)
        // количество+имя файла+ формат файла(xml/json) + тип(contact/group)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string typeFormat = args[3];
            string format = args[2];
            List <GroupData>  groups = new List<GroupData> ();
            List<NameData> contacts  = new List<NameData>();
            if (typeFormat == "group")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header= TestBase.GenerateRandomString(100),
                        Footer= TestBase.GenerateRandomString(100)

                    });
                }
            }
            else if (typeFormat == "contact")
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new NameData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        MiddleName = TestBase.GenerateRandomString(10),
                        NickName = TestBase.GenerateRandomString(10),
                    });
                }
            }
               
            
            if (format == "excel")
            {
                writeGroupsToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);

                if (format == "csv")
                { writeGroupsToCsvFile(groups, writer); }
                else if (format == "xml")
                { 
                  if (typeFormat == "group") { writeGroupsToXmlFile(groups, writer); }
                  if (typeFormat == "contact") {writeContactsToXmlFile(contacts, writer); }
                }
                else if (format == "json")
                {
                  if (typeFormat == "group") { writeGroupsToJsonFile(groups, writer); }
                  if (typeFormat == "contact") { writeContactsToJsonFile(contacts, writer); }
                }
                else
                { System.Console.Out.Write("Unrecognized format" + format); }

                writer.Close();
            }
        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app =new Excel.Application();
            app.Visible = true;
             Excel.Workbook wb =app.Workbooks.Add();
            Excel.Worksheet sheet =  wb.ActiveSheet;
            int row = 1;
            foreach (GroupData group in groups)
            {

                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);  
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups,StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0}", "${1}", "${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
             new XmlSerializer (typeof(List<GroupData>)).Serialize(writer, groups);
            
        }
        static void writeContactsToXmlFile(List<NameData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<NameData>)).Serialize(writer, contacts);

        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups,Newtonsoft.Json.Formatting.Indented));

        }
        static void writeContactsToJsonFile(List<NameData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));

        }


    }
}