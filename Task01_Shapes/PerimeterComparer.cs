using System.Collections.Generic;

namespace Task01_Shapes
{
    public class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetPerimeter() > shape2.GetPerimeter())
                return 1;
            else if (shape1.GetPerimeter() < shape2.GetPerimeter())
                return -1;
            else
                return 0;
        }
    }
}
