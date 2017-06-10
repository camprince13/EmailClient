using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace EmailClient
{
    class DBHandler
    {

        public static string AddEmail(EmailAccount e)
        {
            string strFeedback = "";

            string strSQL = "INSERT INTO EmailAccounts (name, eAddr, eDesc, pass, eType) VALUES (@Name, @Addr, @Desc, @pass, @type)";

            OleDbConnection conn = new OleDbConnection();

            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";
            conn.ConnectionString = strConn;

            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSQL;
            comm.Connection = conn;

            comm.Parameters.AddWithValue("@Name", e.Name);
            comm.Parameters.AddWithValue("@Addr", e.Address);
            comm.Parameters.AddWithValue("@Desc", e.Description);
            comm.Parameters.AddWithValue("@pass", e.Password);
            comm.Parameters.AddWithValue("@type", e.Type);

            try
            {
                conn.Open();
                strFeedback = comm.ExecuteNonQuery().ToString() + "Record(s) Added";
            }

            catch (Exception err)
            { strFeedback = "Error: " + err.Message; }

            finally { conn.Close(); }

            return strFeedback;

        }//End add Email

        public static DataSet GetEmailAccs()
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();


            //Create a command for our SQL statement
            OleDbCommand comm = new OleDbCommand();

            //SQL Statement
            String strSQL = "Select id as ID, eAddr as Email_Address, name as Email_Name, eDesc as Description, eType as Type FROM EmailAccounts WHERE 0=0";


            //Create DB tools and Configure
            //************************************************
            OleDbConnection conn = new OleDbConnection();

            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";
            conn.ConnectionString = strConn;

            comm.Connection = conn;
            comm.CommandText = strSQL;

            //Create Data Adapter
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = comm;

            //************************************************

            //Get Data
            conn.Open();
            da.Fill(ds, "EmailAccounts");
            conn.Close();


            return ds;
        }//End get Emails

        internal static EmailAccount GetFullEmailAccount(int id)
        {
            //Create and Initialize the DB Tools we need
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();
            OleDbDataReader dr;

            //Connection String
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";

            //SQL command string to pull up one person's data
            string sqlString =
           "Select id, name, eAddr, eDesc, pass, eType FROM EmailAccounts WHERE id = @e_ID;";

            conn.ConnectionString = strConn;

            //Give info
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@e_ID", id);

            //Open the DataBase
            conn.Open();
            dr = comm.ExecuteReader();

            EmailAccount acc = new EmailAccount();

            while (dr.Read())
            {
                acc.Id = Convert.ToInt32(dr["id"]);
                acc.Name = Convert.ToString(dr["name"]);
                acc.Address = Convert.ToString(dr["eAddr"]);
                acc.Description = Convert.ToString(dr["eDesc"]);
                acc.Password = Convert.ToString(dr["pass"]);
                acc.Type = Convert.ToString(dr["eType"]);
            }

            conn.Close();

            return acc;

        }//end GetFullEmailAccount

    }//end class
}//end namespace