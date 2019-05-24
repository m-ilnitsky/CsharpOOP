using System;

namespace Task05_ArrayList
{
    class ArrayListProgram
    {
        static void Main(string[] args)
        {
            var intList = new MikeList<int>(10) { 0, 1, 2, 3, 4, 5, 6, 7 };
            var doubleList = new MikeList<double>(8) { 0, 1, 0.5, 0.25, 0.125 };
            var doubleList2 = new MikeList<double>(doubleList);
            double[] doubleArray = { 0, 1, 0.5, 0.25, 0.125 };
            var doubleList3 = new MikeList<double>(doubleArray);
            var stringList = new MikeList<string>() { "123", "Alfa", "Beta", "Hello", "<0_0>", "_   _", "", "()" };

            Console.WriteLine("intList     = {0}", intList);
            Console.WriteLine("doubleList  = {0}", doubleList);
            Console.WriteLine("doubleList2 = {0}", doubleList2);
            Console.WriteLine("doubleList3 = {0}", doubleList3);
            Console.WriteLine("stringList  = {0}", stringList);

            Console.WriteLine();
            Console.WriteLine("stringList.Count     = {0}", stringList.Count);
            Console.WriteLine("stringList.Capacity  = {0}", stringList.Capacity);
            stringList.TrimToSize();
            Console.WriteLine("stringList.Capacity  = {0}", stringList.Capacity);
            Console.WriteLine();

            stringList.Insert(0, "0");
            Console.WriteLine("stringList  = {0}", stringList);

            stringList.Insert(2, "2");
            Console.WriteLine("stringList  = {0}", stringList);

            stringList.Insert(4, "4");
            Console.WriteLine("stringList  = {0}", stringList);

            stringList[5] = "5";
            Console.WriteLine("stringList  = {0}", stringList);

            stringList.RemoveAt(5);
            Console.WriteLine("stringList  = {0}", stringList);

            Console.WriteLine();
            Console.WriteLine("stringList.Count     = {0}", stringList.Count);
            Console.WriteLine("stringList.Capacity  = {0}", stringList.Capacity);
            Console.WriteLine();

            stringList.Remove("_   _");
            stringList.Remove("");
            stringList.Remove("()");
            Console.WriteLine("stringList  = {0}", stringList);

            Console.WriteLine();
            Console.WriteLine("stringList.Count     = {0}", stringList.Count);
            Console.WriteLine("stringList.Capacity  = {0}", stringList.Capacity);

            var listIterator = stringList.GetEnumerator();

            Console.WriteLine();

            try
            {
                listIterator.MoveNext();
                Console.WriteLine("1 list.element = {0}", listIterator.Current);
                listIterator.MoveNext();
                Console.WriteLine("2 list.element = {0}", listIterator.Current);
                listIterator.MoveNext();
                Console.WriteLine("3 list.element = {0}", listIterator.Current);

                //stringList.Clear();
                //stringList.Add("new");
                //stringList.Remove("4");
                //stringList.Remove("1234567");
                //stringList.RemoveAt(2);
                //stringList[0]="qwerty";
                stringList.Insert(1, "insert");

                listIterator.MoveNext();
                Console.WriteLine("4 list.element = {0}", listIterator.Current);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine();
                Console.WriteLine("EXCEPTION:");
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Exit?");
            Console.ReadLine();
        }
    }
}
