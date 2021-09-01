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
    public partial class profilDuzenle : Form
    {
        public profilDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            SqlCommand guncelle = new SqlCommand("UPDATE TBLKULLANICI SET  kullanıcıAd=@ad, kullaniciSifre=@sifre,kullaniciPosta=@posta,kullaniciTel=@tel,kullaniciAdres=@adres,kullanıcıDurum=@durum WHERE kullaniciId=@id", baglanti);
            guncelle.Parameters.AddWithValue("@id", textBox4.Text);
            guncelle.Parameters.AddWithValue("@ad", textBox1.Text);
            guncelle.Parameters.AddWithValue("@sifre", textBox2.Text);
            guncelle.Parameters.AddWithValue("@posta", textBox3.Text);
            guncelle.Parameters.AddWithValue("@tel", textBox6.Text);
            guncelle.Parameters.AddWithValue("@adres", richTextBox1.Text);
            guncelle.Parameters.AddWithValue("@durum",comboBox1.SelectedItem);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("BAŞARIYLA GÜNCELLENDİ");
            yenile();
        }
        SqlDataAdapter da;
        
        DataSet ds;
        private void yenile()
        {
            baglanti.Open();
            string kayit = "SELECT * from TBLKULLANICI";
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
        private void profilDuzenle_Load(object sender, EventArgs e)
        {
            DataSet dataseti = new DataSet();
            da = new SqlDataAdapter("Select *From TBLKULLANICI", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "TBLKULLANICI");
            dataGridView1.DataSource = ds.Tables["TBLKULLANICI"];
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            int secilen = dataGridView1.SelectedCells[0].RowIndex;// secilen hücre için
            textBox4.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();// textbox1 e 0 indisi getir 
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            if (dataGridView1.Rows[secilen].Cells[6].Value.ToString() == "True")
            {
                index = 0;//0 ıncı indisimiz true 
                comboBox1.SelectedIndex = index;
            }
            else
            {
                index = 1;
                comboBox1.SelectedIndex = index;
            }
            

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminUrun adminUrun = new AdminUrun();
           adminUrun.Show();
           this.Hide();
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
         baglanti.Open();
              SqlCommand sil = new SqlCommand("Delete From TBLKULLANICI Where KullaniciId=@id", baglanti);
              sil.Parameters.AddWithValue("@id", textBox4.Text);
              sil.ExecuteNonQuery();
              baglanti.Close();
              MessageBox.Show("KİŞİ BAŞARILI ŞEKİLDE SİLİNDİ!");
            yenile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand kayit = new SqlCommand("insert into TBLKULLANICI(kullanıcıAd,kullaniciSifre,kullaniciPosta,kullaniciTel,kullaniciAdres) values (@k1,@k2,@k3,@k4,@k5) ", baglanti);
            kayit.Parameters.AddWithValue("@k1", textBox1.Text);
            kayit.Parameters.AddWithValue("@k2", textBox2.Text);
            kayit.Parameters.AddWithValue("@k3", textBox3.Text);
            kayit.Parameters.AddWithValue("@k4", textBox6.Text);
            kayit.Parameters.AddWithValue("@k5", richTextBox1.Text);
            kayit.ExecuteNonQuery();



            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı!");
            yenile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Log Log = new Log();
            Log.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HediyeKupon hediyeKupon = new HediyeKupon();
            hediyeKupon.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Kargo kargo = new Kargo();
            kargo.Show();
        }
    }
}
