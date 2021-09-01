using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace CicekSepeti
{
    public partial class arayuz : Form
    {
        public arayuz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Sepet Sepet = new Sepet();//bu formu kapatıp ödeme formuna geçtik
            Sepet.Show();
            this.Close();

        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");

        private void arayuz_Load(object sender, EventArgs e)
        {
            genelToplam = 0;

            textBox1.Text = "1";//miktarımızı default olarka 1 yaptık
            textBox2.Text = "1";
            textBox3.Text = "1";
            textBox4.Text = "1";
            textBox5.Text = "1";
            textBox6.Text = "1";

            /*
           string DosyaYolu = @"C:\Resimler";//dosya yolumuz 

          if (Directory.Exists(DosyaYolu)==false) // resimler dosyası yoksa oluştur.
           {
               Directory.CreateDirectory(DosyaYolu);


           }
           pictureBox1.Image = Image.FromFile("C:\\Resimler\\default.png");
           pictureBox2.Image = Image.FromFile("C:\\Resimler\\default.png");
           pictureBox3.Image = Image.FromFile("C:\\Resimler\\default.png");
           pictureBox4.Image = Image.FromFile("C:\\Resimler\\default.png");
           pictureBox5.Image = Image.FromFile("C:\\Resimler\\default.png");
           pictureBox6.Image = Image.FromFile("C:\\Resimler\\default.png");*/

            /*
             eğer yoksa  default fotograf sec
           
            pictureBox1.Image = Image.FromFile("C:\\Resimler\\orkide.jpg"); // fotograf yollarımızı pictureboxlara tanımladık
            pictureBox2.Image = Image.FromFile("C:\\Resimler\\laptop.png");
            pictureBox3.Image = Image.FromFile("C:\\Resimler\\camasirmak.png");
            pictureBox4.Image = Image.FromFile("C:\\Resimler\\parfum.png");
            pictureBox5.Image = Image.FromFile("C:\\Resimler\\scooter.png");
            pictureBox6.Image = Image.FromFile("C:\\Resimler\\bisiklet.png");

            */
            label1.Text = Form1.kullaniciAdi; // KULLANICI ADIMIZI FORM1  DEN CEKMESİ İÇİN 

            SqlCommand getir = new SqlCommand();
          //  SqlCommand KullaniciGetir = new SqlCommand();
          //  KullaniciGetir.Connection = baglanti;
            getir.Connection = baglanti; 
            getir.CommandText="urunGetir"; //tablomuzu cektik Stored Procedure ile
          //  KullaniciGetir.CommandText = "KullaniciGetir"; //tablomuzu cektik Stored Procedure ile

            baglanti.Open();
           // SqlDataReader kullaniciokuyucu = KullaniciGetir.ExecuteReader();
            SqlDataReader okuyucu = getir.ExecuteReader();//tablomuzu okuyucumuza okuttuk
            
          /* 
            while (kullaniciokuyucu.Read())
            {
                kullaniciİd.Add(kullaniciokuyucu["kullaniciId"]);
            }*/
                while (okuyucu.Read())  //okuyucu
            {

                UrunStok.Add(okuyucu["UrunStok"]);
                UrunFiyatlari.Add(okuyucu["UrunFiyat"]);//UrunFiyatlarımızı
                UrunAdlari.Add(okuyucu["UrunAd"]);//ve urun adlarımızı dizilerimize attık
                urunİD.Add(okuyucu["Urunİd"]);//urunidlerimizi okuduk ve diziye attık
                

              //  listBox1.Items.Add(okuyucu["UrunAd"].ToString()+" " +okuyucu["UrunFiyat" ].ToString()+" "+  okuyucu["UrunStok"].ToString())


            }
            baglanti.Close();
            label12.Text = UrunAdlari[0].ToString();//urun adlarımızı ve urun fiyatlarımızı yazdırdık 
            label6.Text = UrunFiyatlari[0].ToString();
            label10.Text = UrunAdlari[1].ToString();
            label4.Text = UrunFiyatlari[1].ToString();
            label11.Text = UrunAdlari[2].ToString();
            label5.Text = UrunFiyatlari[2].ToString();
            label8.Text = UrunAdlari[3].ToString();
            label2.Text = UrunFiyatlari[3].ToString();
            label9.Text = UrunAdlari[4].ToString();
            label3.Text = UrunFiyatlari[4].ToString();
            label13.Text = UrunAdlari[5].ToString();
            label7.Text = UrunFiyatlari[5].ToString();

        }

        ArrayList UrunAdlari = new ArrayList();//urun adlarını 
        ArrayList UrunFiyatlari = new ArrayList();//ve urun fiyatlarını tutması için dizi olusturduk
        ArrayList UrunStok = new ArrayList();
        ArrayList urunİD = new ArrayList();
        ArrayList kullaniciİd = new ArrayList();
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       
        public static  int genelToplam;
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand UrunEkle = new SqlCommand("UrunEkle", baglanti);// PROCEDURE 

            UrunEkle.CommandType = CommandType.StoredProcedure;// PROCEDURE olduğunu belirttik
            
            siparis1.Text = UrunAdlari[3].ToString() + "X" + textBox1.Text; ;// siparişi yazma sablonumz
            listBox1.Items.Add(siparis1.Text);//sablonumuzu yazdırma 
            genelToplam += (int)UrunFiyatlari[3]* (int)Convert.ToUInt32(textBox1.Text); //genel toplamı yazdırıdk
            geneltoplam.Text = genelToplam.ToString();
            /*
            baglanti.Open();

            UrunEkle.Parameters.AddWithValue("@siparistutar", (int)Convert.ToUInt32(siparis1.Text));//sipariş tutarımızı miktarla carpılmıs haliyle
                                                                                                    // yani siparis1.text ile databasemize gonderdik
            UrunEkle.Parameters.AddWithValue("@miktar", textBox1.Text);
            UrunEkle.Parameters.AddWithValue("@urunid",urunİD[3]);// urun id mizi dizimizden alıp sql e sipariş olarak aktardık 
            UrunEkle.Parameters.AddWithValue("@kullaniciid",kullaniciİd[0]);

            UrunEkle.ExecuteNonQuery();

            baglanti.Close();
          */

        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            siparis2.Text = UrunAdlari[4].ToString() + "X"+ textBox2.Text ;
            listBox1.Items.Add(siparis2.Text);
            genelToplam += (int)UrunFiyatlari[4] * (int)Convert.ToUInt32(textBox2.Text); 
            geneltoplam.Text = genelToplam.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            siparis3.Text = UrunAdlari[1].ToString() + "X" + textBox3.Text;
            listBox1.Items.Add(siparis3.Text);
            genelToplam += (int)UrunFiyatlari[1] * (int)Convert.ToUInt32(textBox3.Text);
            geneltoplam.Text = genelToplam.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            siparis4.Text = UrunAdlari[2].ToString() + "X" + textBox4.Text;
            listBox1.Items.Add(siparis4.Text);
            genelToplam += (int)UrunFiyatlari[2] * (int)Convert.ToUInt32(textBox4.Text); 
            geneltoplam.Text = genelToplam.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            siparis5.Text = UrunAdlari[0].ToString() + "X" + textBox5.Text;
            listBox1.Items.Add(siparis5.Text);
            genelToplam += (int)UrunFiyatlari[0] * (int)Convert.ToUInt32(textBox5.Text); 
            geneltoplam.Text = genelToplam.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            siparis6.Text = UrunAdlari[5].ToString() + "X" + textBox6.Text;
            listBox1.Items.Add(siparis6.Text);
            genelToplam += (int)UrunFiyatlari[5] * (int)Convert.ToUInt32(textBox6.Text); 
            geneltoplam.Text = genelToplam.ToString();
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
           /* baglanti.Open();
            SqlCommand sepeteEkle = new SqlCommand("SepetEkle)",baglanti);
            sepeteEkle.CommandType = CommandType.StoredProcedure; //PROCEDURE olduğunu belirttik
            sepeteEkle.Parameters.AddWithValue("@spttutar", textBox7.Text);
            sepeteEkle.Parameters.AddWithValue("@sptuserad", label1.Text);
            sepeteEkle.ExecuteNonQuery();



            baglanti.Close();*/
            baglanti.Open();

            SqlCommand sepeteEkle = new SqlCommand("SepeteEkle", baglanti);
            sepeteEkle.CommandType = CommandType.StoredProcedure;

            sepeteEkle.Parameters.AddWithValue("@spttutar", genelToplam);
            sepeteEkle.Parameters.AddWithValue("@sptuserad",label1.Text);


            sepeteEkle.ExecuteNonQuery();



            baglanti.Close();
            MessageBox.Show("SEPET BAŞARIYLA EKLENDİ!!!!");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void KARGO_Click(object sender, EventArgs e)
        {
            kullaniciKargo kullaniciKargo = new kullaniciKargo();
            kullaniciKargo.Show();
        }
    }
}
