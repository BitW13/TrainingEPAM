using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static string[] GetFactorialForInt(int n)
        {
            if (n > 1)
            {
                int[] reverseFactorial = new int[]
                {
                    1
                };

                for (int i = 2; i <= n; i++)
                {
                    int[] additionalElements = new int[reverseFactorial.Length];
                    int length = reverseFactorial.Length;
                    for (int j = 0; j < length; j++)
                    {
                        int r = i * reverseFactorial[j];
                        if (r > 999)
                        {
                            reverseFactorial[j] = r % 1000;
                            r = (int)r / 1000;
                            int k = j + 1;
                            while (r > 0)
                            {
                                if (k > reverseFactorial.Length - 1)
                                {
                                    Array.Resize<int>(ref reverseFactorial, reverseFactorial.Length + 1);
                                    Array.Resize<int>(ref additionalElements, additionalElements.Length + 1);
                                }
                                int remainder = 0;
                                if (r < 1000)
                                {
                                    remainder = r;
                                }
                                else
                                {
                                    remainder = r % 1000;

                                }
                                r = (int)r / 1000;
                                if (remainder + additionalElements[k] > 999)
                                {
                                    r += (remainder + additionalElements[k]) % 1000;
                                    additionalElements[k] = 1;
                                }
                                else
                                {
                                    additionalElements[k] = remainder + additionalElements[k];
                                }
                                k++;
                            }
                        }
                        else
                        {
                            reverseFactorial[j] = r;
                        }
                    }
                    for(int j=0; j<additionalElements.Length; j++)
                    {
                        if (additionalElements[j] + reverseFactorial[j] > 999)
                        {
                            int r = reverseFactorial[j] + additionalElements[j];
                            reverseFactorial[j] = r % 1000;
                            r = (int)r / 1000;
                            int k = j+1;
                            while (r > 0)
                            {
                                if (k > reverseFactorial.Length - 1)
                                {
                                    Array.Resize<int>(ref reverseFactorial, reverseFactorial.Length + 1);
                                    Array.Resize<int>(ref additionalElements, additionalElements.Length + 1);
                                }
                                int remainder = 0;
                                if (r < 1000)
                                {
                                    remainder = r;
                                }
                                else
                                {
                                    remainder = r % 1000;

                                }
                                r = (int)r / 1000;
                                if (remainder + reverseFactorial[k] > 999)
                                {
                                    r += (remainder + reverseFactorial[k]) % 1000;
                                    reverseFactorial[k] = 1;
                                }
                                else
                                {
                                    reverseFactorial[k] = remainder + reverseFactorial[k];
                                }
                                k++;
                            }                            

                        }
                        else
                        {
                            reverseFactorial[j] += additionalElements[j];
                        }
                    }
                }
                int[] factorial = new int[reverseFactorial.Length];
                for (int i = reverseFactorial.Length - 1; i >= 0; i--)
                {
                    factorial[reverseFactorial.Length - 1 - i] = reverseFactorial[i];
                }
                string[] stringFactorial = new string[factorial.Length];
                for(int i=0; i<stringFactorial.Length; i++)
                {
                    if (factorial[i] == 0)
                    {
                        stringFactorial[i] = "000";
                    }
                    if (factorial[i] < 10)
                    {
                        stringFactorial[i] = "00" + factorial[i].ToString();
                    }
                    if(factorial[i]>9 && factorial[i] < 100)
                    {
                        stringFactorial[i] = "0" + factorial[i].ToString();
                    }
                    if (factorial[i] > 99)
                    {
                        stringFactorial[i] = factorial[i].ToString();
                    }
                }
                return stringFactorial;
            }
            else
            {
                return new string[] { "1" };
            }
        }
        static void Main(string[] args)
        {
            Console.Write("n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            string[] factorial = GetFactorialForInt(n);
            for(int i=0; i<factorial.Length; i++)
            {
                Console.Write(factorial[i]);
            }
            Console.WriteLine();
        }
    }
}
