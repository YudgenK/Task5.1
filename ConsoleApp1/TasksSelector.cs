using ConsoleApp.Task;
using MyNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TasksSelector
    {
        public void sealectTask()
        {
            Console.Clear();
            Console.WriteLine("Оберіть завдання:");
            int.TryParse(Console.ReadLine(), out int taskNamber);

            switch (taskNamber)
            {
                case 1:
                    {
                        task1();
                        break;
                    }
                case 2:
                    {
                        task2();
                        break;
                    }
                case 4:
                    {
                        task4();
                        break;
                    }
                
                default:
                    {
                        Console.WriteLine("Такого завдання немає");
                        break;
                    }
            }
        }
        private static void task1()
        {
            var Task1 = new task1();
            Task1.Run();
        }
        private static void task2()
        {
            var Task2 = new task2();
            Task2.Run();
        }
        private static void task4()
        {
            var Task4 = new task3();
            Task4.Run();
        }
    }
}
