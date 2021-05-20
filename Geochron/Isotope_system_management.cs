using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geochron
{
    public partial class Isotope_system_management : Form
    {
        
        public Isotope_system_management()
        {
            InitializeComponent();
            listBox1.DataSource = Master.isc.Iso_Names();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IS_creation Create = new IS_creation();
            Create.TheParent = this;
            Create.ShowDialog(this);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Isotope_system_management_Load(object sender, EventArgs e)
        {
            
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void IS_List_Changed()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = Master.isc.Iso_Names(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int del = listBox1.SelectedIndex;
            Master.isc.Delete_From_Collection(del);
            IS_List_Changed();
        }
    }
}
