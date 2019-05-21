﻿using System;
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
                throw new ArgumentException("Size must be > 0 (Size=" + length + ").");
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
                throw new ArgumentException("Size must be > 0 (Size=" + values.Length + ").");
            }

            elements = new double[values.Length];

            Array.Copy(values, elements, values.Length);
        }

        public Vector(int length, double[] values)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Size must be > 0 (Size=" + length + ").");
            }

            elements = new double[length];

            int copyLength = Math.Min(length, values.Length);

            Array.Copy(values, elements, copyLength);
        }

        public int GetSize()
        {
            return elements.Length;
        }

        public double GetLength()
        {
            double result = 0;

            for (int i = 0; i < elements.Length; ++i)
            {
                result += elements[i] * elements[i];
            }

            return Math.Sqrt(result);
        }

        private void TestIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index < 0  (Index = " + index + ").");
            }
            if (index == elements.Length)
            {
                throw new ArgumentException("Index == Length  (Index = " + index + ").");
            }
            if (index == elements.Length)
            {
                throw new ArgumentException("Index > Length  (Index = " + index + ", Length = " + elements.Length + ").");
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

        protected void ResizeToVector(Vector vector)
        {
            if (vector.elements.Length > elements.Length)
            {
                double[] newElements = new double[vector.elements.Length];

                Array.Copy(elements, newElements, elements.Length);

                elements = newElements;
            }
        }

        public void Add(Vector vector)
        {
            ResizeToVector(vector);

            for (int i = 0; i < vector.elements.Length; ++i)
            {
                elements[i] += vector.elements[i];
            }
        }

        public void Subtract(Vector vector)
        {
            ResizeToVector(vector);

            for (int i = 0; i < vector.elements.Length; ++i)
            {
                elements[i] -= vector.elements[i];
            }
        }

        public void Multiply(double scalar)
        {
            for (int i = 0; i < elements.Length; ++i)
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
            Vector result = new Vector(Math.Max(vector1.elements.Length, vector2.elements.Length));

            Array.Copy(vector1.elements, result.elements, vector1.elements.Length);

            result.Add(vector2);

            return result;
        }

        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(Math.Max(vector1.elements.Length, vector2.elements.Length));

            Array.Copy(vector1.elements, result.elements, vector1.elements.Length);

            result.Subtract(vector2);

            return result;
        }

        public static double ScalarProduct(Vector vector1, Vector vector2)
        {
            double result = 0;

            int minLength = Math.Min(vector1.elements.Length, vector2.elements.Length);

            for (int i = 0; i < minLength; ++i)
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

            Vector vector = (Vector)obj;

            if (vector.elements.Length != this.elements.Length)
            {
                return false;
            }

            for (int i = 0; i < elements.Length; ++i)
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
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < elements.Length; ++i)
            {
                if (i == 0)
                {
                    sb.Append("[ ");
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(elements[i]);
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}
