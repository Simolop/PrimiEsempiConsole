using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    class Rettangolo : FormeGeo
    {
        public double Larghezza { get; set; }
        public double Altezza { get; set; }

        public Rettangolo(string nome, double larghezza, double altezza)
            : base(nome)
        {
            Larghezza = larghezza;
            Altezza = altezza;
        }
        public override double Area()
        {
            return Larghezza * Altezza;
        }

       

       
    }


}
