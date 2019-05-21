using System.Collections.Generic;
using Task01_Shapes.Shapes;

namespace Task01_Shapes.Comparators
{
    public class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}
