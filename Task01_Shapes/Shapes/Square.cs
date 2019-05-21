namespace Task01_Shapes.Shapes
{
    class Square : IShape
    {
        private double sideLength;

        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double GetArea()
        {
            return sideLength * sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetPerimeter()
        {
            return sideLength * 4;
        }

        public double GetWidth()
        {
            return sideLength;
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

            Square square = (Square)obj;

            return sideLength == square.sideLength;
        }

        public override int GetHashCode()
        {
            return sideLength.GetHashCode();
        }

        public override string ToString()
        {
            return "Square[ " + sideLength + " x " + sideLength + " ]";
        }
    }
}
