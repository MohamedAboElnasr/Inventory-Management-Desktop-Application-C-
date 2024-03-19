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

namespace InventoryManagementSystem
{
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=InventoryDB.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader adr;
        public UserForm()
        {
            InitializeComponent();
            loadUser();
        }
        public void loadUser()
        {
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUser", con);
            con.Open();
            adr = cm.ExecuteReader();
            int i = 0;
            while (adr.Read())
            {
                i++;
                dgvUser.Rows.Add(i, adr[0].ToString(), adr[1].ToString(), adr[2].ToString(), adr[3].ToString());
            }
            adr.Close();
            con.Close();



        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colmName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colmName == "edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtPassword.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.btnSave.Enabled = false;
                userModule.btnUpdate.Enabled = true;
                userModule.txtUserName.Enabled = false;
                userModule.ShowDialog();
                           
            }
            else if (colmName == "delete")
            {
                if (MessageBox.Show("Are You Sure You Want to delete this, user? ", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successufly deleted");

                }
            }
            loadUser();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();
            loadUser();
        }
    }
}
