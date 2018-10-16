using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Text");
            //string text = Console.ReadLine();
            //TextSeparation ts = new TextSeparation(text);
            TextSeparation ts = new TextSeparation("Товарищи! новая модель организационной деятельности представляет собой интересный эксперимент проверки новых предложений. Таким образом рамки и место обучения кадров требуют определения и уточнения системы обучения кадров, соответствует насущным потребностям. Равным образом рамки и место обучения кадров требуют определения и уточнения существенных финансовых и административных условий.");
            ts.SplitWords();
            string[] splitWords = ts.GetSplitWords();
            foreach(string word in splitWords)
            {
                Console.Write(word+" ");
            }
            Console.WriteLine();
        }
    }
}
