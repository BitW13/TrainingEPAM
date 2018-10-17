using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Parallelepiped : Shape3D, IComparable
    {
        public Parallelepiped(Rectangle figureBase, double height):base(figureBase, height)
        { }
        public Parallelepiped():this(new Rectangle(), 1)
        { }

        public override double GetArea()
        {
            return Base.GetArea() * 2 + Height * Base.GetPerimeter();
        }

        public int CompareTo(object obj)
        {
            return (((Shape3D)obj).GetVolume()).CompareTo(this.GetVolume());
        }
    }
}
