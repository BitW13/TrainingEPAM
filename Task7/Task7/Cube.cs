using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Cube:Shape3D, IComparable
    {
        public Cube(Square figureBase, double height):base(figureBase, height)
        { }
        public Cube():this(new Square(), 1)
        { }

        public override double GetArea()
        {
            return 6 * Base.GetArea();
        }

        public int CompareTo(object obj)
        {
            return (((Shape3D)obj).GetVolume()).CompareTo(this.GetVolume());
        }
    }
}
