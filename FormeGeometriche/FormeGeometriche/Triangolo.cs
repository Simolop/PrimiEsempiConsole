using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    class Triangolo : FormeGeo
    {
        public double BaseT { get; set; }
        public double Altezza { get; set; }

        public Triangolo (string nome, double baseT, double altezza)
            :base(nome)
        {
            BaseT = baseT;
            Altezza = altezza;

        }
        public override double Area()
        {
            return (BaseT * Altezza) / 2;
        }
    }
}
