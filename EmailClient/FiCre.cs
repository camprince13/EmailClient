using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;
using ADOX; //Requires Microsoft ADO Ext. 2.8 for DDL and Security
using ADODB; // requires Microsoft ActiveX Data Objects 2.X Library

namespace EmailClient
{
    class FiCre
    {
        public void DtaFldCre()
        {
            string MainP = @"Data";
            bool exists = System.IO.Directory.Exists((MainP));
            if (!exists)
                System.IO.Directory.CreateDirectory((MainP));

            DtaDbCre();
        }//end DtaFldCre

        public void DtaDbCre()
        {
            if (!File.Exists(@"Data\Data.accdb"))
            {
                ADOX.Catalog cat = new ADOX.Catalog();
                ADOX.Table table = new ADOX.Table();

                try
                {
                    cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Data\\Data.accdb; Jet OLEDB:Engine Type=5");

                    //Now Close the database
                    ADODB.Connection con = cat.ActiveConnection as ADODB.Connection;
                    if (con != null)
                        con.Close();

                    //result = true;
                }
                catch //(Exception ex)
                {
                }
                cat = null;
                TblCre();
            }//End if


        }//End dbCre

        public static void TblCre()
        {

            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";

            string sqlString = "CREATE TABLE EmailAccounts ([id] AUTOINCREMENT NOT NULL, [name] text(50), [eAddr] text(100), [eDesc] text(100), [pass] text(100), PRIMARY KEY (id));";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }


        public static void chIfTableExists()
        {
            bool exists = false;

            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";

            string sqlString = @"SELECT COUNT(*) FROM EmailAccounts";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                exists = true;
            }
            catch
            {
                exists = false;
            }
            finally { conn.Close(); }


            if (exists == false) { TblCre(); }
        }//end chIfTableExists

        public void write2Lic(string input)
        {
            string path = @"Data\licence.rec";
            if (!File.Exists(path))
            {
                //File.Create(path);
                //TextWriter tw = new StreamWriter(path);
                //tw.Write(input);
                //tw.Close();

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(input);
                }


            }
            else if (File.Exists(path))
            {
                //TextWriter tw = new StreamWriter(path, true);
                //tw.Write(input);
                //tw.Close();

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(input);
                }

            }
        }//End write2Lic

        public string ReadLic()
        {
            string text = System.IO.File.ReadAllText(@"Data\licence.rec");
            // Display the file contents to the console. Variable text is a string.
            return text;
        }

    }//End class
}//End namespace