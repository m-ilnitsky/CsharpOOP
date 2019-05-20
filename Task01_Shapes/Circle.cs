using System;

namespace Task01_Shapes
{
    class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public double GetHeight()
        {
            return radius * 2;
        }

        public double GetPerimeter()
        {
            return Math.PI * radius * 2;
        }

        public double GetWidth()
        {
            return radius * 2;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType()) return false;
            Circle circle = (Circle)obj;
            return radius == circle.radius;
        }

        public override int GetHashCode()
        {
            return 3571 + radius.GetHashCode();
        }

        public override string ToString()
        {
            return "Circle[ r = " + radius + " ]";
        }
    }
}
