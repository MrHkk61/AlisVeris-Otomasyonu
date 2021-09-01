using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace CicekSepeti
{
    public partial class Sepet : Form
    {
        public Sepet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Sepeti Onaylıyomusunuz ?", "ONAY ", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                SiparisOnay siparisOnay = new SiparisOnay();//bu formu kapatıp ödeme formuna geçtik
                siparisOnay.Show();
                this.Close();

            }
        }
        ArrayList SepetTutar = new ArrayList();
        ArrayList kullanici = new ArrayList();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");
        private void Sepet_Load(object sender, EventArgs e)
        {
          /*  SqlCommand Sepet = new SqlCommand();
            Sepet.Connection = baglanti;
            Sepet.CommandText = "select *from TBLSEPET";
            baglanti.Open();
            SqlDataReader okuyucu = Sepet.ExecuteReader();//tablomuzu okuyucumuza okuttuk
            while (okuyucu.Read())  //okuyucu
            {
                SepetTutar.Add(okuyucu["sepetTutar"]);
                kullanici.Add(okuyucu["SepetKullaniciAd"]);

            }


            baglanti.Close();*/
            label2.Text = arayuz.genelToplam.ToString();
            label1.Text = Form1.kullaniciAdi;
        }
    }
}
