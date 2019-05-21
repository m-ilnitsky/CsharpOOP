using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_Vector
{
    class VectorTest
    {
        static void Main(string[] args)
        {
            double[] values = { 1, 2, 3, 4, 5, 6, 7 };

            Vector vector1 = new Vector(5);
            Vector vector2 = new Vector(values);
            Vector vector3 = new Vector(vector2);
            Vector vector4 = new Vector(3, values);

            vector3.SetElement(3, 7);

            Console.WriteLine("vector1 = {0}", vector1);
            Console.WriteLine("vector2 = {0}", vector2);
            Console.WriteLine("vector3 = {0}", vector3);
            Console.WriteLine("vector4 = {0}", vector4);

            vector3.Multiply(0.5);

            Console.WriteLine();
            Console.WriteLine("vector3 = vector3*0.5 = {0}", vector3);

            Vector vector5 = Vector.Summarize(vector3, vector2);
            Vector vector6 = Vector.Subtract(vector3, vector2);
            Vector vector7 = Vector.Summarize(vector2, vector1);
            Vector vector8 = Vector.Subtract(vector2, vector1);

            Console.WriteLine();
            Console.WriteLine("vector5 = vector3+vector2 = {0}", vector5);
            Console.WriteLine("vector6 = vector3-vector2 = {0}", vector6);
            Console.WriteLine("vector7 = vector2+vector1 = {0}", vector7);
            Console.WriteLine("vector8 = vector2-vector1 = {0}", vector8);

            double scalarProduct1 = Vector.ScalarProduct(vector3, vector2);
            double scalarProduct2 = Vector.ScalarProduct(vector5, vector6);
            double scalarProduct3 = Vector.ScalarProduct(vector2, vector1);

            Console.WriteLine();
            Console.WriteLine("scalarProduct1 = vector3*vector2 = {0}", scalarProduct1);
            Console.WriteLine("scalarProduct2 = vector5*vector6 = {0}", scalarProduct2);
            Console.WriteLine("scalarProduct3 = vector2*vector1 = {0}", scalarProduct3);

            Console.WriteLine();
            Console.WriteLine("Exit?");
            Console.ReadLine();
        }
    }
}
