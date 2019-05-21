using System;

namespace Task01_Shapes.Shapes
{
    class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }

        public double GetDistanceTo(Point p)
        {
            return Math.Sqrt(Math.Pow(p.Y - Y, 2) + Math.Pow(p.X - X, 2));
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

            Point point = (Point)obj;

            return X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            var prime = 3571;
            var hashCode = 1;

            hashCode = hashCode * prime + X.GetHashCode();
            hashCode = hashCode * prime + Y.GetHashCode();

            return hashCode;
        }

        public override string ToString()
        {
            return "( " + X + " ; " + Y + " )";
        }
    }
}
