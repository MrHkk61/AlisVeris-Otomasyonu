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
    public partial class SiparisOnay : Form
    {
        public SiparisOnay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");
        private void SiparisOnay_Load(object sender, EventArgs e)
        {
            label6.Text = Form1.kullaniciAdi;
            label1.Text = arayuz.genelToplam.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool durum = true;
            baglanti.Open();
            SqlCommand odeme = new SqlCommand("insert into TBLODEME(Durum,KullaniciAd) values (@durum,@kullaniciAd)", baglanti);
            odeme.Parameters.AddWithValue("@durum", durum);
            odeme.Parameters.AddWithValue("@kullaniciAd",label6.Text);
           
            odeme.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ÖDEME BAŞARILI");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }
    }
}
