using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    public class Csaomag : Kuldemeny
    {
        public double Tomeg { get; set; }

        public override string ToString()
        {
            return string.Format("({0}) {1} {2} {3} {4}", FeladasDat, ID, Cimzett, Irszam, Varos, Cim);
        }
    }
}
