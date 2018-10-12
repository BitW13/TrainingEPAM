using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._2
{
    class Tulip : IFlower
    {
        private static readonly int _price = 5;

        public string GetName()
        {
            return "Tulip";
        }

        public int GetPrice()
        {
            return _price;
        }
    }
}
