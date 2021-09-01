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
    public partial class AdminUrun : Form
    {
        public AdminUrun()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;// secilen hücre için
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();// textbox1 e 0 indisi getir 
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }
        SqlDataAdapter da;

        private void yenile()
        {
            baglanti.Open();
            string kayit = "SELECT * from TBL_URUN";
            //musteriler tablosundaki tüm kayıtları çekecek olan sql sorgusu.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
            dataGridView1.DataSource = dt;
            //Formumuzdaki DataGridViewin veri kaynağını oluşturduğumuz tablo olarak gösteriyoruz.
            baglanti.Close();
        }

        DataSet ds;
        private void AdminUrun_Load(object sender, EventArgs e)
        {
            DataSet dataseti = new DataSet();
            da = new SqlDataAdapter("Select *From TBL_URUN", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "TBL_URUN");
            dataGridView1.DataSource = ds.Tables["TBL_URUN"];
            baglanti.Close();
            yenile();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand urunEkle = new SqlCommand("insert into TBL_URUN(UrunAd,UrunTur,UrunStok,UrunFiyat,UrunMiktar) values (@U1,@U2,@U3,@U4,@U5) ", baglanti);
            urunEkle.Parameters.AddWithValue("@U1", textBox2.Text);
            urunEkle.Parameters.AddWithValue("@U2", textBox3.Text);
            urunEkle.Parameters.AddWithValue("@U3", textBox4.Text);
            urunEkle.Parameters.AddWithValue("@U4", textBox5.Text);
            urunEkle.Parameters.AddWithValue("@U5", textBox6.Text);


            urunEkle.ExecuteNonQuery();
            MessageBox.Show("ÜRÜN BAŞARILI ŞEKİLDE EKLENDİ!");


            baglanti.Close();
            yenile();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From TBL_URUN Where Urunİd=@id", baglanti);
            sil.Parameters.AddWithValue("@id", textBox1.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ÜRÜN BAŞARILI ŞEKİLDE SİLİNDİ!");
            yenile();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.dataGridView1.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            profilDuzenle profilDuzenle = new profilDuzenle();
            profilDuzenle.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand guncelle = new SqlCommand("UPDATE TBL_URUN SET  UrunAd=@ad, UrunTur=@tur,UrunStok=@stok,UrunFiyat=@fiyat,UrunMiktar=@miktar WHERE Urunİd=@id", baglanti);
            guncelle.Parameters.AddWithValue("@id", textBox1.Text);
            guncelle.Parameters.AddWithValue("@ad", textBox2.Text);
            guncelle.Parameters.AddWithValue("@tur", textBox3.Text);
            guncelle.Parameters.AddWithValue("@stok", textBox4.Text);
            guncelle.Parameters.AddWithValue("@fiyat", textBox5.Text);
            guncelle.Parameters.AddWithValue("@miktar", textBox6.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ÜRÜN BAŞARIYLA GÜNCELLENDİ");
            yenile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BayiLog BayiLog = new BayiLog();
            BayiLog.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
