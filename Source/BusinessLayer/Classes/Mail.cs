// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Text;

using BusinessLayer.Instruments;
using ToolsLibrary;

namespace BusinessLayer.Classes
{
    public class Mail
    {
        public static string SiteContactMail = string.Empty;
        public static bool SendMailViaSSL = false;

        public static void SendMessageToSite(string fromEmail, string text)
        {
            SiteContactMail.ExcIfNullOrEmpty();
            if (SiteContactMail.IsValidEmailAddress() == false) { BTools.NewBException("Invalid SiteContactMail"); }

            fromEmail.ExcIfNullOrEmpty();

            text = text.GetTrimmed();
            text.ExcIfNullOrEmpty();
            text = text.Replace(Environment.NewLine, "<br/>");

            StringBuilder messageBody = new StringBuilder();

            messageBody.Append(string.Format("От : {0}{1}", fromEmail, "<br/>"));
            messageBody.Append(string.Format("{0}{1}"
                , "<hr/>"
                , text
                ));

            messageBody.Append(string.Format("{0}Това съобщение е пратено чрез формата за връзка в страницата за контакти."
                , "<hr/>"
                ));

            SmtpMailSend newMail = new SmtpMailSend(SendMailViaSSL);
            newMail.Send(SiteContactMail, messageBody.ToString(), "Съобщение от формата за контакт.");
        }
    }
}
