using System;
using Week1.Demo.Pub_Sub;

namespace Week1.Demo
{
    class Program
    {

        //Dichiarazione delegate
        delegate int Somma(int a, int b);
        
        
        static void Main(string[] args)
        {
            //Funzionalita.EsercizioTipo();


            //Delegate
            Somma somma = new Somma(MiaSomma);

            int risultato = somma(1, 2);

            Somma somma2 = new Somma(ReturnZero);

            Somma somma3 = new Somma(Dividi);

            int ris = somma3(4, 2);

            MiaSomma(1, 2); //qui faccio la chiamata senza passare dal delegate

            Console.WriteLine($"Somma: {risultato} e Divisione: {ris}");

            Console.Clear();

            DemoEventi();
        
        }

        public static int MiaSomma(int a, int b)
        {
            return a + b;
        }

        public static int ReturnZero(int a, int b)
        {
            return 0;
        }

        public static int Dividi(int a, int b)
        {
            return a / b;
        }

        public static void DemoEventi()
        {
            //Publisher
            Publisher youtube = new Publisher("Youtube.com");
            Publisher instagram = new Publisher("Instagram");

            //Subscriber
            Subscriber sub1 = new Subscriber("Mario");
            Subscriber sub2 = new Subscriber("Giulia");
            Subscriber sub3 = new Subscriber("Luana");

            //Iscrizione all'evento
            sub1.Subscribe(youtube);
            sub3.Subscribe(youtube);

            sub2.Subscribe(instagram);

            //Scateniamo l'evento
            youtube.Publish();

            Console.WriteLine(" ----------------------- ");

            instagram.Publish();

            sub1.Unsubscribe(youtube);

            Console.WriteLine(" ---------------------- ");

            youtube.Publish();
        }
    }
}
