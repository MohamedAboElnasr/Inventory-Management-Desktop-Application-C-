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

    public partial class customerForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=InventoryDB.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader adr;
        public customerForm()
        {
            InitializeComponent();
            loadCustomer();

        }
        public void loadCustomer()
        {
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbCustomer", con);
            con.Open();
            adr = cm.ExecuteReader();
            int i = 0;
            while (adr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, adr[0].ToString(), adr[1].ToString(), adr[2].ToString());
            }
            adr.Close();
            con.Close();



        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            customerModule moduleForm = new customerModule();
            moduleForm.btnSave.Enabled = true;
            moduleForm.btnUpdate.Enabled = false;
            moduleForm.ShowDialog();
            loadCustomer();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colmName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colmName == "edit")
            {

                customerModule customerModule = new customerModule();
                customerModule.Customerid.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                customerModule.txtName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                customerModule.txtPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                customerModule.btnSave.Enabled = false;
                customerModule.btnUpdate.Enabled = true;
                customerModule.ShowDialog();

            }
            else if (colmName == "delete")
            {
                if (MessageBox.Show("Are You Sure You Want to delete this, user? ", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbCustomer WHERE id LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successufly deleted");

                }
            }
            loadCustomer();

        }
    }
}

