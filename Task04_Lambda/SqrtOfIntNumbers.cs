using System;
using System.Collections;
using System.Collections.Generic;

namespace Task04_Lambda
{
    class SqrtOfIntNumbers : IEnumerable<double>
    {
        public IEnumerator<double> GetEnumerator()
        {
            var i = 1;
            while (true)
            {
                yield return Math.Sqrt(i);
                ++i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
