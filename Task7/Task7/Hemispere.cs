using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Hemispere : Shape3D, IComparable
    {
        public Hemispere(Circle figureBase):base(figureBase, figureBase.Radius)
        { }
        public Hemispere():this(new Circle())
        { }

        public override double GetArea()
        {
            return 2 * Math.PI * Height * Height + Base.GetArea();
        }

        public override double GetVolume()
        {
            return 4.0 / 6 * Math.PI * Math.Pow(Height, 3);
        }

        public int CompareTo(object obj)
        {
            return (((Shape3D)obj).GetVolume()).CompareTo(this.GetVolume());
        }
    }
}
