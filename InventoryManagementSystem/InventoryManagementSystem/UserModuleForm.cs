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
using System.Security.Cryptography.X509Certificates;

namespace InventoryManagementSystem
{
    public partial class UserModuleForm : Form
    {
        
       SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=InventoryDB.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        public UserModuleForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UserModuleForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure You Want to save this, user? ","Saving Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {                    
                    cm = new SqlCommand("INSERT INTO tbUser(username,fullname,password,phone) VALUES(@username,@fullname,@password,@phone)", con);
                    cm.Parameters.AddWithValue("@username", txtUserName.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPassword.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();                    
                    con.Close();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
           
           
         }
        public void clear()
        {
            txtFullName.Clear();
            txtPassword.Clear();
            txtUserName.Clear();
            txtPhone.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure You Want to update this, user? ", "update Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbUser SET fullname=@fullname,password=@password,phone=@phone WHERE username LIKE '"+ txtUserName.Text+"'", con);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPassword.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successufly updated");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
