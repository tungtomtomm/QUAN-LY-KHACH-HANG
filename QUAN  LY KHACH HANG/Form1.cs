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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QUAN__LY_KHACH_HANG
{
    public partial class Form1 : Form
    {
        string connectionstring = @"Data Source=DESKTOP-CO09DFI\MSSQLSERVER01;Initial Catalog=QLKH;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader doc;
        string sql;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionstring);
            hienthikhachhang();
            hienthidichvu();
            
        }
        private void hienthikhachhang()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            con.Open();
            sql = @"select * from khachhang";
            cmd = new SqlCommand(sql, con);
            doc = cmd.ExecuteReader();
            i = 0;
            while (doc.Read())
            {
                listView1.Items.Add(doc[0].ToString());
                listView1.Items[i].SubItems.Add(doc[1].ToString());
                listView1.Items[i].SubItems.Add(doc[2].ToString());
                listView1.Items[i].SubItems.Add(doc[3].ToString());
                i++;
            }
            con.Close();
        }
        private void hienthidichvu()
        {
            listView2.Items.Clear();
            listView2.View = View.Details;
            con.Open();
            sql = @"select * from dichvu";
            cmd = new SqlCommand(sql, con);
            doc = cmd.ExecuteReader();
            i = 0;
            while (doc.Read())
            {
                listView2.Items.Add(doc[0].ToString());
                listView2.Items[i].SubItems.Add(doc[1].ToString());
                listView2.Items[i].SubItems.Add(doc[2].ToString());
                i++;
            }
            con.Close();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtHoten.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtSDT.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtDiachi.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            con.Open();
            sql = @"insert into khachhang(makh, hoten, sdt, dchi) 
            values ('"+txtMaKH.Text+@"','"+txtHoten.Text+@"','"+txtSDT.Text+@"','"+txtDiachi.Text+@"')";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            hienthikhachhang();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            con.Open();
            sql = @"update khachhang set
                    makh = '"+txtMaKH.Text+@"',
                    hoten = '"+txtHoten.Text+@"',
                    sdt = '"+txtSDT.Text+@"',
                    dchi = '"+txtDiachi.Text+ @"'
                    where (makh = '"+txtMaKH.Text+@"')";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            hienthikhachhang();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            con.Open();
            sql = @"delete from khachhang where
                    makh = '" + txtMaKH.Text+ @"'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            hienthikhachhang();
        }
        private void chonmadv()
        {
            con.Open();
            sql = @"select * from dichvu where madv = '"+txtMadv.Text+"'";
            cmd = new SqlCommand(sql, con);
            doc = cmd.ExecuteReader();
            while (doc.Read())
            {
                listView3.Items.Add(doc[0].ToString());
                listView3.Items.Add(doc[1].ToString());
                listView3.Items.Add(doc[2].ToString());
            }
            con.Close();
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            txtMadv.Text = listView2.SelectedItems[0].SubItems[0].Text;
            chonmadv();
            listView3.Items.Clear();
            listView3.View = View.Details;
        }
    }
}
