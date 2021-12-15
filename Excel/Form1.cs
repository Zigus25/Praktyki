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
                int rowID = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dbl.CreateConnection(openFileDialog.FileName);
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
            }
        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int x = (DataGrid.CurrentCell.RowIndex + 1);
            string Kol = DataGrid.CurrentCell.OwningColumn.Name;
            Komurka.Text = (Kol + x);
            bool tak = true;
            if (DataGrid.CurrentCell.Value!=null)
            {
                string a = DataGrid.CurrentCell.Value.ToString();
                label2.Text = a;
                if (a.StartsWith("="))
                {
                    if (a.Contains("*") && tak)
                    {
                        var sp = a.Remove(0, 1).Split("*");
                        int wynik = 1;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            wynik *= Convert.ToInt32(sp[i]);
                        }
                        label2.Text = (wynik).ToString();
                        tak = false;
                    }
                    if (a.Contains("/") && tak)
                    {
                        var sp = a.Remove(0, 1).Split("/");
                        int wynik = 0;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            if (i==0)
                            {
                                wynik = Convert.ToInt32(sp[i]);
                            }
                            else
                            {
                                wynik /= Convert.ToInt32(sp[i]);
                            }
                        }
                        label2.Text = (wynik).ToString();
                        tak = false;
                    }
                    if (a.Contains("-") && tak)
                    {
                        var sp = a.Remove(0, 1).Split("-");
                        int wynik = 0;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            if (sp[i].Contains("+"))
                            {
                                var susp = sp[i].Split("+");
                                if (i != 0)
                                {
                                    wynik -= Convert.ToInt32(susp[0]);
                                }
                                for (int j = 1; j < susp.Length; j++)
                                {
                                    wynik += Convert.ToInt32(susp[j]);
                                }
                            }
                            else
                            {
                                if (a.Remove(0, 1)[0] == '-' && i == 0)
                                {
                                    wynik -= Convert.ToInt32(sp[i+1]);
                                    i++;
                                }
                                else if (i == 0)
                                {
                                    wynik += Convert.ToInt32(sp[i]);
                                }
                                else
                                {
                                    wynik -= Convert.ToInt32(sp[i]);
                                }
                            }
                        }
                        label2.Text = (wynik).ToString();
                        tak = false;
                    }
                    if (a.Contains("+") && tak)
                    {
                        var sp = a.Remove(0,1).Split("+");
                        int wynik = 0;
                        for(int i = 0; i< sp.Length; i++)
                        {
                            if (sp[i].Contains("-"))
                            {
                                var susp = sp[i].Split("-");
                                wynik += Convert.ToInt32(susp[0]);
                                for (int j =1; j< susp.Length; j++)
                                {
                                    wynik -= Convert.ToInt32(susp[j]);
                                }
                            }
                            else
                            {
                                wynik += Convert.ToInt32(sp[i]);
                            }
                        }
                        label2.Text = (wynik).ToString();
                        tak = false;
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
