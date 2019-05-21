using System;
using System.Text;

namespace Task02_Vector
{
    class Vector
    {
        private double[] elements;

        public Vector(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Size must be > 0 (Size=" + length + ").", nameof(length));
            }

            elements = new double[length];
        }

        public Vector(Vector vector)
        {
            elements = new double[vector.elements.Length];

            Array.Copy(vector.elements, elements, vector.elements.Length);
        }

        public Vector(double[] values)
        {
            if (values.Length <= 0)
            {
                throw new ArgumentException("Size must be > 0 (Size=" + values.Length + ").", nameof(values.Length));
            }

            elements = new double[values.Length];

            Array.Copy(values, elements, values.Length);
        }

        public Vector(int length, double[] values)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Size must be > 0 (Size=" + length + ").", nameof(length));
            }

            elements = new double[length];

            var copyLength = Math.Min(length, values.Length);

            Array.Copy(values, elements, copyLength);
        }

        public int GetSize()
        {
            return elements.Length;
        }

        public double GetLength()
        {
            var result = 0d;

            foreach (var element in elements)
            {
                result += element * element;
            }

            return Math.Sqrt(result);
        }

        private void TestIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index < 0  (Index = " + index + ").");
            }
            if (index >= elements.Length)
            {
                throw new IndexOutOfRangeException("Index >= Length  (Index = " + index + ", Length = " + elements.Length + ").");
            }
        }

        public double GetElement(int index)
        {
            TestIndex(index);

            return elements[index];
        }

        public void SetElement(int index, double value)
        {
            TestIndex(index);

            elements[index] = value;
        }

        private void ResizeToVector(Vector vector)
        {
            if (vector.elements.Length > elements.Length)
            {
                Array.Resize(ref elements, vector.elements.Length);
            }
        }

        public void Add(Vector vector)
        {
            ResizeToVector(vector);

            for (var i = 0; i < vector.elements.Length; ++i)
            {
                elements[i] += vector.elements[i];
            }
        }

        public void Subtract(Vector vector)
        {
            ResizeToVector(vector);

            for (var i = 0; i < vector.elements.Length; ++i)
            {
                elements[i] -= vector.elements[i];
            }
        }

        public void Multiply(double scalar)
        {
            for (var i = 0; i < elements.Length; ++i)
            {
                elements[i] *= scalar;
            }
        }

        public void Turn(double scalar)
        {
            Multiply(-1);
        }

        public static Vector Summarize(Vector vector1, Vector vector2)
        {
            var result = new Vector(Math.Max(vector1.elements.Length, vector2.elements.Length), vector1.elements);

            result.Add(vector2);

            return result;
        }

        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            var result = new Vector(Math.Max(vector1.elements.Length, vector2.elements.Length), vector1.elements);

            result.Subtract(vector2);

            return result;
        }

        public static double ScalarProduct(Vector vector1, Vector vector2)
        {
            var result = 0d;

            var minLength = Math.Min(vector1.elements.Length, vector2.elements.Length);

            for (var i = 0; i < minLength; ++i)
            {
                result += vector1.elements[i] * vector2.elements[i];
            }

            return result;
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

            var vector = (Vector)obj;

            if (vector.elements.Length != this.elements.Length)
            {
                return false;
            }

            for (var i = 0; i < elements.Length; ++i)
            {
                if (elements[i] != vector.elements[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var prime = 3571;
            var hashCode = 1;

            hashCode = hashCode * prime + elements.Length;

            foreach (var element in elements)
            {
                hashCode = hashCode * prime + element.GetHashCode();
            }

            return hashCode;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("[");
            foreach (var element in elements)
            {
                sb.Append(element);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
