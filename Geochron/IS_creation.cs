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
    
    public partial class IS_creation : Form
    {
       

        internal Isotope_system_management TheParent;
        public IS_creation()
        {
            InitializeComponent();
            
        }
        
        internal void button1_Click(object sender, EventArgs e)
        {
            Isotope_System IS = new Isotope_System(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox4.Text)*1000000);
            Master.isc.Add_To_Collection(IS);
            TheParent.IS_List_Changed();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
