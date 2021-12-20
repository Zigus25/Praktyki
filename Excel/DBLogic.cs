using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace Excel
{
    public class DBLogic
    {
        SqliteConnection sqlite_conn;
        public void CreateConnection(string path)
        {

            SqliteConnection conn;
            conn = new SqliteConnection($@"Data Source={path}");
            try
            {
                conn.Open();
                sqlite_conn = conn;
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT COUNT(*) FROM sqlite_master WHERE name=@TableName";
                var p1 = cmd.CreateParameter();
                p1.DbType = DbType.String;
                p1.ParameterName = "TableName";
                p1.Value = "Tabela";
                cmd.Parameters.Add(p1);

                var result = cmd.ExecuteScalar();
                if ((long)result == 0)
                {
                    Table();
                    configDB();
                }
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

        public SqliteDataReader LoadTable()
        {
            SqliteCommand command = new SqliteCommand("SELECT * FROM Tabela", sqlite_conn);
            return command.ExecuteReader();
        }

        public void configDB()
        {
            SqliteCommand command = new SqliteCommand(null, sqlite_conn);
            command.CommandText = "INSERT INTO Tabela (A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z) VALUES (@A,@B,@C,@D,@E,@F,@G,@H,@I,@J,@K,@L,@M,@N,@O,@P,@Q,@R,@S,@T,@U,@V,@W,@X,@Y,@Z)";
            SqliteParameter A = new SqliteParameter("@A", SqliteType.Text, 256);
            SqliteParameter B = new SqliteParameter("@B", SqliteType.Text, 256);
            SqliteParameter C = new SqliteParameter("@C", SqliteType.Text, 256);
            SqliteParameter D = new SqliteParameter("@D", SqliteType.Text, 256);
            SqliteParameter E = new SqliteParameter("@E", SqliteType.Text, 256);
            SqliteParameter F = new SqliteParameter("@F", SqliteType.Text, 256);
            SqliteParameter G = new SqliteParameter("@G", SqliteType.Text, 256);
            SqliteParameter H = new SqliteParameter("@H", SqliteType.Text, 256);
            SqliteParameter I = new SqliteParameter("@I", SqliteType.Text, 256);
            SqliteParameter J = new SqliteParameter("@J", SqliteType.Text, 256);
            SqliteParameter K = new SqliteParameter("@K", SqliteType.Text, 256);
            SqliteParameter L = new SqliteParameter("@L", SqliteType.Text, 256);
            SqliteParameter M = new SqliteParameter("@M", SqliteType.Text, 256);
            SqliteParameter N = new SqliteParameter("@N", SqliteType.Text, 256);
            SqliteParameter O = new SqliteParameter("@O", SqliteType.Text, 256);
            SqliteParameter P = new SqliteParameter("@P", SqliteType.Text, 256);
            SqliteParameter Q = new SqliteParameter("@Q", SqliteType.Text, 256);
            SqliteParameter R = new SqliteParameter("@R", SqliteType.Text, 256);
            SqliteParameter S = new SqliteParameter("@S", SqliteType.Text, 256);
            SqliteParameter T = new SqliteParameter("@T", SqliteType.Text, 256);
            SqliteParameter U = new SqliteParameter("@U", SqliteType.Text, 256);
            SqliteParameter V = new SqliteParameter("@V", SqliteType.Text, 256);
            SqliteParameter W = new SqliteParameter("@W", SqliteType.Text, 256);
            SqliteParameter X = new SqliteParameter("@X", SqliteType.Text, 256);
            SqliteParameter Y = new SqliteParameter("@Y", SqliteType.Text, 256);
            SqliteParameter Z = new SqliteParameter("@Z", SqliteType.Text, 256);
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

            for (int j = 0; j < 50; j++)
            {
                for (int i = 0; i < 26; i++)
                {
                    command.Parameters[i].Value = "";
                }
                command.ExecuteNonQuery();
            }
        }

        public void AddData(string row, int RowID)
        {
            SqliteCommand command = new SqliteCommand(null, sqlite_conn);
            command.CommandText = "UPDATE Tabela SET (A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z) = (@A,@B,@C,@D,@E,@F,@G,@H,@I,@J,@K,@L,@M,@N,@O,@P,@Q,@R,@S,@T,@U,@V,@W,@X,@Y,@Z) WHERE ROWID = @RID";
            SqliteParameter A = new SqliteParameter("@A", SqliteType.Text, 256);
            SqliteParameter B = new SqliteParameter("@B", SqliteType.Text, 256);
            SqliteParameter C = new SqliteParameter("@C", SqliteType.Text, 256);
            SqliteParameter D = new SqliteParameter("@D", SqliteType.Text, 256);
            SqliteParameter E = new SqliteParameter("@E", SqliteType.Text, 256);
            SqliteParameter F = new SqliteParameter("@F", SqliteType.Text, 256);
            SqliteParameter G = new SqliteParameter("@G", SqliteType.Text, 256);
            SqliteParameter H = new SqliteParameter("@H", SqliteType.Text, 256);
            SqliteParameter I = new SqliteParameter("@I", SqliteType.Text, 256);
            SqliteParameter J = new SqliteParameter("@J", SqliteType.Text, 256);
            SqliteParameter K = new SqliteParameter("@K", SqliteType.Text, 256);
            SqliteParameter L = new SqliteParameter("@L", SqliteType.Text, 256);
            SqliteParameter M = new SqliteParameter("@M", SqliteType.Text, 256);
            SqliteParameter N = new SqliteParameter("@N", SqliteType.Text, 256);
            SqliteParameter O = new SqliteParameter("@O", SqliteType.Text, 256);
            SqliteParameter P = new SqliteParameter("@P", SqliteType.Text, 256);
            SqliteParameter Q = new SqliteParameter("@Q", SqliteType.Text, 256);
            SqliteParameter R = new SqliteParameter("@R", SqliteType.Text, 256);
            SqliteParameter S = new SqliteParameter("@S", SqliteType.Text, 256);
            SqliteParameter T = new SqliteParameter("@T", SqliteType.Text, 256);
            SqliteParameter U = new SqliteParameter("@U", SqliteType.Text, 256);
            SqliteParameter V = new SqliteParameter("@V", SqliteType.Text, 256);
            SqliteParameter W = new SqliteParameter("@W", SqliteType.Text, 256);
            SqliteParameter X = new SqliteParameter("@X", SqliteType.Text, 256);
            SqliteParameter Y = new SqliteParameter("@Y", SqliteType.Text, 256);
            SqliteParameter Z = new SqliteParameter("@Z", SqliteType.Text, 256);
            SqliteParameter RID = new SqliteParameter("@RID", SqliteType.Integer, 2);
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
            command.Parameters.Add(RID);
            command.Prepare();

            var Data = row.Split(";");
            for (int i = 0; i < Data.Length - 1; i++)
            {
                command.Parameters[i].Value = Data[i];
            }
            command.Parameters[26].Value = RowID;
            command.ExecuteNonQuery();
        }
    }
}
