using System;
using System.Collections.Generic;
using System.Text;
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

        }//End add Recipe

    }//end class
}//end namespace
