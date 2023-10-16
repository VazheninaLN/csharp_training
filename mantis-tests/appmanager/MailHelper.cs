using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpaqueMail;

namespace mantis_tests
{
    public class MailHelper
    {
        public MailHelper(ApplicationManager manager) : base(manager) { }

        public String GetLastMail(AccountData account)
        {
            
            //int count =  pop3.GetMessageCount();
            for (int i = 0; i < 20; i++)
            {
                Pop3Client pop3 = new Pop3Client("localhost", 110, account.Name, account.Password, false);
                pop3.Connect();
                pop3.Authenticate();
                if (pop3.GetMessageCount()>0)
                {
                    ReadOnlyMailMassage massage = pop3.GetMassage(1);
                    return  massage.Body;
                }
                else
                { 
                    System.Threading.Thread.Sleep(3000);
                }
            }
            return null;
        }


    }
}
