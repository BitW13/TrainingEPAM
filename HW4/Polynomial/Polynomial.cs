using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    class Polynomial
    {
        public double[] Coefficients { get; private set; }

        public Polynomial(double[] coefficients)
        {
            Coefficients = coefficients;
        }
        private static List<double> GetReverseList(List<double> list)
        {
            List<double> newList = new List<double>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                newList.Add(list[i]);
            }
            return newList;
        }
        private static List<double> AddTwoLists(List<double> list1, List<double> list2)
        {
            List<double> newList;
            bool firstMoreThanSecond;
            if (list1.Count >= list2.Count)
            {
                newList = new List<double>(list1.Count);
                firstMoreThanSecond = true;
            }
            else
            {
                newList = new List<double>(list2.Count);
                firstMoreThanSecond = false;
            }
            for (int i = 0; i < newList.Capacity; i++)
            {
                if (firstMoreThanSecond)
                {
                    if (list2.Count - 1 >= i)
                    {
                        newList.Add(list1[i] + list2[i]);
                    }
                    else
                    {
                        newList.Add(list1[i]);
                    }
                }
                else
                {
                    if (list1.Count - 1 >= i)
                    {
                        newList.Add(list1[i] + list2[i]);
                    }
                    else
                    {
                        newList.Add(list2[i]);
                    }
                }
            }
            return newList;
        }
        public static Polynomial AddTwoPolynomials(Polynomial polynomial1, Polynomial polynomial2)
        {
            List<double> reverseCoefficientsPol1 = GetReverseList(polynomial1.Coefficients.ToList<double>());
            List<double> reverseCoefficientsPol2 = GetReverseList(polynomial2.Coefficients.ToList<double>());

            List<double> coefficients = GetReverseList(AddTwoLists(reverseCoefficientsPol1, reverseCoefficientsPol2));
            return new Polynomial(coefficients.ToArray<double>());
        }
    }
}
