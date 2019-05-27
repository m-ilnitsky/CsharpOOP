using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06_HashTable
{
    class HashTableProgram
    {
        static void Main(string[] args)
        {
            var intTable = new MikeHashTable<int>(10) { 0, 1, 2, 3, 4, 5, 6, 7 };
            var doubleTable = new MikeHashTable<double>(8) { 0, 1, 10, 100, 1000 };
            var doubleTable2 = new MikeHashTable<double>(doubleTable);
            double[] doubleArray = { 0, 1, 10, 100, 1000 };
            var doubleTable3 = new MikeHashTable<double>(doubleArray);

            Console.WriteLine("intTable     = {0}", intTable);
            Console.WriteLine("doubleTable  = {0}", doubleTable);
            Console.WriteLine("doubleTable2 = {0}", doubleTable2);
            Console.WriteLine("doubleTable3 = {0}", doubleTable3);
            Console.WriteLine();

            var stringTable = new MikeHashTable<string>(32) { "123", "Alfa", "Beta", "Gamma", "Name", "Text", "Int" };

            Console.WriteLine("stringTable.Count = {0}", stringTable.Count);
            Console.WriteLine("stringTable  = {0}", stringTable);

            stringTable.Add(null);
            Console.WriteLine("stringTable.Count = {0}", stringTable.Count);
            Console.WriteLine("stringTable  = {0}", stringTable);

            stringTable.Add("add1");
            Console.WriteLine("stringTable.Count = {0}", stringTable.Count);
            Console.WriteLine("stringTable  = {0}", stringTable);

            stringTable.Add(null);
            Console.WriteLine("stringTable.Count = {0}", stringTable.Count);
            Console.WriteLine("stringTable  = {0}", stringTable);

            stringTable.Add("add2");
            Console.WriteLine("stringTable.Count = {0}", stringTable.Count);
            Console.WriteLine("stringTable  = {0}", stringTable);

            stringTable.Add("add3");
            Console.WriteLine("stringTable.Count = {0}", stringTable.Count);
            Console.WriteLine("stringTable  = {0}", stringTable);

            stringTable.Remove(null);
            Console.WriteLine("stringTable.Count = {0}", stringTable.Count);
            Console.WriteLine("stringTable  = {0}", stringTable);

            stringTable.Remove("add1");
            Console.WriteLine("stringTable.Count = {0}", stringTable.Count);
            Console.WriteLine("stringTable  = {0}", stringTable);

            Console.WriteLine();

            var listIterator = stringTable.GetEnumerator();

            try
            {
                listIterator.MoveNext();
                Console.WriteLine("1 list.element = {0}", listIterator.Current);
                listIterator.MoveNext();
                Console.WriteLine("2 list.element = {0}", listIterator.Current);
                listIterator.MoveNext();
                Console.WriteLine("3 list.element = {0}", listIterator.Current);

                stringTable.Clear();
                //stringTable.Add("new");
                //stringTable.Remove("Name");
                //stringTable.Remove("1234567");      

                Console.WriteLine("stringTable.Count = {0}", stringTable.Count);
                Console.WriteLine("stringTable  = {0}", stringTable);

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
