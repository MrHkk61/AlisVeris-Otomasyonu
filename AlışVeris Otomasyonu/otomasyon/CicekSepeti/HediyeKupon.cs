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
    public partial class HediyeKupon : Form
    {
        public HediyeKupon()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MO40VRA\SQLEXPRESS;Initial Catalog=cicekDatabase;Integrated Security=True");
        
        private void HediyeKupon_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            
            
            SqlCommand komut = new SqlCommand("HediyeKupon", baglanti);//StoredProcedure göre  2000 tl ve üzeri alısverişlerde 
            komut.CommandType = CommandType.StoredProcedure;
            
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            baglanti.Close();
        }
    }
}
