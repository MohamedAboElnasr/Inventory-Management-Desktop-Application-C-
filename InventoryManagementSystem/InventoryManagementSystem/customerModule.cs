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
namespace InventoryManagementSystem
{

    public partial class customerModule : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=InventoryDB.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        public customerModule()
        {

            InitializeComponent();
        }
        public void clear()
        {
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;

           

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure You Want to save this, Customer? ", "Saving Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbCustomer(cname,cphone) VALUES(@cname,@cphone)", con);
                    cm.Parameters.AddWithValue("@cname", txtName.Text);
                    cm.Parameters.AddWithValue("@cphone", txtPhone.Text);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure You Want to update this, Customer? ", "update Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbCustomer SET cname=@cname,cphone=@cphone WHERE id LIKE '" + Customerid.Text + "'", con);
                    cm.Parameters.AddWithValue("@cname", txtName.Text);
                    cm.Parameters.AddWithValue("@cphone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been successufly updated");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void customerModule_Load(object sender, EventArgs e)
        {

        }
    }   
        }
    

