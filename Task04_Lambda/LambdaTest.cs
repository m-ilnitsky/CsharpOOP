using System;
using System.Collections.Generic;
using System.Linq;

namespace Task04_Lambda
{
    class LambdaTest
    {
        private static void PrintList(List<string> list)
        {
            foreach (var name in list)
            {
                Console.WriteLine(name);
            }
        }

        private static void PrintList(List<Person> list)
        {
            foreach (var person in list)
            {
                Console.WriteLine("Name: {0,-4}    Age: {1,2}", person.Name, person.Age);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("<<<< 1 >>>>");
            Console.WriteLine();

            var personsList = new List<Person>
            {
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
            PrintList(personsList);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("<<<< 1.А-v1 >>>>");
            Console.WriteLine("<< Получить список уникальных имён >>");
            Console.WriteLine();

            var nameComparer = new PersonNameComparer();
            var uniqueNamesList = personsList.Distinct(nameComparer)
                                        .Select(x => x.Name)
                                        .ToList();

            Console.WriteLine("uniqueNamesList:");
            PrintList(uniqueNamesList);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("<<<< 1.А-v2 >>>>");
            Console.WriteLine("<< Получить список уникальных имён >>");
            Console.WriteLine();

            var uniqueNamesList2 = personsList.Select(x => x.Name)
                                        .Distinct()
                                        .ToList();

            Console.WriteLine("uniqueNamesList2:");
            PrintList(uniqueNamesList2);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("<<<< 1.Б >>>>");
            Console.WriteLine("<< Вывести список уникальных имён в заданном формате >>");
            Console.WriteLine();

            var uniqueNamesString = "Имена: " + string.Join(", ", uniqueNamesList);

            Console.WriteLine(uniqueNamesString);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("<<<< 1.В >>>>");
            Console.WriteLine("<< Получить список людей младше 18 лет, посчитать их средний возраст >>");
            Console.WriteLine();

            var youngPersonsList = personsList.Where(p => p.Age < 18)
                                       .ToList();
            PrintList(youngPersonsList);

            if (youngPersonsList.Count > 0)
            {
                var averageAgeOfYoungPersons = youngPersonsList.Average(p => p.Age);

                Console.WriteLine("Average Age: {0}", averageAgeOfYoungPersons);
            }
            else
            {
                Console.WriteLine("Нет ни одного человека младше 18 лет");
            }


            Console.WriteLine();
            Console.WriteLine("<<<< 1.Г >>>>");
            Console.WriteLine("<< Получить словарь в котором ключи имена, а значения - средний возраст >>");
            Console.WriteLine();

            var groupByName = personsList.GroupBy(p => p.Name)
                                    .ToDictionary(g => g.Key, g => g.Average(p => p.Age));

            foreach (var key in groupByName.Keys)
            {
                Console.WriteLine("Name: {0,-4}    Average age: {1,2}", key, groupByName[key]);
            }

            Console.WriteLine();
            Console.WriteLine("<<<< 1.Д >>>>");
            Console.WriteLine("<< Получить список людей в возрасте от 20 до 45 лет, вывести в консоль имена в порядке убывания возраста >>");
            Console.WriteLine();

            var from20To45AgePersons = personsList.Where(p => p.Age >= 20 && p.Age <= 45)
                                        .OrderByDescending(p => p.Age)
                                        .ToList();

            PrintList(from20To45AgePersons);

            Console.WriteLine();
            Console.WriteLine("<<<< 2 >>>>");
            Console.WriteLine();

            Console.Write("Введите максимальное целое число N ряда целых чисел: ");
            var maxNumber = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("<<<< 2.1 >>>>");
            Console.WriteLine("<< Сделать бесконечный поток корней чисел >>");
            Console.WriteLine();

            Console.WriteLine("Вычислим корни ряда целых чисел от 1 до {0}", maxNumber);

            var sqrtOfIntNumbers = new SqrtOfIntNumbers();
            var sqrt = sqrtOfIntNumbers.GetEnumerator();

            for (var i = 1; i <= maxNumber; ++i)
            {
                sqrt.MoveNext();
                Console.WriteLine("sqrt({0}) = {1}", i, sqrt.Current);
            }

            Console.WriteLine();
            Console.WriteLine("<<<< 2.2-v1 >>>>");
            Console.WriteLine("<< Сделать бесконечный поток чисел Фибоначчи >>");
            Console.WriteLine();

            Console.WriteLine("Вычислим числа Фибоначчи от F(0) до F({0})", maxNumber);

            var fibonacciNumbers = new FibonacciNumbers();
            var fibonacci = fibonacciNumbers.GetEnumerator();

            for (var i = 0; i <= maxNumber; ++i)
            {
                fibonacci.MoveNext();
                Console.WriteLine("F({0}) = {1}", i, fibonacci.Current);
            }

            Console.WriteLine();
            Console.WriteLine("<<<< 2.2-v2 >>>>");
            Console.WriteLine("<< Сделать бесконечный поток чисел Фибоначчи >>");
            Console.WriteLine();

            Console.WriteLine("Вычислим числа Фибоначчи от F(0) до F({0})", maxNumber);

            var fibonacci2 = fibonacciNumbers.Take(maxNumber + 1);

            var count = 0;
            foreach (var fib in fibonacci2)
            {
                Console.WriteLine("F({0}) = {1}", count, fib);
                ++count;
            }

            Console.WriteLine();
            Console.WriteLine("Exit?");
            Console.ReadLine();
        }
    }
}