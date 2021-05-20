using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Geochron
{
    public partial class Calculation : Form
    {
        public Calculation()
        {
            InitializeComponent();
            listBox1.DataSource=Master.isc.Iso_Names();
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            Master.cur_calc = new Calc();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog1.FileName;
            Master.cur_calc.read_csv(filename);
        }

        private void button1_Click(object sender, EventArgs e)
        {if (Master.cur_calc.c_ra_norm != null)
            {
                int index = listBox1.SelectedIndex;
                Master.cur_calc.set_is(index);
                double age = Master.cur_calc.calculate().Item1;
                double MSE = Master.cur_calc.calculate().Item2;
                label2.Text = "Возраст породы: "+Convert.ToString(Convert.ToInt32(age))+" Ma"+"\n"+"СКВО: "+Convert.ToString(MSE);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        { if (Master.cur_calc != null)
            { Isochrone Graph = new Isochrone(Master.cur_calc.c_ra_norm, Master.cur_calc.c_rg_norm);
                Graph.ShowDialog(this);
            }
            
            
        }
    }
    
}
