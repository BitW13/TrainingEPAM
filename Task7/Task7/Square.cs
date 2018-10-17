using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Square : Shape2D
    {
        public double Length { get; }

        public Square(double length)
        {
            Length = length;
        }
        public Square():this(1)
        { }

        public override double GetArea()
        {
            return Math.Pow(Length, 2);
        }

        public override double GetPerimeter()
        {
            return 4 * Length;
        }
    }
}
