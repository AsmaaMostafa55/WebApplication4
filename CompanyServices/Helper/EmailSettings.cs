using CompanyData.Migrations;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CompanyServices.Helper
{
    public static class EmailSettings
    {
        public static void SendEmail(Email  input)
        {
            var client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl=false;
            client.Credentials = new NetworkCredential("asmaamostafaelsayed55@gmail.com","lagcddtaxfekbomj"); ;
            client.Send("asmaamostafaelsayed55@gmail.com", input.To, input.Subject, input.Body);
          

        }

    }

}
