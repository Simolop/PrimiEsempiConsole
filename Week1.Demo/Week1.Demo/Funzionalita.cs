using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Demo.Classi;
using Week1.Demo.Interfacce;

namespace Week1.Demo
{
    public class Funzionalita
    {
        public enum State
        {
            New,
            Open,
            OnHold,
            Closed
        }

        public static void EsercizioTipo()
        {
            //value type vs reference type
            
            //VALUE TYPE:

            //Booleani
            bool x = true;
            bool y = false;

            bool z = !x; //! rappresenta il not 

            Console.WriteLine("Valore di z: {0}", z);

            //Numerici
            int i = 0;
            int j = 34;

            int numero = 1 * (3 + 5) * 7;

            float f = 1f / 3f;
            double doubl = 1d / 3d;
            decimal dec = 1m / 3m;

            Console.WriteLine("Decimali: ");
            Console.WriteLine("f: {0}", f);
            Console.WriteLine("doubl: {0}", doubl);
            Console.WriteLine("dec: {0}", dec);

            Console.WriteLine($"Float valore massimo: {float.MaxValue} - valore minimo: {float.MinValue}");
            Console.WriteLine($"Double valore massimo: {double.MaxValue} - valore minimo: {double.MinValue}");
            Console.WriteLine($"Decimal valore massimo: {decimal.MaxValue} - valore minimo: {decimal.MinValue}");


            //DateTime
            DateTime now = DateTime.Now;
            DateTime today = DateTime.Today;
            DateTime data = new DateTime(2021, 05, 05);

            DateTime tomorrow = now.AddDays(1);
            DateTime post5Hours = now.AddHours(5);

            Console.WriteLine($"Tomorrow: {tomorrow}");
            Console.WriteLine($"In 5 hours: {post5Hours}");

            //Enum
            State myState = State.Open;
           
            if(myState == State.New)
            {
                Console.WriteLine("La mia variabile contiene New");
            } else
            {
                Console.WriteLine($"La mia variabile myState contiene {myState}");
            }

            //REFERENCE TYPE
            //String
            string nome = "Simona";
            nome = "Federica"; //viene creato un oggetto aggiuntivo e soo in un secondo momento simona viene modificato


            int numeroCaratteri = nome.Length;
            Console.WriteLine($"Il nome comincia per S {nome.StartsWith("S")}");

            Console.Clear();

            Persona p = new Persona
            {
                //specifico quali caratteristiche ha la persona
                Nome = "Simona",
                Cognome = "Loperfido",
                DataNascita = new DateTime(1996, 5, 9)
            };

            Console.WriteLine(p.PersonString());


            Console.WriteLine(p.Eta);

            Manager m = new Manager
            {
                Nome = "Mario",
                Cognome = "Rossi",
                DataNascita = DateTime.Today
            };

            Console.WriteLine(m.Eta);
            Console.WriteLine(m.Stipendio);

            Persona manager2 = new Manager
            {
                Nome = "Luca",
                Cognome = "Verdi",
                DataNascita = new DateTime(1970, 4, 5)
            };
            manager2.PersonString();
            Console.WriteLine(manager2.PersonString());
            manager2.CalcolaCodiceFiscale();

            IEntita manager3 = new Manager();
            manager3.CalcolaCodiceFiscale();
            
            
        }
    }
}
