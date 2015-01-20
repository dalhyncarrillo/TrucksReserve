// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Net.Mail;
using System.Threading;

namespace ToolsLibrary
{
    public class SmtpMailSend
    {
        private class MailThreadParams
        {
            public SmtpClient Client { get; set; }
            public MailMessage Message { get; set; }
        }

        private SmtpClient client;
        private static object sendingMail = new object();

        public SmtpMailSend(bool sendMailViaSSl = false)
        {
            try
            {
                client = new SmtpClient();
                PostInitClient(sendMailViaSSl);
            }
            catch (Exception ex)
            {
                string errMessage = "Could not initialize SMTP client.";
                Tools.NewToolsException(errMessage + Environment.NewLine + ex.ToString());
            }
        }

        public SmtpMailSend(string smtpServer, bool sendMailViaSSl = false)
        {
            smtpServer.ExcIfNullOrEmpty();

            try
            {
                client = new SmtpClient(smtpServer);
                PostInitClient(sendMailViaSSl);
            }
            catch (Exception ex)
            {
                string errMessage = "Could not initialize SMTP client.";
                Tools.NewToolsException(errMessage + Environment.NewLine + ex.ToString());
            }
        }

        public SmtpMailSend(string smtpServer, Int32 port, bool sendMailViaSSl = false)
        {
            smtpServer.ExcIfNullOrEmpty();
            if (port <= 0) { Tools.NewToolsException("port is <= 0."); }

            try
            {
                client = new SmtpClient(smtpServer, port);
                PostInitClient(sendMailViaSSl);
            }
            catch (Exception ex)
            {
                string errMessage = "Could not initialize SMTP client.";
                Tools.NewToolsException(errMessage + Environment.NewLine + ex.ToString());
            }
        }

        /// <summary>
        /// Additionally configures the SMTP client after it is created.
        /// </summary>
        private void PostInitClient(bool sendMailViaSSl)
        {
            client.ExcIfNull();
            client.EnableSsl = sendMailViaSSl;
        }

        /// <summary>
        /// Sends message to receiver
        /// </summary>
        public void Send(string receiverMail, string bodyText, string subject)
        {
            receiverMail.ExcIfNullOrEmpty();
            bodyText.ExcIfNullOrEmpty();
            subject.ExcIfNullOrEmpty();
            client.ExcIfNull();

            MailMessage message = new MailMessage();

            string receiverAddress = receiverMail;

            message.IsBodyHtml = true;

            message.Body = bodyText;
            message.Subject = subject;
            message.To.Add(receiverAddress);

            try
            {
                ParameterizedThreadStart sendingThreadStart = new ParameterizedThreadStart(SendThreadProc);
                Thread sendingThread = new Thread(sendingThreadStart);
                MailThreadParams sendingThreadParams = new MailThreadParams();

                sendingThreadParams.Client = client;
                sendingThreadParams.Message = message;

                sendingThread.Start(sendingThreadParams);
            }
            catch (Exception ex)
            {
                // Do not include the message body, because it may contain a password.
                string errMsg = string.Format("Could not send email To : '{0}'.", receiverMail);
                Tools.NewToolsException(errMsg + Environment.NewLine + ex);
            }
        }

        private void SendThreadProc(object threadParams)
        {
            try
            {
                lock (sendingMail)
                {
                    MailThreadParams mailParams = threadParams as MailThreadParams;

                    if (mailParams == null)
                    {
                        string msg = string.Format(
                            "threadParams argument must be of type \"{0}\". Actual type passed: \"{1}\".",
                            typeof(MailThreadParams).FullName,
                            threadParams != null ? threadParams.GetType().FullName : "null");
                        Tools.NewToolsException(msg);
                    }
                    if (mailParams.Client == null) { Tools.NewToolsException("No Client."); }
                    if (mailParams.Message == null) { Tools.NewToolsException("No Message."); }

                    try
                    {
                        client.Send(mailParams.Message);
                    }
                    finally
                    {
                        mailParams.Message.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }


}
