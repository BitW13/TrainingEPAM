using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество роз: ");
            int roses = Convert.ToInt32(Console.ReadLine());
            Console.Write("Количество гвоздик: ");
            int carnations = Convert.ToInt32(Console.ReadLine());
            Console.Write("Количество тюльпанов: ");
            int tulips = Convert.ToInt32(Console.ReadLine());
            Console.Write("Количество лилий: ");
            int lilies = Convert.ToInt32(Console.ReadLine());
            Bouguet bouguet = new Bouguet();
            for(int i=0; i<roses; i++)
            {
                bouguet.AddFlower(new Rose());
            }
            for(int i=0; i<carnations; i++)
            {
                bouguet.AddFlower(new Carnation());
            }
            for(int i=0; i<tulips; i++)
            {
                bouguet.AddFlower(new Tulip());
            }
            for(int i=0; i<lilies; i++)
            {
                bouguet.AddFlower(new Lily());
            }
            Console.WriteLine(bouguet.GetPriceOfBouguet());
        }
    }
}
