using System;
using System.Collections.Generic;
using System.Text;

//using OpenPop;//
//using OpenPop.Common;//
//using OpenPop.Common.Logging;//
using OpenPop.Mime;
//using OpenPop.Mime.Decode;//
using OpenPop.Mime.Header;
using OpenPop.Pop3;

//using System.IO;//
//using System.Net.Security;//
//using System.Security.Cryptography.X509Certificates;//

namespace EmailClient
{
    class MailHandler
    {


        public static List<Message> FetchAllMessages(EmailType et, string username, string password)//string hostname, int port, bool useSsl, string username, string password)
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(et.RecieveServer, et.RecievePort, et.RecieveSSL);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // Get the number of messages in the inbox
                int messageCount = client.GetMessageCount();

                // We want to download all messages
                List<Message> allMessages = new List<Message>(messageCount);

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number
                for (int i = messageCount; i > 0; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                }

                client.Reset();
                client.Disconnect();
                client.Dispose();

                // Now return the fetched messages
                return allMessages;

            }//end using
        }//end FetchAllMessages



    }//end class
}//end namespace
