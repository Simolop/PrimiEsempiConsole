using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Demo.Interfacce;

namespace Week1.Demo.Classi
{ 

    public class Persona : IEntita
    {
        //proprietà
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }

        public int Eta 
        {
            get
            {
                return DateTime.Today.Year - DataNascita.Year;
            }
        }

        public string CalcolaCodiceFiscale()
        {
            return Nome.Substring(0, 3) + Cognome.Substring(0, 3) + DataNascita.Year;
        }

        //metodo
        public virtual string PersonString()
        {
            return "Nome: " + Nome + " " + "Cognome: " + Cognome + " " + "Data di nascita: " + DataNascita.ToShortDateString() + " " + "Eta: " + Eta + " ";
        }
        
        private int CalcolaEta()
        {
            return DateTime.Today.Year - DataNascita.Year;
            
        }

    }
}
