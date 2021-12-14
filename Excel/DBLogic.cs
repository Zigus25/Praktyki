using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace Excel
{
    public class DBLogic
    {
        SqliteConnection sqlite_conn;
        public void CreateConnection( string path )
        {

            SqliteConnection conn;
            conn = new SqliteConnection($@"Data Source={path}");
            try
            {
                conn.Open();
                sqlite_conn = conn;
                Table();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Table()
        {
            SqliteCommand sqlite_cmd; 
            string Createsql = "CREATE TABLE IF NOT EXISTS Tabela(A VARCHAR(255), B VARCHAR(255), C VARCHAR(255), D VARCHAR(255), E VARCHAR(255), F VARCHAR(255), G VARCHAR(255), H VARCHAR(255), I VARCHAR(255), J VARCHAR(255), K VARCHAR(255), L VARCHAR(255), M VARCHAR(255), N VARCHAR(255), O VARCHAR(255), P VARCHAR(255), Q VARCHAR(255), R VARCHAR(255), S VARCHAR(255), T VARCHAR(255), U VARCHAR(255), V VARCHAR(255), W VARCHAR(255), X VARCHAR(255), Y VARCHAR(255), Z VARCHAR(255))";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }

        public void AddData()
        {
            SqliteCommand command = new SqliteCommand(null,sqlite_conn);
            SqlParameter descParam = new SqlParameter("@desc", SqlDbType.Text, 100);
        }
    }
}
