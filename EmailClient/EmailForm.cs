using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenPop.Mime.Header;

namespace EmailClient
{
    public partial class EmailForm : Form
    {
        public EmailForm(int id)
        {
            InitializeComponent();
            ea = DBHandler.GetFullEmailAccount(id);
            this.Text = ea.Address;
            et = new EmailType(ea.Type);
            popGrid();
        }

        private EmailAccount ea;
        private EmailType et;

        private List<OpenPop.Mime.Message> list;
        List<OpenPop.Mime.Header.MessageHeader> headList;

        private void popGrid()
        {
            var source = new BindingSource();
            list = MailHandler.FetchAllMessages(et, ea.Address, ea.Password);
            //source.DataSource = list;

            headList = new List<MessageHeader>(); //list.Headers;

            for (int i = 0; i < list.Count; i++)
            {
                headList.Add(list[i].Headers);
            }//end for

            source.DataSource = headList;

            dataGridEmList.DataSource = source;
        }//end popGrid


    }//end class
}//end namespace