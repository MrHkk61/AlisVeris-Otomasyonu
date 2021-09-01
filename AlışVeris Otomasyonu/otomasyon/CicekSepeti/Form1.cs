using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CicekSepeti
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        SqlDataReader kontrol;
        


        public static string kullaniciAdi;
        public static int kullaniciId;

        
        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
           // SqlCommand hata = new SqlCommand("HataliGiris", baglanti);
           // hata.CommandType = CommandType.StoredProcedure;
            SqlCommand giris = new SqlCommand("girisKontol", baglanti);// PROCEDURE 
            giris.CommandType = CommandType.StoredProcedure;// PROCEDURE olduğunu belirttik
            giris.Parameters.AddWithValue("@user", textBox1.Text);
            giris.Parameters.AddWithValue("@pass", textBox2.Text);
           
            //hata.Parameters.AddWithValue("@Auser", textBox1.Text);

         

            kontrol = giris.ExecuteReader();
            if (kontrol.Read())
            {
                kullaniciAdi = textBox1.Text;
                MessageBox.Show("GİRİŞ BAŞARILI");
           
                arayuz arayuz = new arayuz();
                arayuz.Show();
                this.Hide();
                

            }
            else
            {
               // hata.ExecuteNonQuery();
                
                MessageBox.Show("GİRİŞ BAŞARISIZ");
                
            }

            baglanti.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kayıt_Ol kayıt_Ol = new Kayıt_Ol();
            kayıt_Ol.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
           else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminBayiGiris adminBayiGiris = new adminBayiGiris();
            adminBayiGiris.Show();
            this.Hide();
        }
    }
}
