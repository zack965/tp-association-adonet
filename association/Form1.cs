using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace association
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ADO d = new ADO();
        private void Form1_Load(object sender, EventArgs e)
        {
            d.connecter();
            RemplirGrid();

        }
        public void RemplirGrid()
        {
            d.cmd.CommandText = "select * from asso";
            d.cmd.Connection = d.cnx;
            d.dr = d.cmd.ExecuteReader();
            //d.dt.Load(d.dr);
            while (d.dr.Read())
            {
                //MessageBox.Show("hello");
                comboBox1.Items.Add(d.dr[0].ToString());
            }
            d.dr.Close();
            //d.deconnecter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d.connecter();
            d.dt.Clear();
            //string id_stg = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //MessageBox.Show(id_stg);
            d.cmd.CommandText = "select * from inscription where id_stg = 1";
            d.cmd.Connection = d.cnx;
            //d.cmd.Parameters.AddWithValue("@id_stg", id_stg);
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            dataGridView2.DataSource = d.dt;
            //d.dr.Close();

        }
        public void remplirDG1()
        {
            //d.connecter();
            //string SelectedItem = comboBox1.SelectedItem.ToString();
            d.cmd.CommandText = "select * from stage where id_asso=@idass";
            d.cmd.Connection = d.cnx;
            d.cmd.Parameters.AddWithValue("@idass", comboBox1.SelectedItem.ToString());
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            dataGridView1.DataSource = d.dt;
            //SelectedItem = string.Empty;
            d.dr.Close();

            //d.deconnecter();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            remplirDG1();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            d.connecter();
            d.dt.Clear();
            //string id_stg = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //MessageBox.Show(id_stg);
            d.cmd.CommandText = "select * from inscription where id_stg = 1";
            d.cmd.Connection = d.cnx;
            //d.cmd.Parameters.AddWithValue("@id_stg", id_stg);
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            dataGridView2.DataSource = d.dt;
            d.dr.Close();
            //remplirDG1();
        }
    }
}
