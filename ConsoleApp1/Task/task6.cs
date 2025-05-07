using System;
using System.Collections.Generic;

namespace ConsoleApp.Task
{
    class task6
    {
        public void Run()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine("Квадрати непарних чисел:");
            foreach (var square in GetOddSquares(numbers))
            {
                Console.WriteLine(square);
            }
        }

        public IEnumerable<int> GetOddSquares(int[] numbers)
        {
            foreach (int number in numbers)
            {
                if (number % 2 != 0)
                {
                    yield return number * number;
                }
            }
        }
    }
}
