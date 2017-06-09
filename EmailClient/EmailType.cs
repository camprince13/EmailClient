using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
    class EmailType
    {
        //class to store email info needed for sending/recieving
        public EmailType(string EmailTypeName, int recPort, string recServer, int sndPort, string sndServer)
        {
            name = EmailTypeName;
            recievePort = recPort;
            recieveServer = recServer;
            sendPort = sndPort;
            sendServer = sndServer;
        }//end full constructor

        public EmailType(string EmailTypeName)
        {
            if (EmailTypeName.ToLower() == "google")
            { completeGoogle(); }

            else
            { completeGuess(EmailTypeName); }

        }//end auto-complete constructor

        #region main variables

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int recievePort;

        public int RecievePort
        {
            get { return recievePort; }
            set { recievePort = value; }
        }

        private string recieveServer;

        public string RecieveServer
        {
            get { return recieveServer; }
            set { recieveServer = value; }
        }

        private int sendPort;

        public int SendPort
        {
            get { return sendPort; }
            set { sendPort = value; }
        }

        private string sendServer;

        public string SendServer
        {
            get { return sendServer; }
            set { sendServer = value; }
        }

        #endregion

        private void completeGuess(string nm)
        {
            name = nm;
            recievePort = 995;
            recieveServer = "pop."+ nm +".com";
            sendPort = 465;
            sendServer = "smtp."+ nm +".com";
        }//end completeGuess

        private void completeGoogle()
        { 
        name = "Google";
        recievePort = 995;
        recieveServer = "pop.gmail.com";
        sendPort = 465;
        sendServer = "smtp.gmail.com";
        }//end completeGoogle








    }//end class
}//end namespace