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
    public partial class Main_Window : Form
    {

        public Main_Window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculation CalcForm = new Calculation();
            CalcForm.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Isotope_system_management Iso_Man = new Isotope_system_management();
            Iso_Man.ShowDialog(this);
        }
        
    }
}
