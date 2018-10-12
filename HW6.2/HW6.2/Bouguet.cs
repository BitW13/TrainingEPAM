using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._2
{
    class Bouguet
    {
        List<IFlower> _flowers;
        public Bouguet()
        {
            _flowers = new List<IFlower>();
        }
        public void AddFlower(IFlower flower)
        {
            _flowers.Add(flower);
        }
        public int GetPriceOfBouguet()
        {
            int price = 0;
            for(int i=0; i<_flowers.Count; i++)
            {
                price += _flowers[i].GetPrice();
            }
            return price;
        }
    }
}
