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
    public partial class BayiLog : Form
    {
        public BayiLog()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");
        SqlDataAdapter da;

        DataSet ds;
        private void BayiLog_Load(object sender, EventArgs e)
        {
            DataSet dataseti = new DataSet();
            da = new SqlDataAdapter("Select *From TBLBAYİLOG", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "TBLBAYİLOG");
            dataGridView1.DataSource = ds.Tables["TBLBAYİLOG"];
            dataGridView1.Columns[1].Width = 700;// içerigimiz gözükmesi için 2. column un boyutunu arttırdım
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminBayiGiris adminBayiGiris = new adminBayiGiris();
            adminBayiGiris.Show();
            this.Hide();
        }
    }
}
