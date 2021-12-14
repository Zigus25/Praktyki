using System;
using System.Windows.Forms;

namespace Excel
{
    public partial class Form1 : Form
    {

        DBLogic dbl = new DBLogic();
        public Form1()
        {
            InitializeComponent();
            CreateTable();
        }
        
        public void CreateTable()
        {
            for(int i = 0; i < 26; i++)
            {
                DataGrid.Columns.Add(((char)(65+i)).ToString(), ((char)(65+i)).ToString());
            }
            for(int i = 0; i < 50; i++)
            {
                DataGrid.Rows.Add();
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
            using (SaveFileDialog openFileDialog = new SaveFileDialog())
            {
                openFileDialog.Filter = "db files (*.db)|*.db";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dbl.CreateConnection(openFileDialog.FileName);

                }
            }
        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if(row.Cells[1].Value != null)
                {
                    Console.WriteLine(row.Cells[1].Value.ToString());
                }
            }
            int x = (DataGrid.CurrentCell.RowIndex + 1);
            string Kol = DataGrid.CurrentCell.OwningColumn.Name;
            Komurka.Text = (Kol + x);
            if (DataGrid.CurrentCell.Value!=null)
            {
                string a = DataGrid.CurrentCell.Value.ToString();
                label2.Text = a;
                if (a.StartsWith("="))
                {
                    if (a.Contains("+"))
                    {
                        var sp = a.Split("+");
                        label2.Text = sp[0];
                    }
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

                }
            }
        }
    }
}
