using System;
using Task01_Shapes.Comparators;
using Task01_Shapes.Shapes;

namespace Task01_Shapes
{
    class ShapesTest
    {
        static void Main(string[] args)
        {
            IShape[] shapes =
            {
                new Square(3),
                new Square(5),
                new Square(7),
                new Rectangle(2, 4),
                new Rectangle(4, 2),
                new Rectangle(6, 1),
                new Rectangle(5, 1.5),
                new Circle(3),
                new Circle(5),
                new Circle(7),
                new Triangle(0, 0,  0, 1,  3, 0),
                new Triangle(0, 1,  0, 2,  5, 0),
                new Triangle(2, 0,  3, 1,  3, 7),
                new Triangle(0, 3,  1, 4,  9, 3)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
                Console.WriteLine("Area      = {0}", shape.GetArea());
                Console.WriteLine("Perimeter = {0}", shape.GetPerimeter());
                Console.WriteLine("Height    = {0}", shape.GetHeight());
                Console.WriteLine("Width     = {0}", shape.GetWidth());
                Console.WriteLine();
            }

            Array.Sort(shapes, new AreaComparer());

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
                Console.WriteLine("Area      = {0}", shape.GetArea());
            }
            Console.WriteLine();

            Console.WriteLine("ФИГУРА С МАКСМАЛЬНОЙ ПЛОЩАДЬЮ:");
            Console.WriteLine(shapes[shapes.Length - 1]);
            Console.WriteLine("Area      = {0}", shapes[shapes.Length - 1].GetArea());
            Console.WriteLine("Perimeter = {0}", shapes[shapes.Length - 1].GetPerimeter());
            Console.WriteLine("Height    = {0}", shapes[shapes.Length - 1].GetHeight());
            Console.WriteLine("Width     = {0}", shapes[shapes.Length - 1].GetWidth());
            Console.WriteLine();

            Array.Sort(shapes, new PerimeterComparer());
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
                Console.WriteLine("Perimeter = {0}", shape.GetPerimeter());
            }
            Console.WriteLine();

            Console.WriteLine("ФИГУРА СО ВТОРЫМ ПО ВЕЛИЧИНЕ ПЕРИМЕТРОМ:");
            Console.WriteLine(shapes[shapes.Length - 2]);
            Console.WriteLine("Area      = {0}", shapes[shapes.Length - 2].GetArea());
            Console.WriteLine("Perimeter = {0}", shapes[shapes.Length - 2].GetPerimeter());
            Console.WriteLine("Height    = {0}", shapes[shapes.Length - 2].GetHeight());
            Console.WriteLine("Width     = {0}", shapes[shapes.Length - 2].GetWidth());
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Exit?");
            Console.ReadLine();
        }
    }
}
