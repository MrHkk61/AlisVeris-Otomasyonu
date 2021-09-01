using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CicekSepeti
{
    public partial class adminBayiGiris : Form
    {
        public adminBayiGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");
        SqlDataReader AdminKontrol;
        SqlDataReader BayiKontrol;
        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand giris = new SqlCommand("adminGirisKontrol", baglanti);
            giris.CommandType = CommandType.StoredProcedure;
            giris.Parameters.AddWithValue("@Auser", textBox3.Text);
            giris.Parameters.AddWithValue("@APass", textBox4.Text);
            baglanti.Open();

            
            AdminKontrol = giris.ExecuteReader();
            
            if (AdminKontrol.Read())
            {
                MessageBox.Show("GİRİŞ BAŞARILI");

                profilDuzenle profilDuzenle = new profilDuzenle();
                profilDuzenle.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("GİRİŞ BAŞARISIZ");
            }

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand Bgiris = new SqlCommand("SELECT* FROM TBLBAYİ where BayiAd=@Buser AND BayiSifre=@Bpass", baglanti);
            
            Bgiris.Parameters.AddWithValue("@Buser", textBox1.Text);
            Bgiris.Parameters.AddWithValue("@BPass", textBox2.Text);
            baglanti.Open();


            BayiKontrol = Bgiris.ExecuteReader();
            if (BayiKontrol.Read())
            {
                MessageBox.Show("GİRİŞ BAŞARILI");

                AdminUrun AdminUrun = new AdminUrun();
                AdminUrun.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("GİRİŞ BAŞARISIZ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void adminBayiGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
