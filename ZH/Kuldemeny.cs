using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    abstract public class Kuldemeny
    {
        #region Propertys
        public int ID { get; set; } = 1;
        public string Cimzett { get; set; }
        public string Irszam { get; set; }
        public string Varos { get; set; }
        public string Cim { get; set; }
        public DateTime FeladasDat { get; set; }
        #endregion
    }
}
