using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape3D[] shape3Ds = new Shape3D[5]; 

            Console.WriteLine("Cube");
            Console.Write("Длина квадрата: ");
            double squareLength = Convert.ToInt32(Console.ReadLine());
            Console.Write("Высота куба: ");
            double cubeHeight = Convert.ToInt32(Console.ReadLine());
            shape3Ds[0]= new Cube(new Square(squareLength), cubeHeight);

            Console.WriteLine("Hemispere");
            Console.Write("Радиус: ");
            double hemispereRadius = Convert.ToInt32(Console.ReadLine());
            shape3Ds[1] = new Hemispere(new Circle(hemispereRadius));

            Console.WriteLine("Parallelepiped");
            Console.Write("Длина прямоугольника: ");
            double rectangleLength = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ширина прямоугольника: ");
            double rectangleWidth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Высота: ");
            double parallelepipedHeight = Convert.ToInt32(Console.ReadLine());
            shape3Ds[2] = new Parallelepiped(new Rectangle(rectangleLength, rectangleWidth), parallelepipedHeight);

            Console.WriteLine("Prism");
            Console.Write("Первая сторона: ");
            double firstSide = Convert.ToInt32(Console.ReadLine());
            Console.Write("Вторая сторона: ");
            double secondSide = Convert.ToInt32(Console.ReadLine());
            Console.Write("Третья сторона: ");
            double thirdSide = Convert.ToInt32(Console.ReadLine());
            Console.Write("Высота: ");
            double prismHeight = Convert.ToInt32(Console.ReadLine());
            shape3Ds[3] = new Prism(new Triangle(firstSide, secondSide, thirdSide), prismHeight);

            Console.WriteLine("Cylinder");
            Console.Write("Радиус: ");
            double cylinderRadius = Convert.ToInt32(Console.ReadLine());
            Console.Write("Высота: ");
            double cylinderHeight = Convert.ToInt32(Console.ReadLine());
            shape3Ds[4] = new Cylinder(new Circle(cylinderRadius), cylinderHeight);

            Console.WriteLine("Массив");
            foreach(var shape in shape3Ds)
            {
                Console.Write(shape.GetVolume()+" ");
            }
            Console.WriteLine();

            Array.Sort(shape3Ds);
            Console.WriteLine("Отсортированный массив");
            foreach(var shape in shape3Ds)
            {
                Console.Write(shape.GetVolume()+" ");
            }
            Console.WriteLine();
            Console.WriteLine("Отсортированный массив (Площади)");
            foreach (var shape in shape3Ds)
            {
                Console.Write(shape.GetArea() + " ");
            }
            Console.WriteLine();
        }
    }
}
