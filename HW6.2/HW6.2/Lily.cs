using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._2
{
    class Lily : IFlower
    {
        private static readonly int _price = 6;

        public string GetName()
        {
            return "Lily";
        }

        public int GetPrice()
        {
            return _price;
        }
    }
}
