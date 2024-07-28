using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrenci_Kayit_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JNFOI6TN\SQLHASAN;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=False");
        
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * From TBLDERS where OGRNUMARA = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            lblNumara.Text = numara;
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();    lblSinav1.Text = dr[4].ToString();
                lblSinav2.Text = dr[5].ToString();
                lblSinav3.Text = dr[6].ToString();
                lblOrtalama.Text = dr[7].ToString();
                lblDurum.Text = dr[8].ToString();
            }
             if(lblDurum.Text == "True")
             {
                lblDurum.Text = "Geçti";
             }
             else
             {
                lblDurum.Text = "Kaldı";
             }
           
        }
    }
}
