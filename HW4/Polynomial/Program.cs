using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество коэффициентов 1 полинома: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            double[] coefficients1 = new double[n1];
            Console.WriteLine("Коэффициенты 1 полинома:");
            for(int i=0; i<n1; i++)
            {
                coefficients1[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.Write("Количество коэффициентов 2 полинома: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            double[] coefficients2 = new double[n2];
            Console.WriteLine("Коэффициенты 2 полинома:");
            for (int i = 0; i < n2; i++)
            {
                coefficients2[i] = Convert.ToDouble(Console.ReadLine());
            }
            Polynomial newPolynomial = Polynomial.AddTwoPolynomials(new Polynomial(coefficients1), new Polynomial(coefficients2));
            for(int i=0; i<newPolynomial.Coefficients.Length; i++)
            {
                Console.Write(newPolynomial.Coefficients[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
