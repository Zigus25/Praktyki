using System;
using System.IO;
using System.Windows.Forms;

namespace Excel
{
    public partial class Form1 : Form
    {
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

        private void New_Click(object sender, System.EventArgs e)
        {
            DataGrid.Rows.Clear(); 
            for (int i = 0; i < 50; i++)
            {
                DataGrid.Rows.Add();
            }
            DataGrid.Refresh();
        }

        private void Sava_Click(object sender, System.EventArgs e)
        {

        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Komurka.Text = (DataGrid.CurrentCell.OwningColumn.Name + (DataGrid.CurrentCell.RowIndex+1));
        }
    }
}
