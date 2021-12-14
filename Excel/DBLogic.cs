using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Data.SqlClient;

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

        public void AddData(string row)
        {
            SqliteCommand command = new SqliteCommand(null,sqlite_conn);
            command.CommandText = "INSERT INTO Tabela (A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z) VALUES (@A,@B,@C,@D,@E,@F,@G,@H,@I,@J,@K,@L,@M,@N,@O,@P,@Q,@R,@S,@T,@U,@V,@W,@X,@Y,@Z)";
            SqlParameter A = new SqlParameter("@A", SqlDbType.Text, 256);
            SqlParameter B = new SqlParameter("@B", SqlDbType.Text, 256);
            SqlParameter C = new SqlParameter("@C", SqlDbType.Text, 256);
            SqlParameter D = new SqlParameter("@D", SqlDbType.Text, 256);
            SqlParameter E = new SqlParameter("@E", SqlDbType.Text, 256);
            SqlParameter F = new SqlParameter("@F", SqlDbType.Text, 256);
            SqlParameter G = new SqlParameter("@G", SqlDbType.Text, 256);
            SqlParameter H = new SqlParameter("@H", SqlDbType.Text, 256);
            SqlParameter I = new SqlParameter("@I", SqlDbType.Text, 256);
            SqlParameter J = new SqlParameter("@J", SqlDbType.Text, 256);
            SqlParameter K = new SqlParameter("@K", SqlDbType.Text, 256);
            SqlParameter L = new SqlParameter("@L", SqlDbType.Text, 256);
            SqlParameter M = new SqlParameter("@M", SqlDbType.Text, 256);
            SqlParameter N = new SqlParameter("@N", SqlDbType.Text, 256);
            SqlParameter O = new SqlParameter("@O", SqlDbType.Text, 256);
            SqlParameter P = new SqlParameter("@P", SqlDbType.Text, 256);
            SqlParameter Q = new SqlParameter("@Q", SqlDbType.Text, 256);
            SqlParameter R = new SqlParameter("@R", SqlDbType.Text, 256);
            SqlParameter S = new SqlParameter("@S", SqlDbType.Text, 256);
            SqlParameter T = new SqlParameter("@T", SqlDbType.Text, 256);
            SqlParameter U = new SqlParameter("@U", SqlDbType.Text, 256);
            SqlParameter V = new SqlParameter("@V", SqlDbType.Text, 256);
            SqlParameter W = new SqlParameter("@W", SqlDbType.Text, 256);
            SqlParameter X = new SqlParameter("@X", SqlDbType.Text, 256);
            SqlParameter Y = new SqlParameter("@Y", SqlDbType.Text, 256);
            SqlParameter Z = new SqlParameter("@Z", SqlDbType.Text, 256);
            command.Parameters.Add(A);
            command.Parameters.Add(B);
            command.Parameters.Add(C);
            command.Parameters.Add(D);
            command.Parameters.Add(E);
            command.Parameters.Add(F);
            command.Parameters.Add(G);
            command.Parameters.Add(H);
            command.Parameters.Add(I);
            command.Parameters.Add(J);
            command.Parameters.Add(K);
            command.Parameters.Add(L);
            command.Parameters.Add(M);
            command.Parameters.Add(N);
            command.Parameters.Add(O);
            command.Parameters.Add(P);
            command.Parameters.Add(Q);
            command.Parameters.Add(R);
            command.Parameters.Add(S);
            command.Parameters.Add(T);
            command.Parameters.Add(U);
            command.Parameters.Add(V);
            command.Parameters.Add(W);
            command.Parameters.Add(X);
            command.Parameters.Add(Y);
            command.Parameters.Add(Z);
            command.Prepare();

            var Data = row.Split(";");
            for(int i = 0; i < Data.Length; i++)
            {
                command.Parameters[i].Value = Data[i];
            }
            command.ExecuteNonQuery();
        }
    }
}
