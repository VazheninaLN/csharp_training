using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace addressbook_web_test.model
{
    public class NameData : IEquatable<NameData>, IComparable<NameData>
    {
        //private string firstname;
        //private string middlename = "";
        //private string lastname = "";

        public NameData(string firstname)
        {
            FirstName = firstname;

        }
        public NameData(string firstname, string middlename, string lastname)
        {
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
        }
        public NameData(string firstname, string lastname)
        {
            FirstName = firstname;
            //MiddleName = middlename;
            LastName = lastname;
        }
        public NameData(string firstname,
                string middlename,
                string lastname,
                string nickname,
                string photo,
                string title,
                string company,
                string address,
                string thome,string tmobile,string twork ,string tfax,
                string email1, string email2,string email3,
                string homepage,
                string bday,string bmonth, string byears,
                string aday, string amonth, string ayears,
                string group,
                string secaddress, string sechome,string secnotes)
        {
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            NickName =nickname;
            Photo  = photo;
            Title=title;
            Company = company;
            Address =address;
            Thome = thome;
            Tmobile =tmobile;
            Twork = twork;
            Tfax= tfax;
            Email1  = email1;
            Email2  = email2;
            Email3= email3;
            HomePage  = homepage;
            Bday  =bday;
            Bmonth = bmonth;
            Byears = byears;
            Aday = aday;
            Amonth =amonth;
            Ayears =ayears;
            Group = group;
            SecAddress=secaddress;
            SecHome = sechome;
            SecNotes =secnotes;
    }
       

        public bool Equals(NameData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }
            if (Object.ReferenceEquals(this, other))
            { return true; }
           
            return LastName==other.LastName && FirstName==other.FirstName;
           
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() + FirstName.GetHashCode() ;

        }
           

        public override string ToString()
        {
            return "Lastname/FirstName=" + LastName +  FirstName;
            
        }


        public int CompareTo (NameData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) == 0)
            {
                if (FirstName.CompareTo(other.FirstName) == 1)
                {
                    return 1;
                }
                if (FirstName.CompareTo(other.FirstName) == -1)
                {
                    return -1;
                }
                if (FirstName.CompareTo(other.FirstName) == 0)
                {
                    return 0;
                }
                return FirstName.CompareTo(other.FirstName);
            }
            else
            {
                return -1;
            }
        }
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
       
        public string LastName { get; set; }
        public string  NickName{ get; set; }
        public string  Photo{ get; set; }

        public string Title { get; set; }

        public string Company { get; set; }
        public string Address { get; set; }

        public string  Thome{ get; set; }

        public string Tmobile { get; set; }


        public string Twork { get; set; }

        public string Tfax { get; set; }

        public string Email1 { get; set; }
        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string HomePage { get; set; }


        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byears { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayears { get; set; }

        public string Group { get; set; }
        public string SecAddress { get; set; }
        public string SecHome { get; set; }
        public string SecNotes { get; set; }



    }

}

