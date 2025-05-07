using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Task
{
    class task4
    {
        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            MultiDictionary dict = new MultiDictionary();

            dict.Add("кіт", "кот", "cat");
            dict.Add("дім", "дом", "house");
            dict.Add("вода", "вода", "water");

            Console.Write("Введіть українське слово: ");
            string word = Console.ReadLine();

            try
            {
                Console.WriteLine("1 - Показати російський переклад");
                Console.WriteLine("2 - Показати англійський переклад");
                Console.Write("Ваш вибір: ");
               
                int choice;
                    int.TryParse(Console.ReadLine(),out choice);

                if (choice == 1)
                {
                    Console.WriteLine($"Російською: {dict.GetRussian(word)}");
                }
                else if (choice == 2)
                {
                    Console.WriteLine($"Англійською: {dict.GetEnglish(word)}");
                }
                else
                {
                    Console.WriteLine("Невірний вибір.");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Слово не знайдено у словнику.");
            }
        }
    }

    class MultiDictionary
    {
        private Dictionary<string, (string Russian, string English)> dictionary =
            new Dictionary<string, (string, string)>();

        public void Add(string ukrainian, string russian, string english)
        {
            dictionary[ukrainian] = (russian, english);
        }

        public string GetRussian(string ukrainian)
        {
            if (!dictionary.ContainsKey(ukrainian))
                throw new KeyNotFoundException();
            return dictionary[ukrainian].Russian;
        }

        public string GetEnglish(string ukrainian)
        {
            if (!dictionary.ContainsKey(ukrainian))
                throw new KeyNotFoundException();
            return dictionary[ukrainian].English;
        }
    }
}
