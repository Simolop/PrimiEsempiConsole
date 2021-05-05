using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    public class FormeGeo : IFileSerializable
    {
        public string Nome { get; set; }

        //public FormeGeo (string nome)
        //{
        //    Nome = nome;
        //}
         public virtual double Area()
         {
            return 0;
         }
       

        public virtual void Disegno()
        {
            
        }


        //con virtual dico che le classi derivate possono implementre una loro soluzione per il salvataggio
        public virtual void SaveToFile(string fileName) 
        {
            Console.WriteLine($"Documento salvato su file come: {fileName}");
        }

        public virtual void LoadFromFile(string fileName)
        {
            Console.WriteLine($"Documento caricato come: {fileName}");           
        }

       
        
    }
}
