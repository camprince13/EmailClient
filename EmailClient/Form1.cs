using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace EmailClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FiCre.DtaFldCre();

            if (FiCre.chIfTableContains() >= 1)
            {
                panel1.Visible = false;
                panel1.Enabled = false;
                popEmailAccGrid();
            }

            else
            {
                dataGridEmails.Visible = false;
                dataGridEmails.Enabled = false;
            }

        }//end constructor

        private void btnSubEmail_Click(object sender, EventArgs e)
        {
            EmailAccount em = new EmailAccount();
            em.Address = txtEmail.Text;
            em.Description = txtDesc.Text;
            em.Name = txtName.Text;
            em.Password = txtPass.Text;
            em.Type = txtType.Text;

            string outp = DBHandler.AddEmail(em);
            if (outp.ToLower().Contains("error"))
            { MessageBox.Show("There was an error, please try again."); }

            else
            {
                panel1.Visible = false;
                panel1.Enabled = false;
                dataGridEmails.Visible = true;
                dataGridEmails.Enabled = true;
                popEmailAccGrid();
            }
        }//end submit email

        private void popEmailAccGrid()
        {
            //display data
            DataSet ds = DBHandler.GetEmailAccs();
            dataGridEmails.DataSource = ds;
            dataGridEmails.DataMember = ds.Tables["EmailAccounts"].ToString();
        }//end popEmailAccGrid

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Enabled = true;
            dataGridEmails.Visible = false;
            dataGridEmails.Enabled = false;
        }

        private void dataGridEmails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string EmID = dataGridEmails.Rows[e.RowIndex].Cells[0].Value.ToString();

            int emID = Convert.ToInt32(EmID);

            EmailForm Eform = new EmailForm(emID);
            Eform.Show();
        }


    }//end class
}//end namespace
