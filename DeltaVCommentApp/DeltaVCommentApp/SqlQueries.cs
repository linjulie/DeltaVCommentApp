using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeltaVCommentApp
{
    internal class SqlQueries
    {
        public void InsertComment(string header, string section)
        {
            string connectionString;
            string sql;

            connectionString = "Server=PKDEMOSYSTEM\\SQLEXPRESS;Initial Catalog=Sommerprosjekt;Integrated Security=True";
            sql = "INSERT INTO dbo.PopUpTable ([Header], [Section]) VALUES (@Header, @Section)";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                //Adds the new popup object to the database  
                cmd.Parameters.AddWithValue("@header", header);
                cmd.Parameters.AddWithValue("@section", section);

                try
                {
                    cnn.Open();
                    Int32 rowsAffected = cmd.ExecuteNonQuery();     
                    cnn.Close();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message);
                }
            }
          
        }
        
        public int ReturnLastID()
        {
            string connectionString;
            string sql;

            connectionString = "Server=PKDEMOSYSTEM\\SQLEXPRESS;Initial Catalog=Sommerprosjekt;Integrated Security=True";
            sql = "SELECT TOP 1 PopUpID FROM dbo.PopUpTable ORDER BY PopUpID DESC";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                try
                {
                    cnn.Open();
                    //Int32 rowsAffected = cmd.ExecuteNonQuery();
                    Int32 commentId = (int)cmd.ExecuteScalar();
                    cnn.Close();
                    Console.WriteLine("RowsAffected: {0}");
                    return commentId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
            
        }

    }
}
