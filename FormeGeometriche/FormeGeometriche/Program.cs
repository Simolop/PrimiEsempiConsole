using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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


            //Esercitazione LINQ
            List<FormeGeo> figure = new List<FormeGeo>()
            {
                new Cerchio
                {
                    Nome = "Anello",
                    Raggio = 7,
                    X = 10,
                    Y = 8
                },

                new Rettangolo
                {
                    Nome = "Cassa",
                    Larghezza = 19,
                    Altezza = 10
                },

                new Triangolo
                {
                    Nome = "Triangolino",
                    BaseT = 7,
                    Altezza = 9
                },

                new Cerchio
                {
                    Nome = "Anellino",
                    Raggio = 6,
                    X = 3,
                    Y = 7
                },

                new Cerchio
                {
                    Nome = "Cerchietto",
                    Raggio = 3,
                    X = 5,
                    Y = 4
                },

                new Rettangolo
                {
                    Nome = "Auto",
                    Larghezza = 18,
                    Altezza = 10
                },

                new Rettangolo
                {
                    Nome = "Mobile",
                    Larghezza = 28,
                    Altezza = 19
                },

                new Triangolo
                {
                    Nome = "Orecchino",
                    BaseT = 3,
                    Altezza = 5
                },

                new Triangolo
                {
                    Nome = "Ape",
                    BaseT = 6,
                    Altezza = 7
                },

                new Rettangolo
                {
                    Nome = "Tv",
                    Larghezza = 30,
                    Altezza = 25
                },
            };

            //ELENCA TUTTE LE FIGURE CON AREA > 20
            //Lambda Expression
            var areaFigure = figure.Where(f => f.Area() >= 20);
            //Fluent Api
            var areaFigureFA =
                from f in figure
                where f.Area() >= 20
                select f;

            Console.WriteLine("Elenco figure con area > 20 ottenute con Lambda Expression");
            foreach (FormeGeo f in areaFigure)
            {
                Console.WriteLine($"Nome: {f.Nome} -"+
                    $" Area: {f.Area()}");
            }

            Console.WriteLine("Elenco figure con area > 20 ottenute con Fluent Api");
            foreach (FormeGeo f in areaFigureFA)
            {
                Console.WriteLine($"Nome: {f.Nome} -" + 
                    $" Area: {f.Area()}");
            }

            Console.WriteLine(" -------------------- ");

            //ELENCA TUTTE LE FIGURE CON IL NOME CHE INIZIA PER 'A'
            //Lambda Expression
            var nomeA = figure.Where(f => f.Nome.StartsWith("A"));
            //Fluent Api
            var nomeAFA =
                from f in figure
                where f.Nome.StartsWith("A")
                select f;

            Console.WriteLine("Elenco figure con nome che inizia per 'A' ottenute con Lambda Expression");
            foreach (FormeGeo f in nomeA)
            {
                Console.WriteLine($"Nome: {f.Nome} -" + 
                    $" Area: {f.Area()}" );
            }

            Console.WriteLine("Elenco figure con nome che inizia per 'A' ottenute con Fluent Api");
            foreach (FormeGeo f in nomeAFA)
            {
                Console.WriteLine($"Nome: {f.Nome} -" + 
                    $" Area: {f.Area()}" );
            }

            Console.WriteLine(" -------------------- ");

            //ELENCA SOLO I NOMI DELLE FIGURE
            //Lambda Expression
            var nome = figure.Select(f => new { NomeFig = f.Nome });
            //Fluent Api
            var nomeFA =
                from f in figure
                select new { f.Nome};

            Console.WriteLine("Elenco Nome figure ottenute con Lambda Expression");
            foreach (var f in nome)
            {
                Console.WriteLine($"Nome: {f.NomeFig}");
            }

            Console.WriteLine("Elenco nome figure ottenute con Fluent Api");
            foreach (var f in nomeFA)
            {
                Console.WriteLine($" Nome: {f.Nome}");
            }

            Console.WriteLine(" -------------------- ");

            //ELENCA FIGURE IN ORDINE ALFABETICO PER NOME E POI PER AREA DECRESCENTE
            //Lambda Expression
            var figureOrdinate = figure
                .OrderBy(f => f.Nome)
                .ThenByDescending(f => f.Area());
            //Fluent Api
            var figureOrdinateFA =
                from f in figure
                orderby f.Nome
                orderby f.Area() descending
                select f;

            Console.WriteLine("Elenco figure ordinate ottenute con Lambda Expression");
            foreach (FormeGeo f in figureOrdinate)
            {
                Console.WriteLine($"Nome: {f.Nome} -" +
                    $" Area: {f.Area()}");
            }

            Console.WriteLine("Elenco figure ordinate ottenute con Fluent Api");
            foreach (FormeGeo f in figureOrdinateFA)
            {
                Console.WriteLine($"Nome: {f.Nome} -" +
                    $" Area: {f.Area()}");
            }
        }


    }
}
