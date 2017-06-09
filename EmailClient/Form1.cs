using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using OpenPop;
using OpenPop.Common;
using OpenPop.Common.Logging;
using OpenPop.Mime;
using OpenPop.Mime.Decode;
using OpenPop.Mime.Header;
using OpenPop.Pop3;

using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace EmailClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubEmail_Click(object sender, EventArgs e)
        {
            ETest();
        }


        static void ETest()
        {
            var client = new OpenPop.Pop3.Pop3Client(); //new POPClient();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate("user", "pass");
            var count = client.GetMessageCount();
            OpenPop.Mime.Message message = client.GetMessage(count);
            Console.WriteLine(message.Headers.Subject);
        }//end etest

    }//end class
}//end namespace
