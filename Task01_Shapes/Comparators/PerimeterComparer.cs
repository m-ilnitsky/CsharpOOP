using System.Collections.Generic;
using Task01_Shapes.Shapes;

namespace Task01_Shapes.Comparators
{
    public class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
        }
    }
}
