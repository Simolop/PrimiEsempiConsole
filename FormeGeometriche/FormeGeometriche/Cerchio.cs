using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    class Cerchio : FormeGeo
    {
        public double Raggio { get; set; }

        public Cerchio (string nome, double raggio)
            :base(nome)
        {
            Raggio = raggio;
        }
        public override double Area()
        {
            return Raggio * Raggio * Math.PI;
        }
    }
}
