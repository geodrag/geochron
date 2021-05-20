using System;
namespace Geochron
{
    internal class Isotope_System
    {
        string radiogenic;
        string radioactive;
        int k_fission;
        float hl;
        public Isotope_System(string radioact_isotope, string radiogen_isotope, int k, float half_life)
        {
            this->radioactive = radioact_isotope;
            this->radiogenic = radiogen_isotope;
            this->k_fission = k;
            this->hl = half_life;
        }
    }
}
