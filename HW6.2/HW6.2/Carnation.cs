using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._2
{
    class Carnation : IFlower
    {
        private static readonly int _price = 4;

        public string GetName()
        {
            return "Carnation";
        }

        public int GetPrice()
        {
            return _price;
        }
    }
}
