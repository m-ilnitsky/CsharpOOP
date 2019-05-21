using System;

namespace Task01_Shapes.Shapes
{
    class Triangle : IShape
    {
        private Point pointA;
        private Point pointB;
        private Point pointC;
        private double sideAB;
        private double sideBC;
        private double sideCA;

        public Triangle(Point pointA, Point pointB, Point pointC)
        {
            this.pointA = pointA;
            this.pointB = pointB;
            this.pointC = pointC;

            SetSidesLength();
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.pointA = new Point(x1, y1);
            this.pointB = new Point(x2, y2);
            this.pointC = new Point(x3, y3);

            SetSidesLength();
        }

        private void SetSidesLength()
        {
            sideAB = pointA.GetDistanceTo(pointB);
            sideBC = pointB.GetDistanceTo(pointC);
            sideCA = pointC.GetDistanceTo(pointA);
        }

        public double GetArea()
        {
            double p = 0.5 * (sideAB + sideBC + sideCA);
            return Math.Sqrt(p * (p - sideAB) * (p - sideBC) * (p - sideCA));
        }

        public double GetHeight()
        {
            return Math.Max(pointA.Y, Math.Max(pointB.Y, pointC.Y)) - Math.Min(pointA.Y, Math.Min(pointB.Y, pointC.Y));
        }

        public double GetPerimeter()
        {
            return sideAB + sideBC + sideCA;
        }

        public double GetWidth()
        {
            return Math.Max(pointA.X, Math.Max(pointB.X, pointC.X)) - Math.Min(pointA.X, Math.Min(pointB.X, pointC.X));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return pointA.Equals(triangle.pointA) &&
                   pointB.Equals(triangle.pointB) &&
                   pointC.Equals(triangle.pointC);
        }

        public override int GetHashCode()
        {
            var prime = 3571;
            var hashCode = 1;

            hashCode = hashCode * prime + pointA.GetHashCode();
            hashCode = hashCode * prime + pointB.GetHashCode();
            hashCode = hashCode * prime + pointC.GetHashCode();

            return hashCode;
        }

        public override string ToString()
        {
            return "Triangle[ A" + pointA + ", B" + pointB + ", C" + pointC + " ]";
        }
    }
}
