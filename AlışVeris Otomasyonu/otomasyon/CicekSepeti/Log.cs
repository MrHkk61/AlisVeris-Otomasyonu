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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AdminUrun adminUrun = new AdminUrun();
            adminUrun.Show();
            this.Hide();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");
        SqlDataAdapter da;

        DataSet ds;
        private void Log_Load(object sender, EventArgs e)

        {
           
            DataSet dataseti = new DataSet();
            da = new SqlDataAdapter("Select *From TBLLOGKAYIT", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "TBLLOGKAYIT");
            dataGridView1.DataSource = ds.Tables["TBLLOGKAYIT"];
            dataGridView1.Columns[1].Width = 700;// içerigimiz güzkmesi için 2. column un boyutunu arttırdım
            baglanti.Close();
        }
    }
}
