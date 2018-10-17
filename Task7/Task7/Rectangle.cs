using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Rectangle : Shape2D
    {
        public double Length { get; }
        public double Width { get; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public Rectangle() : this(1, 1)
        { }
        public override double GetArea()
        {
            return Length * Width;
        }

        public override double GetPerimeter()
        {
            return (Length + Width) * 2;
        }
    }
}
