using System;
using System.Collections.Generic;
using System.Linq;

namespace Task04_Lambda
{
    class LambdaTest
    {
        static void PrintList(List<String> list)
        {
            foreach (var name in list)
            {
                Console.WriteLine(name);
            }
        }

        static void PrintList(List<Person> list)
        {
            foreach (var person in list)
            {
                Console.WriteLine("Name: {0,-4}    Age: {1,2}", person.Name, person.Age);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n<<<< 1 >>>>\n");

            var list = new List<Person>  {
                new Person("Вася", 19),
                new Person("Петя", 16),
                new Person("Юля", 17),
                new Person("Оля", 18),
                new Person("Вася", 15),
                new Person("Рома", 20),
                new Person("Галя", 13),
                new Person("Валя", 22),
                new Person("Вася", 11),
                new Person("Коля", 30),
                new Person("Вася", 35),
                new Person("Коля", 40),
                new Person("Вася", 55),
                new Person("Коля", 50)
            };

            Console.WriteLine("list:");
            PrintList(list);
            Console.WriteLine();

            Console.WriteLine("\n<<<< 1.А >>>>\n");

            var nameComparer = new PersonNameComparer();
            var uniqueNamesList = list.Distinct(nameComparer)
                                     .Select(x => x.Name)
                                     .ToList();

            Console.WriteLine("uniqueNamesList:");
            PrintList(uniqueNamesList);
            Console.WriteLine();

            Console.WriteLine("\n<<<< 1.Б >>>>\n");

            var uniqueNamesString = "Имена: " + string.Join(", ", uniqueNamesList);

            Console.WriteLine(uniqueNamesString);
            Console.WriteLine();

            Console.WriteLine("\n<<<< 1.В >>>>\n");

            var youngPersonsList = list.Where(p => p.Age < 18)
                                       .ToList();
            var averageAgeOfYoungPersons = youngPersonsList.Average(p => p.Age);

            PrintList(youngPersonsList);
            Console.WriteLine("Average Age: {0}", averageAgeOfYoungPersons);
            Console.WriteLine();

            Console.WriteLine("\n<<<< 1.Г >>>>\n");

            var groupByName = list.GroupBy(p => p.Name)
                                    .ToDictionary(g => g.Key, g => g.Average(p => p.Age));

            foreach (var key in groupByName.Keys)
            {
                Console.WriteLine("Name: {0,-4}    Average age: {1,2}", key, groupByName[key]);
            }

            Console.WriteLine("\n<<<< 1.Д >>>>\n");

            var from20to45Persons = list.Where(p => p.Age >= 20 && p.Age <= 45)
                                        .OrderByDescending(p => p.Age)
                                        .ToList();

            PrintList(from20to45Persons);

            Console.WriteLine("\n<<<< 2 >>>>\n");

            Console.WriteLine();
            Console.WriteLine("Exit?");
            Console.ReadLine();
        }
    }
}
