using System;
using System.Collections.Generic;
using System.Text;

//using OpenPop;
//using OpenPop.Common;
//using OpenPop.Common.Logging;
using OpenPop.Mime;
//using OpenPop.Mime.Decode;
using OpenPop.Mime.Header;
using OpenPop.Pop3;

//using System.IO;
//using System.Net.Security;
//using System.Security.Cryptography.X509Certificates;

namespace EmailClient
{
    class MailHandler
    {

        public void testFunction(EmailType e, string addr, string pass)
        {

            var client = new OpenPop.Pop3.Pop3Client(); //new POPClient();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate(addr, pass);
            var count = client.GetMessageCount();
            OpenPop.Mime.Message message = client.GetMessage(count);
            Console.WriteLine(message.Headers.Subject.ToString());
            Console.WriteLine(message.MessagePart.Body.ToString());

        }//end testFunction


        public static List<Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

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

                // Now return the fetched messages
                return allMessages;

            }//end using
        }//end FetchAllMessages



    }//end class
}//end namespace
