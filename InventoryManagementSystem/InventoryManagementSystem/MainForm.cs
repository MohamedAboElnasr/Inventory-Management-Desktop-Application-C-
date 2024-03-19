using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {    activeForm.Close(); }
                activeForm = childForm;
                activeForm.TopLevel = false;
                activeForm.FormBorderStyle = FormBorderStyle.None;
                activeForm.Dock = DockStyle.Fill;
                Mainpanel.Controls.Add(childForm);
                Mainpanel.Tag = childForm;
            activeForm.BringToFront();
            activeForm.Show();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void customerButton1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());
        }

        private void Mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new customerForm());


        }

        private void btCat_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm());
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void NoteTake(object sender, EventArgs e)
        {
            openChildForm(new NoteModule());
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
