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
            dataGridEmList.AutoGenerateColumns = false;
            ea = DBHandler.GetFullEmailAccount(id);
            this.Text = ea.Address;
            et = new EmailType(ea.Type);
            setupGrid();
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

        private void setupGrid()
        {
            dataGridEmList.AutoGenerateColumns = false;
            dataGridEmList.AllowUserToAddRows = false;
            dataGridEmList.AllowUserToDeleteRows = false;
            dataGridEmList.AllowUserToResizeRows = false;
            dataGridEmList.AllowUserToResizeColumns = false;
            dataGridEmList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridEmList.ReadOnly = true;

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.HeaderText = "ID";
            idColumn.DataPropertyName = "MessageId";

            DataGridViewTextBoxColumn subjectColumn = new DataGridViewTextBoxColumn();
            subjectColumn.HeaderText = "Subject";
            subjectColumn.DataPropertyName = "Subject";

            DataGridViewTextBoxColumn fromColumn = new DataGridViewTextBoxColumn();
            fromColumn.HeaderText = "From";
            fromColumn.DataPropertyName = "From";

            DataGridViewTextBoxColumn sentColumn = new DataGridViewTextBoxColumn();
            sentColumn.HeaderText = "Date Sent";
            sentColumn.DataPropertyName = "DateSent";

            DataGridViewTextBoxColumn importanceColumn = new DataGridViewTextBoxColumn();
            importanceColumn.HeaderText = "Importance";
            importanceColumn.DataPropertyName = "Importance";

            dataGridEmList.Columns.Add(idColumn);
            dataGridEmList.Columns.Add(subjectColumn);
            dataGridEmList.Columns.Add(fromColumn);
            dataGridEmList.Columns.Add(sentColumn);
            dataGridEmList.Columns.Add(importanceColumn);
        }//end setupGrid



    }//end class
}//end namespace