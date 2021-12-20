using System;
using System.Data;
using System.Windows.Forms;

namespace Excel
{
    public partial class Form1 : Form
    {
        bool baza = false;
        DBLogic dbl = new DBLogic();
        Logic log = new Logic();
        public Form1()
        {
            InitializeComponent();
            CreateTable();
        }

        public void CreateTable()
        {
            for (int i = 0; i < 26; i++)
            {
                DataGrid.Columns.Add(((char)(65 + i)).ToString(), ((char)(65 + i)).ToString());
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
            for (int i = 0; i < 50; i++)
            {
                DataGrid.Rows.Add();
            }
            DataGrid.Refresh();
        }

        private void Sava_Click(object sender, EventArgs e)
        {
            if (!baza)
            {
                using (SaveFileDialog openFileDialog = new SaveFileDialog())
                {
                    openFileDialog.Filter = "db files (*.db)|*.db";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dbl.CreateConnection(openFileDialog.FileName);
                        baza = true;
                    }
                }
            }
            int rowID = 1;
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                string rowData = "";
                for (int i = 0; i < 26; i++)
                {
                    if (row.Cells[i].Value != null)
                    {
                        rowData += row.Cells[i].Value.ToString() + ";";
                    }
                    else
                    {
                        rowData += ";";
                    }
                }
                dbl.AddData(rowData, rowID);
                rowID++;
            }
        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int x = (DataGrid.CurrentCell.RowIndex + 1);
            string Kol = DataGrid.CurrentCell.OwningColumn.Name;
            Komurka.Text = (Kol + x);
            bool tak = true;
            if (DataGrid.CurrentCell.Value != null)
            {
                string a = DataGrid.CurrentCell.Value.ToString(); 
                
                if (a.StartsWith("="))
                {
                    DataTable dt = new DataTable();
                    foreach (DataGridViewColumn column in DataGrid.Columns)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }
                    foreach (DataGridViewRow row in DataGrid.Rows)
                    {
                        dt.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }
                    int y = Kol[0] - 65;
                    label2.Text = log.Rozpoznaj(dt, a,x,y);
                }
                else
                {
                    label2.Text = a;
                }
            }
            else
            {
                label2.Text = "";
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "db files (*.db)|*.db";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dbl.CreateConnection(openFileDialog.FileName);
                    DataGrid.Rows.Clear();
                    var a = dbl.LoadTable();
                    while (a.Read())
                    {
                        string[] row = new string[26];
                        for (int i = 0; i < 26; i++)
                        {
                            row[i] = a.GetString(i);
                        }
                        DataGrid.Rows.Add(row);
                    }
                    DataGrid.Refresh();
                    baza = true;
                }
            }
        }
    }
}
