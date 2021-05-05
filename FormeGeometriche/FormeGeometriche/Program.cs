using System;
using System.IO;

namespace FormeGeometriche
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangolo t = new Triangolo()
            {
                Nome = "triangolo",
                BaseT = 4,
                Altezza = 3
            };


            Rettangolo r = new Rettangolo()
            {
                Nome = "rettangolo",
                Larghezza = 5,
                Altezza = 4
            };

            Cerchio c = new Cerchio()
            {
                Nome = "cerchio",
                Raggio = 3,
                X = 1,
                Y = 2
            }; 

            Console.WriteLine($"L'area del {t.Nome} è: {t.Area()}");

            Console.WriteLine($"L'area del {r.Nome} è: {r.Area()}");

            Console.WriteLine($"L'area del {c.Nome} è: {c.Area()}");

            IFileSerializable rettangolo = new Rettangolo()
            {
                Nome = "Rettangolo",
                Larghezza = 5,
                Altezza = 4
            }; 

            rettangolo.SaveToFile("fileRettangolo.txt");
            rettangolo.LoadFromFile("FileLoadRett.txt");

            IFileSerializable cerchio = new Cerchio();
            cerchio.LoadFromFile("cerchio.txt");
            cerchio.SaveToFile("cerchioSalvato.txt");
            
   
        }

    }
}
