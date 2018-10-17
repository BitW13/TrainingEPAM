using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Prism : Shape3D, IComparable
    {
        public Prism(Triangle figureBase, double height):base(figureBase, height)
        { }
        public Prism():this(new Triangle(), 1)
        { }

        public override double GetArea()
        {
            return Base.GetArea() * 2 + Base.GetPerimeter() * Height;
        }

        public int CompareTo(object obj)
        {
            return (((Shape3D)obj).GetVolume()).CompareTo(this.GetVolume());
        }
    }
}
