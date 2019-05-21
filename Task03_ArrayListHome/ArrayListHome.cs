using System;
using System.Collections.Generic;
using System.IO;

namespace Task03_ArrayListHome
{
    class ArrayListHome
    {
        static void PrintList(List<int> list)
        {
            foreach (var element in list)
            {
                Console.Write(element + ", ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("### 1: Прочитать в список строки из файла");
            Console.WriteLine();

            var listOfStrings = new List<string>();

            string fileName = "..\\..\\input.txt";

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        listOfStrings.Add(reader.ReadLine());
                    }
                }
            }
            catch (IOException exeption)
            {
                Console.WriteLine();
                Console.WriteLine(exeption);
            }

            Console.WriteLine("listOfStrings from file '" + fileName + "':");
            foreach (var str in listOfStrings)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("### 2: Удалить все чётные числа");
            Console.WriteLine();

            var listOfIntNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            Console.Write("listOfIntNumbers: ");
            PrintList(listOfIntNumbers);
            Console.WriteLine();

            for (var i = listOfIntNumbers.Count - 1; i >= 0; --i)
            {
                if ((int)listOfIntNumbers[i] % 2 == 0)
                {
                    listOfIntNumbers.RemoveAt(i);
                }
            }

            Console.Write("listOfIntNumbers: ");
            PrintList(listOfIntNumbers);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("### 3: Создать новый список без повторяющихся чисел");
            Console.WriteLine();

            var listOfRandomNumbers = new List<int>() { 1, 2, 3, 1, 2, 3, 4, 5, 6, 5, 6, 7, 8, 6, 7, 8, 9, 10, 8, 6, 4, 2, 1 };

            Console.Write("listOfRandomNumbers: ");
            PrintList(listOfRandomNumbers);
            Console.WriteLine();

            var listOfUniqueNumbers = new List<int>();

            foreach (var number in listOfRandomNumbers)
            {
                if (!listOfUniqueNumbers.Contains(number))
                {
                    listOfUniqueNumbers.Add(number);
                }
            }

            Console.Write("listOfUniqueNumbers: ");
            PrintList(listOfUniqueNumbers);
            Console.WriteLine();

            var listOfUniqueNumbers2 = new List<int>();

            for (var i = listOfRandomNumbers.Count - 1; i >= 0; --i)
            {
                if (!listOfUniqueNumbers2.Contains(listOfRandomNumbers[i]))
                {
                    listOfUniqueNumbers2.Add(listOfRandomNumbers[i]);
                }
            }

            Console.Write("listOfUniqueNumbers2: ");
            PrintList(listOfUniqueNumbers2);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Exit?");
            Console.ReadLine();
        }
    }
}
