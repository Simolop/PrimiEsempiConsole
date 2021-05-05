using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week1.Demo.Async_Parallel
{
    class Metodi
    {
        public static void ForNormale()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Start" + i);
                //Aggiungo una chiamata che introduce un elemento di ritardo
                Task.Delay(10).Wait();
                Console.WriteLine("End" + i);
            }
        }

        public static void ForParallelo()
        {
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("Start parallel: " + i);
                Task.Delay(10).Wait();
                Console.WriteLine("End parallel: " + i);
            });
        }


        //versione sincrona del metodo
        public static void MetodoA() 
        {
            Console.WriteLine("Inizio metodo A");
            Thread.Sleep(3000); //3000 = numero di millisecondi 
            Console.WriteLine("Fine metodo A");
        }


        //versione asincrona
        public static async Task MetodoAAsync()
        {
            Console.WriteLine("Inizio metodo async A");
            await Task.Delay(3000); //3000 = numero di millisecondi 
            Console.WriteLine("Fine metodo async A");
        }


        //versione sincrona del metodo
        public static void MetodoB()
        {
            Console.WriteLine("Inizio metodo B");
            Thread.Sleep(3000); //3000 = numero di millisecondi 
            Console.WriteLine("Fine metodo B");
        }


        //versione asincrona
        public static async Task MetodoBAsync()
        {
            Console.WriteLine("Inizio metodo async B");
            await Task.Delay(3000); //3000 = numero di millisecondi 
            Console.WriteLine("Fine metodo async B");
        }



        //versione sincrona del metodo
        public static void MetodoC()
        {
            Console.WriteLine("Inizio metodo C");
            Thread.Sleep(3000); //3000 = numero di millisecondi 
            Console.WriteLine("Fine metodo C");
        }


        //versione asincrona
        public static async Task MetodoCAsync()
        {
            Console.WriteLine("Inizio metodo async C");
            await Task.Delay(3000); //3000 = numero di millisecondi 
            Console.WriteLine("Fine metodo async C");
        }

    }
}
