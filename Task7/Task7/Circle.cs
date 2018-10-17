using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Circle : Shape2D
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }
        public Circle() : this(1)
        { }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
