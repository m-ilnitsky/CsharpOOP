using System.Collections.Generic;

namespace Task04_Lambda
{
    class PersonNameComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else if (x.Name == y.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Person obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
