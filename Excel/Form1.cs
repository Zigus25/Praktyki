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
                DataGrid.Columns.Add(((char)(97+i)).ToString(), ((char)(65+i)).ToString());
            }
            for(int i = 0; i < 50; i++)
            {
                DataGrid.Rows.Add();
            }
        }
    }
}
