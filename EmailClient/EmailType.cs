using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
    class EmailType
    {
        //class to store email info needed for sending/recieving
        public EmailType(string EmailTypeName, int recPort, string recServer, bool recSSL, int sndPort, string sndServer, bool sndSSL)
        {
            name = EmailTypeName;
            recievePort = recPort;
            recieveServer = recServer;
            recieveSSL = recSSL;
            sendPort = sndPort;
            sendServer = sndServer;
            sendSSL = sndSSL;
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

        private bool recieveSSL;

        public bool RecieveSSL
        {
            get { return recieveSSL; }
            set { recieveSSL = value; }
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

        private bool sendSSL;

        public bool SendSSL
        {
            get { return sendSSL; }
            set { sendSSL = value; }
        }

        #endregion

        private void completeGuess(string nm)
        {
            name = nm;
            recievePort = 995;
            recieveServer = "pop."+ nm +".com";
            recieveSSL = true;
            sendPort = 465;
            sendServer = "smtp."+ nm +".com";
            sendSSL = true;
        }//end completeGuess

        private void completeGoogle()
        { 
        name = "Google";
        recievePort = 995;
        recieveServer = "pop.gmail.com";
        recieveSSL = true;
        sendPort = 465;
        sendServer = "smtp.gmail.com";
        sendSSL = true;
        }//end completeGoogle








    }//end class
}//end namespace