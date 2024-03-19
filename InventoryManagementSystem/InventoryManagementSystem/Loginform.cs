using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace InventoryManagementSystem
{
    public partial class Loginform : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=InventoryDB.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Loginform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", con);
                cm.Parameters.AddWithValue("@username", txtName.Text);
                cm.Parameters.AddWithValue("@password", txtPass.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    MessageBox.Show("Welcome " + dr["fullname"].ToString() , "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm main = new MainForm();
                    this.Hide();
                    main.ShowDialog();
                    

                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "ACCESS DENITED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)  txtPass.UseSystemPasswordChar = false;
                           
            else
                txtPass.UseSystemPasswordChar = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtPass.Text = string.Empty;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }
     


        
    }
}
