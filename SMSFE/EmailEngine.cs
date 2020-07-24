using log4net;
using log4net.Config;
using log4net.Repository;
using Rebex.Mime;
using Rebex.Net;
using SMSFE.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SMSFE
{
    class EmailEngine
    {

        private static ILog Log;
        public EmailEngine() 
        {
             Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        public void SendEmail(Cola_Envio_Mail email) 
        {

            try { 
            string sender = email.From;
            string recipient = email.To;
            string subject = email.Subject;
            string body = email.Body;
            //MimeMessage message = new MimeMessage();

                // create SMTP client instance
                using (var smtp = new Rebex.Net.Smtp())
                {
                    // connect to Gmail SMTP server
                    smtp.Connect("smtp.gmail.com", SslMode.Explicit);
                    // authenticate with your email address and password
                    smtp.Login(sender, Program.Configuration.GetSection("EmailConfig").GetSection("SenderPassword").Value);
                    // send mail
                    smtp.Send(sender, recipient, subject, body);
                    // disconnect (not required, but polite)
                    smtp.Disconnect();
                    Log.Info("Email Sent from:" + sender + " to:" + recipient);
                }
               
            }
            catch (Exception ex)
            {
                Log.Error("Error Sending Email:"+ex.Message);
            }
        }
    }
}
