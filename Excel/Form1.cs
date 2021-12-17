using System;
using System.Linq;
using System.Windows.Forms;

namespace Excel
{
    public partial class Form1 : Form
    {
        bool baza = false;
        DBLogic dbl = new DBLogic();
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
                    if (a.StartsWith("=Suma(") && a.Contains(":") && a.EndsWith(")") && tak)
                    {
                        double wynik = 0.0;

                        string sum = a.Substring(6, a.Length - 7);
                        var sp = sum.Split(":");

                        int col1 = sp[0][0] - 65;
                        int row1 = Convert.ToInt32(sp[0].Remove(0, 1)) - 1;
                        int col2 = sp[1][0] - 65;
                        int row2 = Convert.ToInt32(sp[1].Remove(0, 1)) - 1;

                        if (col1 == col2)
                        {
                            if (row1 < row2)
                            {
                                for (int i = row1; i <= row2; i++)
                                {
                                    wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[col1].Value);
                                }
                            }
                            else if (row1 > row2)
                            {
                                for (int i = row2; i <= row1; i++)
                                {
                                    wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[col1].Value);
                                }
                            }
                            else
                            {
                                wynik += Convert.ToDouble(DataGrid.Rows[row1].Cells[col1].Value);
                            }
                        }
                        else if (col1 < col2)
                        {
                            if (row1 < row2)
                            {
                                for (int j = col1; j <= col2; j++)
                                {
                                    for (int i = row1; i <= row2; i++)
                                    {
                                        wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[j].Value);
                                    }
                                }
                            }
                            else if (row1 > row2)
                            {
                                for (int j = col1; j <= col2; j++)
                                {
                                    for (int i = row2; i <= row1; i++)
                                    {
                                        wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[j].Value);
                                    }
                                }
                            }
                            else
                            {
                                for (int i = col1; i <= col2; i++)
                                {
                                    wynik += Convert.ToDouble(DataGrid.Rows[row1].Cells[col1].Value);
                                }
                            }
                        }
                        else
                        {
                            if (row1 < row2)
                            {
                                for (int j = col2; j <= col1; j++)
                                {
                                    for (int i = row1; i <= row2; i++)
                                    {
                                        wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[j].Value);
                                    }
                                }
                            }
                            else if (row1 > row2)
                            {
                                for (int j = col2; j <= col1; j++)
                                {
                                    for (int i = row2; i <= row1; i++)
                                    {
                                        wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[j].Value);
                                    }
                                }
                            }
                            else
                            {
                                for (int i = col2; i <= col1; i++)
                                {
                                    wynik += Convert.ToDouble(DataGrid.Rows[row1].Cells[col1].Value);
                                }
                            }
                        }
                        label2.Text = wynik.ToString();
                        tak = false;
                    }
                    if (a.StartsWith("=Avg(") && a.Contains(":") && a.EndsWith(")") && tak)
                    {
                        double wynik = 0.0;
                        int count = 1;

                        string avg = a.Substring(5, a.Length - 6);
                        var sp = avg.Split(":");

                        int col1 = sp[0][0] - 65;
                        int row1 = Convert.ToInt32(sp[0].Remove(0, 1)) - 1;
                        int col2 = sp[1][0] - 65;
                        int row2 = Convert.ToInt32(sp[1].Remove(0, 1)) - 1;
                        if (col1 == col2)
                        {
                            if (row1 < row2)
                            {
                                for (int i = row1; i <= row2; i++)
                                {
                                    wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[col1].Value);
                                    count++;
                                }
                            }
                            else if (row1 > row2)
                            {
                                for (int i = row2; i <= row1; i++)
                                {
                                    wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[col1].Value);
                                    count++;
                                }
                            }
                            else
                            {
                                wynik += Convert.ToDouble(DataGrid.Rows[row1].Cells[col1].Value);
                            }
                        }
                        else if (col1 < col2)
                        {
                            if (row1 < row2)
                            {
                                for (int j = col1; j <= col2; j++)
                                {
                                    for (int i = row1; i <= row2; i++)
                                    {
                                        wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[j].Value);
                                        count++;
                                    }
                                }
                            }
                            else if (row1 > row2)
                            {
                                for (int j = col1; j <= col2; j++)
                                {
                                    for (int i = row2; i <= row1; i++)
                                    {
                                        wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[j].Value);
                                        count++;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = col1; i <= col2; i++)
                                {
                                    wynik += Convert.ToDouble(DataGrid.Rows[row1].Cells[col1].Value);
                                    count++;
                                }
                            }
                        }
                        else
                        {
                            if (row1 < row2)
                            {
                                for (int j = col2; j <= col1; j++)
                                {
                                    for (int i = row1; i <= row2; i++)
                                    {
                                        wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[j].Value);
                                        count++;
                                    }
                                }
                            }
                            else if (row1 > row2)
                            {
                                for (int j = col2; j <= col1; j++)
                                {
                                    for (int i = row2; i <= row1; i++)
                                    {
                                        wynik += Convert.ToDouble(DataGrid.Rows[i].Cells[j].Value);
                                        count++;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = col2; i <= col1; i++)
                                {
                                    wynik += Convert.ToDouble(DataGrid.Rows[row1].Cells[col1].Value);
                                    count++;
                                }
                            }
                        }
                        wynik = wynik / count;
                        Console.WriteLine(wynik);
                        label2.Text = wynik.ToString();
                        tak = false;
                    }
                    if (a.StartsWith("=Pow(") && a.Contains(",") && a.EndsWith(")") && tak)
                    {
                        long wynik = 0;
                        int potega = 0;
                        int podstawa;

                        string avg = a.Substring(5, a.Length - 6);
                        var sp = avg.Split(",");

                        if (sp[0].All(char.IsDigit))
                        {
                            podstawa = Convert.ToInt32(sp[1]);
                        }
                        else
                        {
                            int col1 = sp[0][0] - 65;
                            int row1 = Convert.ToInt32(sp[0].Remove(0, 1)) - 1;
                            podstawa = Convert.ToInt32(DataGrid.Rows[row1].Cells[col1].Value);
                        }
                        if (sp[1].All(char.IsDigit))
                        {
                            potega = Convert.ToInt32(sp[1]);
                        }
                        else
                        {
                            int col2 = sp[1][0] - 65;
                            int row2 = Convert.ToInt32(sp[1].Remove(0, 1)) - 1;
                            potega = Convert.ToInt32(DataGrid.Rows[row2].Cells[col2].Value);
                        }
                        label2.Text = Math.Pow(podstawa,potega).ToString();
                        tak = false;
                    }
                    if (a.StartsWith("=Root(") && a.EndsWith(")") && tak) 
                    {
                        long wynik = 0;
                        int podstawa;

                        string avg = a.Substring(6, a.Length - 7);
                        var sp = avg.Split(",");

                        if (sp[0].All(char.IsDigit))
                        {
                            podstawa = Convert.ToInt32(sp[1]);
                        }
                        else
                        {
                            int col1 = sp[0][0] - 65;
                            int row1 = Convert.ToInt32(sp[0].Remove(0, 1)) - 1;
                            podstawa = Convert.ToInt32(DataGrid.Rows[row1].Cells[col1].Value);
                        }
                        label2.Text = Math.Sqrt(podstawa).ToString();
                        tak = false;
                    }
                    if (a.Contains("*") && tak)
                    {
                        var sp = a.Remove(0, 1).Split("*");
                        decimal wynik = 1;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            if (sp[i].All(char.IsDigit))
                            {
                                wynik *= Convert.ToDecimal(sp[i]);
                            }
                            else if (sp[i].All(char.IsLetter))
                            {
                                Console.WriteLine("kol");
                            }
                            else if (sp[i].Length > 1 && sp[i].Length < 4)
                            {
                                int col = ((int)sp[i][0] - 65);
                                int row = Convert.ToInt32(sp[i].Remove(0, 1)) - 1;
                                if (DataGrid.Rows[row].Cells[col].Value != null)
                                {
                                    wynik *= Convert.ToDecimal(DataGrid.Rows[row].Cells[col].Value);
                                }
                                else
                                {
                                    wynik *= 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Błąd");
                            }
                        }
                        label2.Text = (wynik).ToString();
                        tak = false;
                    }
                    if (a.Contains("/") && tak)
                    {
                        var sp = a.Remove(0, 1).Split("/");
                        double wynik = 0.0;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            if (sp[i].All(char.IsDigit))
                            {
                                if (i == 0)
                                {
                                    wynik = Convert.ToDouble(sp[i]);
                                }
                                else
                                {
                                    wynik /= Convert.ToDouble(sp[i]);
                                }
                            }
                            else if (sp[i].All(char.IsLetter))
                            {
                                Console.WriteLine("kol");
                            }
                            else if (sp[i].Length > 1 && sp[i].Length < 4)
                            {
                                int col = ((int)sp[i][0] - 65);
                                int row = Convert.ToInt32(sp[i].Remove(0, 1)) - 1;
                                if (DataGrid.Rows[row].Cells[col].Value != null)
                                {
                                    if (i == 0)
                                    {
                                        wynik = Convert.ToDouble(DataGrid.Rows[row].Cells[col].Value);
                                    }
                                    else
                                    {
                                        wynik /= Convert.ToDouble(DataGrid.Rows[row].Cells[col].Value);
                                    }
                                }
                                else
                                {
                                    wynik += 0;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Błąd");
                            }
                        }
                        label2.Text = (wynik).ToString();
                        tak = false;
                    }
                    if (a.Contains("-") && tak)
                    {
                        var sp = a.Remove(0, 1).Split("-");
                        double wynik = 0.0;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            if (sp[i].All(char.IsDigit))
                            {
                                if (a.Remove(0, 1)[0] == '-' && i == 0)
                                {
                                    wynik -= Convert.ToDouble(sp[i + 1]);
                                    i++;
                                }
                                else if (i == 0)
                                {
                                    wynik += Convert.ToDouble(sp[i]);
                                }
                                else
                                {
                                    wynik -= Convert.ToDouble(sp[i]);
                                }
                            }
                            else if (sp[i].All(char.IsLetter))
                            {
                                Console.WriteLine("kol");
                            }
                            else if (sp[i].Length > 1 && sp[i].Length < 4)
                            {
                                int col = ((int)sp[i][0] - 65);
                                int row = Convert.ToInt32(sp[i].Remove(0, 1)) - 1;
                                if (DataGrid.Rows[row].Cells[col].Value != null)
                                {
                                    string cellV = DataGrid.Rows[row].Cells[col].Value.ToString();
                                    if (cellV.Length >= 2 && cellV.Remove(0, 1)[0] == '-' && i == 0)
                                    {
                                        wynik -= Convert.ToDouble(cellV);
                                        i++;
                                    }
                                    else if (i == 0)
                                    {
                                        wynik += Convert.ToDouble(cellV);
                                    }
                                    else
                                    {
                                        wynik -= Convert.ToDouble(cellV);
                                    }
                                }
                                else
                                {
                                    wynik += 0;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Błąd");
                            }
                        }
                        label2.Text = (wynik).ToString();
                        tak = false;
                    }
                    if (a.Contains("+") && tak)
                    {
                        var sp = a.Remove(0, 1).Split("+");
                        double wynik = 0.0;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            if (sp[i].All(char.IsDigit))
                            {
                                wynik += Convert.ToDouble(sp[i]);
                            }
                            else if (sp[i].All(char.IsLetter))
                            {
                                Console.WriteLine("kol");
                            }
                            else if (sp[i].Length > 1 && sp[i].Length < 4)
                            {
                                int col = ((int)sp[i][0] - 65);
                                int row = Convert.ToInt32(sp[i].Remove(0, 1)) - 1;
                                if (DataGrid.Rows[row].Cells[col].Value != null)
                                {
                                    wynik += Convert.ToDouble(DataGrid.Rows[row].Cells[col].Value);
                                }
                                else
                                {
                                    wynik += 0;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Błąd");
                            }
                        }
                        label2.Text = (wynik).ToString();
                        tak = false;
                    }
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
