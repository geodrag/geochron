using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Geochron
{
    internal class Isotope_System
    {
        string radiogenic;
        string radioactive;
        int k_fission;
        internal double hl;
        public Isotope_System(string radiogenic, string radioactive, int k, double half_life)
        {
            this.radiogenic = radiogenic;
            this.radioactive = radioactive;
            this.k_fission = k;
            this.hl = half_life;
        }
        public string Get_Name()
        {
            string result;
            result = this.radiogenic + '/' + this.radioactive;
            return result;
        }
    }
    internal class Isotope_Systems_Collection
    {
        internal List<Isotope_System> Isotope_List = new List<Isotope_System>();
        public void Add_To_Collection(Isotope_System a)
        {
            Isotope_List.Add(a);
        }
        public void Delete_From_Collection(int index)
        {
            if (Isotope_List.Count>0)
            { Isotope_List.RemoveAt(index); }
            
        }
        public List<string> Iso_Names()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < Isotope_List.Count; i++)
            {
                result.Add(Isotope_List[i].Get_Name());
            }
            return result;
        }
        public void IS_dump()
        {

        }
    }
    internal class Calc
    {
        internal List<double> c_ra_norm = new List<double>();
        internal List<double> c_rg_norm = new List<double>();
        internal int used_is_index;
        internal double A, B, age, MSE;
        internal void read_csv(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                //List<string> f_isotope_proportion = new List<string>();
                //List<string> s_isotope_proportion = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    this.c_ra_norm.Add(System.Convert.ToDouble(values[0]));
                    this.c_rg_norm.Add(System.Convert.ToDouble(values[1]));
                }
            }
        }

        internal void set_is(int index)
        {
            this.used_is_index = index;
        }
        internal Calc()
        {
            
        }
        internal Tuple<double,double> calculate()
        {
            int n = c_ra_norm.Count;
            List<double> el_wise = new List<double>();
            List<double> sq_c_ra = new List<double>();
            List<double> sq_c_rg = new List<double>();
            for (int i=0; i<c_ra_norm.Count; i++) //Some pre-calculated values for future equation readability
            {
                el_wise.Add(c_ra_norm[i] * c_rg_norm[i]);
                sq_c_ra.Add(Math.Pow(c_ra_norm[i], 2));
                sq_c_rg.Add(Math.Pow(c_rg_norm[i], 2));
                
            }
            double a = (n * el_wise.Sum() - c_rg_norm.Sum() * c_ra_norm.Sum()) / (n * sq_c_ra.Sum() - Math.Pow(c_ra_norm.Sum(), 2)); //Geochrone slope
            double b = c_rg_norm.Sum() / n - (a * c_ra_norm.Sum() / n); //Initial amount of radiogenic isotope
            double half_life = Master.isc.Isotope_List[used_is_index].hl;
            double age = half_life * Math.Log(a + 1) / Math.Log(2);
            this.A = a;
            this.B = b;
            this.age = age/1000000;
            double MSE()
            {
                List<double> square_deviations = new List<double>();
                for (int i = 0; i < c_ra_norm.Count; i++)
                {
                    square_deviations.Add(Math.Pow((A * c_ra_norm[i] + B) - c_rg_norm[i], 2));
                } 
                return square_deviations.Sum()/c_rg_norm.Count;
            }
            double MSE_val = MSE();
            this.MSE = MSE_val;
            return Tuple.Create(age/1000000, MSE_val);
        }

    }
}