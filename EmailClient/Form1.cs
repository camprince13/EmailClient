﻿using System;
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
            }
        }//end submit email


    }//end class
}//end namespace
