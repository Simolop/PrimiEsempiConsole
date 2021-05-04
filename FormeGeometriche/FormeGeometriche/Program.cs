using System;

namespace FormeGeometriche
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangolo t = new Triangolo("triangolo", 4, 3);

            Rettangolo r = new Rettangolo("rettangolo", 5, 4);

            Cerchio c = new Cerchio("cerchio", 3);

            Console.WriteLine($"L'area del {t.Nome} è: {t.Area()}");

            Console.WriteLine($"L'area del {r.Nome} è: {r.Area()}");

            Console.WriteLine($"L'area del {c.Nome} è: {c.Area()}");

            IFileSerializable rettangolo = new Rettangolo("Rettangolo", 5, 4);
            rettangolo.SaveToFile("fileRettangolo.txt");
            rettangolo.LoadFromFile("FileLoadRett.txt");


        }

    }
}
