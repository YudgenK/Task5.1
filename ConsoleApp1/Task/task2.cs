using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Task
{
    class task2
    {
        public void Run()
        {
            var months = new List<Month>
            {
                new Month("Січень", 1, 31),
                new Month("Лютий", 2, 28),
                new Month("Березень", 3, 31),
                new Month("Квітень", 4, 30),
                new Month("Травень", 5, 31),
                new Month("Червень", 6, 30),
                new Month("Липень", 7, 31),
                new Month("Серпень", 8, 31),
                new Month("Вересень", 9, 30),
                new Month("Жовтень", 10, 31),
                new Month("Листопад", 11, 30),
                new Month("Грудень", 12, 31),
            };

            Console.Write("Введіть порядковий номер місяця (1-12): ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                var byNumber = months.FirstOrDefault(m => m.Number == number);
                if (byNumber != null)
                {
                    Console.WriteLine($"Місяць з номером {number}: {byNumber.Name}, днів: {byNumber.Days}");
                }
                else
                {
                    Console.WriteLine("Місяць з таким номером не знайдено.");
                }
            }

            Console.Write("\nВведіть кількість днів для пошуку місяців: ");
            if (int.TryParse(Console.ReadLine(), out int days))
            {
                var matches = months.Where(m => m.Days == days).ToList();
                if (matches.Count > 0)
                {
                    Console.WriteLine($"Місяці з {days} днями:");
                    foreach (var m in matches)
                        Console.WriteLine($"- {m.Name} ({m.Number} місяць)");
                }
                else
                {
                    Console.WriteLine("Місяців з такою кількістю днів не знайдено.");
                }
            }
        }

        class Month
        {
            public string Name { get; }
            public int Number { get; }
            public int Days { get; }

            public Month(string name, int number, int days)
            {
                Name = name;
                Number = number;
                Days = days;
            }
        }
    }
}
