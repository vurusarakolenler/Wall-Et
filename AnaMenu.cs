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
using System.Data.SqlClient;

namespace Wall_Et
{
    public partial class AnaMenu : Form
    {
        int Miktar = 0;
        SqlConnection conn= new SqlConnection("Data Source=OZGU-BILGISAYAR\\OZGU;Initial Catalog=projW;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt = new DataTable();
        int btnClick = 0;

        public static Form_Ekle FormEkle;

        public AnaMenu()
        {
            InitializeComponent();
            FormEkle = new Form_Ekle();
            FormEkle.AnaMenu = this;


            //miktar.Parent = pictureBox1;
            //miktar.BackColor = Color.Transparent;

            
            var pos = this.PointToScreen(miktar.Location);
            pos = pictureBox1.PointToClient(pos);
            miktar.Parent = pictureBox1;
            miktar.Location = pos;
            miktar.BackColor = Color.Transparent;
            
            hesaplama.Visible = false;
            giderEkle.Visible = false;
            gelirEkle.Visible = false;



        }



        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            int yeniMiktar = int.Parse(txtyeni_miktar.Text);
            //int Miktar = int.Parse(miktar.Text);
            Miktar += yeniMiktar;

            miktar.Text = Miktar.ToString() + " ₺";

            SqlDataAdapter adtr = new SqlDataAdapter("Select * From wallet", conn);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "İşlem No";
            dataGridView1.Columns[1].HeaderText = "Harcama Adı";
            dataGridView1.Columns[2].HeaderText = "Tutar";
            dataGridView1.Columns[3].HeaderText = "Kategori";
            dataGridView1.Columns[4].HeaderText = "Tür";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            conn.Close();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            conn.Open();
            int yeniMiktar = int.Parse(txtyeni_miktar.Text);
            //int Miktar = int.Parse(miktar.Text);
            Miktar += yeniMiktar;

            miktar.Text = Miktar.ToString() + " ₺";

            SqlDataAdapter adtr = new SqlDataAdapter("Select * From wallet", conn);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "İşlem No";
            dataGridView1.Columns[1].HeaderText = "Harcama Adı";
            dataGridView1.Columns[2].HeaderText = "Tutar";
            dataGridView1.Columns[3].HeaderText = "Kategori";
            dataGridView1.Columns[4].HeaderText = "Tür";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            conn.Close();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            if (btnClick % 2 == 1)
            {
                pictureBox4.Image = Wall_Et.Properties.Resources.btnKapatmaN;
                pictureBox4.Refresh();
                pictureBox4.Visible = true;

            }
            else
            {
                pictureBox4.Image = Wall_Et.Properties.Resources.btnAcmaUst;
                pictureBox4.Refresh();
                pictureBox4.Visible = true;


            }

        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (btnClick % 2 == 1)
            {
                pictureBox4.Image = Wall_Et.Properties.Resources.btnKapatmaN;
                pictureBox4.Refresh();
                pictureBox4.Visible = true;
            }
            else
            {
                pictureBox4.Image = Wall_Et.Properties.Resources.btnAcmaNormal;
                pictureBox4.Refresh();
                pictureBox4.Visible = true;
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            btnClick++;

            if (btnClick%2 == 1)
            {
                hesaplama.Visible = true;
                hesaplama.Show();

                gelirEkle.Visible = true;
                gelirEkle.Show();

                giderEkle.Visible = true;
                giderEkle.Show();

                pictureBox4.Image = Wall_Et.Properties.Resources.btnKapatmaN;
                pictureBox4.Refresh();
                pictureBox4.Visible = true;
                this.BackgroundImage = Wall_Et.Properties.Resources.bg3Blured;

            }

            else
            {

                hesaplama.Visible = false;
                giderEkle.Visible = false;
                gelirEkle.Visible = false;

                pictureBox4.Image = Wall_Et.Properties.Resources.btnAcmaNormal;
                pictureBox4.Refresh();
                pictureBox4.Visible = true;
                this.BackgroundImage = Wall_Et.Properties.Resources.bg3N;

            }

        }

        private void gelirEkle_Click(object sender, EventArgs e)
        {
            AnaMenu.FormEkle.ShowDialog();
        }
    }

}
