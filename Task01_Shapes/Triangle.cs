using System;

namespace Task01_Shapes
{
    class Triangle : IShape
    {
        private Point p1, p2, p3;
        private double p1p2, p2p3, p3p1;

        public Triangle(Point p1, Point p2, Point p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

            SetSideLength();
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.p1 = new Point(x1, y1);
            this.p2 = new Point(x2, y2);
            this.p3 = new Point(x3, y3);

            SetSideLength();
        }

        private void SetSideLength()
        {
            p1p2 = p1.GetDistanceTo(p2);
            p2p3 = p2.GetDistanceTo(p3);
            p3p1 = p3.GetDistanceTo(p1);
        }

        public double GetArea()
        {
            double p = 0.5 * (p1p2 + p2p3 + p3p1);
            return Math.Sqrt(p * (p - p1p2) * (p - p2p3) * (p - p3p1));
        }

        public double GetHeight()
        {
            return Math.Max(p1.Y, Math.Max(p2.Y, p3.Y)) - Math.Min(p1.Y, Math.Min(p2.Y, p3.Y));
        }

        public double GetPerimeter()
        {
            return p1p2 + p2p3 + p3p1; ;
        }

        public double GetWidth()
        {
            return Math.Max(p1.X, Math.Max(p2.X, p3.X)) - Math.Min(p1.X, Math.Min(p2.X, p3.X));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType()) return false;
            Triangle triangle = (Triangle)obj;
            return p1.Equals(triangle.p1) &&
                   p2.Equals(triangle.p2) &&
                   p3.Equals(triangle.p3);
        }

        public override int GetHashCode()
        {
            var prime = 3571;
            var hashCode = 1;
            hashCode = hashCode * prime + p1.GetHashCode();
            hashCode = hashCode * prime + p2.GetHashCode();
            hashCode = hashCode * prime + p3.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Triangle[ A" + p1 + ", B" + p2 + ", C" + p3 + " ]";
        }
    }
}
