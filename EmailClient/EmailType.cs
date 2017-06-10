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
            if (EmailTypeName.ToLower() == "google" || EmailTypeName.ToLower() == "gmail")
            { completeGoogle(); }

            else if (EmailTypeName.ToLower() == "outlook")
            {completeOutlook();}

            else if (EmailTypeName.ToLower() == "office365" || EmailTypeName.ToLower() == "office")
            { completeOffice365(); }

            else if (EmailTypeName.ToLower() == "yahoo")
            { completeYahoo(); }
                
            else if (EmailTypeName.ToLower() == "hotmail")
            { completeHotmail(); }
   
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

        #region AutoComplete Settings

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

        private void completeOutlook()
        {
            name = "Outlook";
            recievePort = 995;
            recieveServer = "pop3.live.com";
            recieveSSL = true;
            sendPort = 587;
            sendServer = "smtp.live.com";
            sendSSL = false;
        }//end completeOutlook

        private void completeOffice365()
        {
            name = "Office365";
            recievePort = 995;
            recieveServer = "outlook.office365.com";
            recieveSSL = true;
            sendPort = 587;
            sendServer = "smtp.office365.com";
            sendSSL = false;
        }//end completeOffice365

        private void completeYahoo()
        {
            name = "Yahoo";
            recievePort = 995;
            recieveServer = "pop.mail.yahoo.com";
            recieveSSL = true;
            sendPort = 465;
            sendServer = "smtp.mail.yahoo.com";
            sendSSL = true;
        }//end completeYahoo

        //Yahoo Mail Plus
        //Yahoo UK
        //Yahoo Deutschland
        //Yahoo AU/NZ

        //O2
        //O2.uk
        //AOL.com
        //AT&T
        //NTL @ntlworld.com
        //BT Connect
        //BT Openworld
        //BT Internet
        //Orange
        //Orange.uk
        //Wanadoo UK

        private void completeHotmail()
        {
            name = "Hotmail";
            recievePort = 995;
            recieveServer = "pop3.live.com";
            recieveSSL = true;
            sendPort = 465;
            sendServer = "smtp.live.com";
            sendSSL = true;
        }//end completeOutlook


        //list from:
        //https://www.arclab.com/en/kb/email/list-of-smtp-and-pop3-servers-mailserver-list.html

        #endregion

    }//end class
}//end namespace