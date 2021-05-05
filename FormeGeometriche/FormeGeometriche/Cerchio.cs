using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    class Cerchio : FormeGeo
    {
        public double Raggio { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        //public Cerchio (string nome, double raggio, int x, int y)
        //    :base(nome)
        //{
        //    Raggio = raggio;
        //    X = x;
        //    Y = y;
        //}



        public override double Area()
        {
            return Raggio * Raggio * Math.PI;
        }

        public override void LoadFromFile(string fileName)
        {
            //Values: My Circle;7;9;10
            try
            {
                using StreamReader reader = File.OpenText(@"C:\Users\simona.loperfido\Desktop\Week1\Saves\" + fileName);
                string instanceData = reader.ReadLine().Split(":")[1];

                //instanceData -> My Circle;7;9;10
                string[] values = instanceData.Split(";");

                Nome = values[0];

                bool resultOk = int.TryParse(values[1], out int x);
                if (resultOk)
                {
                    X = x;
                }

                //oppure 
                int.TryParse(values[2], out int y);
                Y = y;

                double.TryParse(values[3], out double raggio);
                Raggio = raggio;

                reader.Close();
            } catch (IOException e)
            {
                Console.WriteLine(e.Message);
            } catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public override void SaveToFile(string fileName)
        {
            try
            {
                using StreamWriter writer = File.CreateText(@"C:\Users\simona.loperfido\Desktop\Week1\Saves\" + fileName);
                string instanceData = $"Values:{Nome};{Raggio};{X};{Y}";

                writer.WriteLine(instanceData);
                writer.Close();

            } catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
