using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Geochron
{
    public partial class Isochrone : Form
    {
        List<double> x;
        List<double> y;
        public Isochrone(List<double> c_ra_norm, List<double> c_rg_norm)
        {
            InitializeComponent();
            label1.Text = "Вычисленный возраст породы: " + Convert.ToString(Convert.ToInt32(Master.cur_calc.age))+" Ma"+"\n"+
                "СКВО: "+Convert.ToString(Master.cur_calc.MSE);
            x = c_ra_norm;
            y = c_rg_norm;
            double min_x = x.ToList().Min();
            double max_x = x.ToList().Max();
            chart1.Titles.Add("Изохрона ("+Master.isc.Isotope_List[Master.cur_calc.used_is_index].Get_Name()+" метод)");
            chart1.Series.Clear();
            chart1.Series.Add("Data");
            chart1.Series.Add("Line");
            chart1.Series["Data"].ChartType = SeriesChartType.Point;
            chart1.Series["Line"].ChartType = SeriesChartType.Line;
            for (int i = 0; i < x.Count; i++)
            {
                chart1.Series[0].Points.AddXY(x[i], y[i]);
            }
            chart1.Series[1].Points.AddXY(min_x, Master.cur_calc.B + min_x * Master.cur_calc.A);
            chart1.Series[1].Points.AddXY(max_x, Master.cur_calc.B + max_x * Master.cur_calc.A);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_results = new SaveFileDialog();
            save_results.Filter = ".txt files (*.txt)|*.txt|All files (*.*)|*.*";
            save_results.FilterIndex = 1;
            save_results.RestoreDirectory = true;
            if(save_results.ShowDialog()==DialogResult.OK)
            {
                if (Master.cur_calc != null)
                {
                    string[] lines = { "Изотопная система: " + Master.isc.Isotope_List[Master.cur_calc.used_is_index].Get_Name(),
                        "Число анализов: "+Convert.ToString(Master.cur_calc.c_ra_norm.Count),
                        "Вычисленный возраст: "+ Convert.ToString(Convert.ToInt32(Master.cur_calc.age))+ " Ma",
                        "СКВО: "+Convert.ToString(Master.cur_calc.MSE)};

                    using (StreamWriter writer = new StreamWriter(save_results.OpenFile()))
                    {
                        foreach (string line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                    
            }
        }

        private void Isochrone_Load(object sender, EventArgs e)
        {
            
        }
    }
}
