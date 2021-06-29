using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using NotificationNamespace;

namespace NetworkNamespace
{
    static class Network
    {
        public static void net(Notification notification)
        {

            SmtpClient cv = new SmtpClient("smtp.gmail.com", 587);
            cv.EnableSsl = true;
            cv.Credentials = new NetworkCredential("Here your gmail", "Here your gmail password");
            try
            {
                cv.Send("Here your gmail", " Whom you want to send(gmail)", " New Notification", $"{notification.Text} DateTime:{notification.NotificationTime}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}

