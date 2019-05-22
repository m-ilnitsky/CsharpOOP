using System.Collections;
using System.Collections.Generic;

namespace Task04_Lambda
{
    class FibonacciNumbers : IEnumerable<long>
    {
        public IEnumerator<long> GetEnumerator()
        {
            yield return 0;
            yield return 1;

            long f0 = 0;
            long f1 = 1;

            while (true)
            {
                long f2 = f0 + f1;
                f0 = f1;
                f1 = f2;

                yield return f2;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
