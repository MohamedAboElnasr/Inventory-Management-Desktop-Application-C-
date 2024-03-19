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
    public partial class NoteModule : Form
    {
        public NoteModule()
        {
            InitializeComponent();
        }
        List<string> strings = new List<string>();

        private void Save_Click(object sender, EventArgs e)
        {
            strings.Add(NoteBox.Text);
            listBox1.Items.Add(NoteBox.Text);
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            
           strings.Remove(listBox1.SelectedItems.ToString());
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void NoteModule_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
