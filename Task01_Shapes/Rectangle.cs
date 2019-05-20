namespace Task01_Shapes
{
    class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double GetArea()
        {
            return width * height;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetPerimeter()
        {
            return (width + height) * 2;
        }

        public double GetWidth()
        {
            return width;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType()) return false;
            Rectangle rectangle = (Rectangle)obj;
            return width == rectangle.width &&
                   height == rectangle.height;
        }

        public override int GetHashCode()
        {
            var prime = 3571;
            var hashCode = 1;
            hashCode = hashCode * prime + width.GetHashCode();
            hashCode = hashCode * prime + height.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Rectangle[ w = " + width + " ; h = " + height + " ]";
        }
    }
}
