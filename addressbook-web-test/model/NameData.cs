using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Dynamic;
using LinqToDB.Mapping;
using LinqToDB.Linq.Builder;

namespace addressbook_web_test.model
{
    [Table(Name = "addressbook")]
    public class NameData : IEquatable<NameData>, IComparable<NameData>
    {

        //private string firstname;
        public string allPhone;
        public string allEmail;
        public string allDetals = null;

        public string allNameInfo;
        public string allPhoneInfo;
        public string allEmailInfo;
        public string allSecInfo;
        public string allInfo;



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
        public NameData(string lastname, string firstname)
        {
            FirstName = firstname;
            //MiddleName = middlename;
            LastName = lastname;
        }
        //public NameData(){ }
        public NameData()
        {
            //AllNameInfo=allNameInfo;
            //AllInfo =allInfo;
            //AllPhoneInfo =allPhoneInfo;
            //AllEmailInfo = allEmailInfo;
            //AllSecInfo =allSecInfo;
            AllDetals =allDetals;
        }

        public NameData(string firstname,
                string middlename,
                string lastname,
                string nickname,
                string photo,
                string title,
                string company,
                string address,
                string thome, string tmobile, string twork, string tfax,
                string email1, string email2, string email3,
                string homepage,
                string bday, string bmonth, string byears,
                string aday, string amonth, string ayears,
                string group,
                string secaddress, string sechome, string secnotes)
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
            return LastName.GetHashCode() + FirstName.GetHashCode();

        }


        public override string ToString()
        {
            return "Lastname/FirstName=" + LastName +  FirstName;

        }


        public int CompareTo(NameData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            else
            {
                //return -1;
                return LastName.CompareTo(other.LastName);
            }
        }
        public static List<NameData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "middlename")]
        public string MiddleName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        public string Photo { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]

        public string Company { get; set; }

        public string Address { get; set; }

        public string Thome { get; set; }

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
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
        public string AllPhone
        {
            get
            {
                if (allPhone != null)
                {
                    return allPhone;
                }
                else
                {
                    return (CleanUp(Thome) + CleanUp(Tmobile) + CleanUp(Twork)).Trim();
                }
            }
            set
            {
                allPhone =value;
            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUp(Email1) + CleanUp(Email2) +CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmail =value;
            }
        }
        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()-]", "") + "\r\n";

        }
        public string AllNameInfo
        {
            get
            {
                if (allNameInfo != null)
                {
                    return allNameInfo;
                }
                else
                {

                    if (FirstName != null && FirstName != "") { allNameInfo += FirstName; }
                    if (MiddleName != null && MiddleName != "") { allNameInfo += " " + MiddleName; }
                    if (LastName != null && LastName != "") { allNameInfo +=  " " +LastName; }
                    if (NickName != null && NickName != "") { allNameInfo += "\r\n" + NickName; }

                    return allNameInfo;
                }
            }
            set
            {
                allNameInfo =value;
            }
        }

        public string AllPhoneInfo
        {
            get
            {
                if (allPhoneInfo != null)
                {
                    return allPhoneInfo;
                }
                else
                {

                    if (Thome != null && Thome != "") { allPhoneInfo +="H: " + Thome +"\r\n"; }
                    if (Tmobile != null && Tmobile != "") { allPhoneInfo += "M: " + Tmobile +"\r\n"; }
                    if (Twork != null && Twork != "") { allPhoneInfo +=  "W: " + Twork + "\r\n"; }
                    if (Tfax != null && Tfax != "") { allPhoneInfo +=  "F: " + Tfax + "\r\n"; }

                    return allPhoneInfo;
                }
            }
            set
            {
                allPhoneInfo =value;
            }
        }

        public string AllEmailInfo
        {
            get
            {
                if (allEmailInfo != null)
                {
                    return allEmailInfo;
                }
                else
                {

                    if (Email1 != null && Email1 != "") { allEmailInfo +=Email1 +"\r\n"; }
                    if (Email2 != null && Email2 != "") { allEmailInfo += Email2 +  "\r\n"; }
                    if (Email3 != null && Email3 != "") { allEmailInfo += Email3 + "\r\n"; }
                    if (HomePage != null && HomePage != "") { allEmailInfo +=  "Homepage:\r\n" + HomePage +"\r\n"; }
                    return allEmailInfo;
                }
            }
            set
            {
                allEmailInfo =value;
            }
        }

        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                else
                {
                    if (Title != null && Title != "") { allInfo += Title +  "\r\n"; }
                    if (Company != null && Company != "") { allInfo +=  Company +"\r\n"; }
                    if (Address != null && Address != "") { allInfo +=  Address +"\r\n"; }

                    return allInfo;
                }

            }
            set
            {
                allInfo =value;
            }
        }
        public string AllSecInfo
        {
            get
            {
                if (allSecInfo != null)
                {
                    return allSecInfo;
                }
                else
                {
                    if (SecAddress != null && SecAddress != "") { allSecInfo +=SecAddress; }
                    if (SecHome  != null && SecHome  != "") { allSecInfo += "\r\n\r\n" + "P: " + SecHome; }
                    if (SecNotes != null && SecNotes != "") { allSecInfo += "\r\n\r\n" + SecNotes; }
                    return allSecInfo;
                }

            }
            set
            {
                allSecInfo =value;
            }
        }


        public string AllDetals
        {
            get
            {
                if (allDetals == null)
                {
                    if (AllNameInfo!= null && AllNameInfo != "") { allDetals += AllNameInfo;}
                    if (AllInfo!= null && AllInfo != "") { allDetals += "\r\n" + AllInfo; }
                    if (AllPhoneInfo!= null && AllPhoneInfo != "") { allDetals += "\r\n" + AllPhoneInfo; }
                    if (AllEmailInfo!= null && AllEmailInfo != "") { allDetals += "\r\n" + AllEmailInfo; }
                    if (AllSecInfo!= null && AllSecInfo != "") { allDetals += "\r\n\r\n" + AllSecInfo; }

                    //return Regex.Replace(allDetals, "\r\n", "");
                    return allDetals;
                }

                //return Regex.Replace(allDetals, "\r\n", "");
                return allDetals;

            }
            set
            {
                allDetals =value;
            }


        }
    }



}
     

