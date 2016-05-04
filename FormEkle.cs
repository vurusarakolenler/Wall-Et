using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Web;
using System.Windows.Forms.Design;

namespace Wall_Et
{
    public partial class FormEkle : Form
    {
        public Form AnaMenu;

        public FormEkle()
        {
            InitializeComponent();



        }

        OleDbConnection veriler = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0 ;Data Source=data.accdb");
        OleDbCommand sorgu = new OleDbCommand();
        DataTable tablo = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            veriler.Open();
            sorgu.Connection = veriler;
            sorgu.CommandText = "INSERT INTO wallet (miktar) VALUES ('" + textBox1.Text + "')";
            sorgu.ExecuteNonQuery();
            veriler.Close();
        }
    }
}
