using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PraktikumADO
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;

        private void koneksi()
        {
            conn = new MySqlConnection("Server = localhost; database = DBAkademikADO; UID = root; " +
            "Password = 21914113");
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            koneksi();
            conn.Open();
            MessageBox.Show("Koneksi ke Database Berhasil");
            conn.Close();
        }

        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            koneksi();
            conn.Open();
            string query = "select count(*) from Mahasiswa";
            cmd = new MySqlCommand(query, conn);
            int jumlah = Convert.ToInt32(cmd.ExecuteScalar());
            txtHasil.Text = jumlah.ToString();
            conn.Close();
        }

        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            koneksi();
            conn.Open();
            string query = "select count(*) from MataKuliah";
            cmd = new MySqlCommand(query, conn);
            int jumlah = Convert.ToInt32(cmd.ExecuteScalar());
            txtHasil.Text = jumlah.ToString();
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            koneksi();
            conn.Open();
            string query = "update mahasiswa set Alamat='Yogyakarta' where NIM='23110100001'";
            cmd = new MySqlCommand(query, conn);
            int hasil = cmd.ExecuteNonQuery();
            MessageBox.Show("Jumlah baris terpengaruh: " + hasil);
            conn.Close();
        }

        private void btnHitungDosen_Click(object sender, EventArgs e)
        {
            koneksi();
            conn.Open();
            cmd = new MySqlCommand("SELECT COUNT(*) FROM Dosen", conn);
            txtHasil.Text = cmd.ExecuteScalar().ToString();
            conn.Close();
        }
    }
}
