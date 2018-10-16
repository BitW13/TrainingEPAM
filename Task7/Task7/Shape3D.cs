using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    abstract class Shape3D:Shape
    {
        public double Height { get; }
        public Shape2D Base { get; }

        public Shape3D(Shape2D figureBase, double height)
        {
            Height = height;
            Base = figureBase;
        }
        public double GetBaseArea()
        {
            return Base.GetArea();
        }
        public virtual double GetVolume()
        {
            return Height * Base.GetPerimeter();
        }
    }
}
