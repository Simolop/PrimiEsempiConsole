using System;
using System.Collections.Generic;
using System.Linq;

namespace Week1.Demo.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Valutazione> voti = Program.CaricaValutazioni();
            //recupera tutti i voti di Francesca
            //Lambda Expression
            var votiFrancesca = voti.Where(votazione => votazione.NomeStudente.Equals("Francesca"));
            //oppure l'equivalente:
            //query syntax o fluent api
            var votiFrancescaApi =
                from valutazione in voti
                where valutazione.NomeStudente.Equals("Francesca")
                select valutazione;

            foreach(Valutazione valutazione in votiFrancesca)
            {
                Console.WriteLine($"Nome: {valutazione.NomeStudente}" +
                    $" Data: {valutazione.DataValutazione.ToShortDateString()}" +
                    $" Voto: {valutazione.Voto}" +
                    $" Materia: {valutazione.Materia}");
            }

            Console.WriteLine("-----------");

            foreach(Valutazione valutazione in votiFrancescaApi)
            {
                Console.WriteLine($"Nome: {valutazione.NomeStudente}" +
                    $" Data: {valutazione.DataValutazione.ToShortDateString()}" +
                    $" Voto: {valutazione.Voto}" +
                    $" Materia: {valutazione.Materia}");
            }


            //voti matematica ordinati per data valutazione
            //lambda expression
            var votiMatematicaOrdinati = voti
                .Where(v => v.Materia == Materia.Matematica)
                .OrderBy(v => v.DataValutazione)
                .ThenBy(v => v.Voto) //se voglio fare un altro ordinamento, es anche per voto
                ;

            //equivalente a:
            var votiMatematicaOrdinatiFA =
                from voto in voti
                where voto.Materia == Materia.Matematica
                orderby voto.DataValutazione, voto.Voto descending
                select voto;

            Console.WriteLine("Voti in matematica ordinati");
            foreach (Valutazione valutazione in votiMatematicaOrdinati)
            {
                Console.WriteLine(valutazione.NomeStudente + " " + valutazione.DataValutazione.ToShortDateString() + " " + valutazione.Materia);           
            }

            Console.WriteLine("Voti in matematica ordinati ottenuti con Fluent Api");
            foreach(var val in votiMatematicaOrdinatiFA)
            {
                Console.WriteLine(val.NomeStudente + " " + val.DataValutazione.ToShortDateString() + " " + val.Materia);
            }

           //lambda expression
            var soloVoti = voti
                .Where(v => v.NomeStudente.Equals("Mario"))
                .Select(v => new { v.Voto });
            //equivalente a
            //fluent api
            var soloVotiFA =
                from voto in voti
                where voto.NomeStudente.Equals("Mario")
                select new { voto.Voto };

            Console.WriteLine("Stampa dei voti di Mario");
            foreach(var voto in soloVoti)
            {
                Console.WriteLine(voto.Voto);
            }

            Console.WriteLine("Stampa voti di Mario ottenuti con Fluent Api");
            foreach(var voto in soloVotiFA)
            {
                Console.WriteLine(voto.Voto);
            }

            //Media, max, min voti per ogni studente
            //lambda expression
            var mediaMaxMinVotiStudente = voti
                .GroupBy(v => v.NomeStudente, //specifico la proprietà su cui raggruppare
                (key, grp) => new { Nome = key, //specifico caratteristiche di ogni gruppo
                                    Media = grp.Average(v => v.Voto),
                                    Max = grp.Max(v => v.Voto),
                                    Min = grp.Min(v => v.Voto)
                });

            //equivalente a
            //fluent Api
            var mediaMaxMinStudenteFA =
                from voto in voti
                group voto by voto.NomeStudente into grp
                select new
                {
                    Nome = grp.Key,
                    Media = grp.Average(v => v.Voto),
                    Max = grp.Max(v => v.Voto),
                    Min = grp.Min(v => v.Voto)
                };

            Console.WriteLine("Stampa media, max e min per ogni studente");
            foreach(var gruppo in mediaMaxMinVotiStudente)
            {
                Console.WriteLine($"Nome: {gruppo.Nome} -" +
                    $"Media voti: {gruppo.Media} -" +
                    $"Voto massimo: {gruppo.Max} -" + 
                    $"Voto minimo: {gruppo.Min}");
            }

            Console.WriteLine("Stampa media, max e min per ogni studente con Fluent Api");
            foreach (var gruppo in mediaMaxMinStudenteFA)
            {
                Console.WriteLine($"Nome: {gruppo.Nome} -" +
                    $"Media voti: {gruppo.Media} -" + 
                    $"Voto massimo: {gruppo.Max} -" +
                    $"Voto minimo: {gruppo.Min}");
            }


        }

        public static List<Valutazione> CaricaValutazioni()
        {
            List<Valutazione> valutazione = new List<Valutazione>() 
            { 
                new Valutazione 
                {NomeStudente = "Mario", 
                DataValutazione= new DateTime(2021, 5, 5),
                Voto = 7,
                Materia = Materia.Geografia},

                new Valutazione
                {NomeStudente = "Mario",
                DataValutazione= new DateTime(2021, 4, 25),
                Voto = 3,
                Materia = Materia.Matematica},

                new Valutazione
                {NomeStudente = "Tiziana",
                DataValutazione= new DateTime(2021, 4, 27),
                Voto = 6,
                Materia = Materia.Italiano},

                new Valutazione
                {NomeStudente = "Francesca",
                DataValutazione= new DateTime(2021, 5, 5),
                Voto = 8,
                Materia = Materia.Storia},

                new Valutazione
                {NomeStudente = "Francesca",
                DataValutazione= new DateTime(2021, 5, 13),
                Voto = 4,
                Materia = Materia.Matematica},
            };

            return valutazione;
        }
    }
}
