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
    public partial class Kayıt_Ol : Form
    {
        public Kayıt_Ol()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");

        private void Kayıt_Ol_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
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
            Form1 Form1 = new Form1();
            Form1.Show();
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
    }
}
