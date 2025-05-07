using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Task
{
    class task3
    {
        public void Run()
        {
            FamilyTree tree = new FamilyTree();

            tree.AddRelative("Іван", 1950, null);
            tree.AddRelative("Олена", 1975, "Іван");
            tree.AddRelative("Петро", 2000, "Олена");
            tree.AddRelative("Андрій", 2010, "Олена");
            tree.AddRelative("Марія", 1980, "Іван");

            Console.WriteLine("Спадкоємці Олени:");
            foreach (var child in tree.GetChildren("Олена"))
            {
                Console.WriteLine($"- {child.Name} ({child.BirthYear})");
            }

            Console.WriteLine("\nРодичі, народжені після 1990 року:");
            foreach (var person in tree.GetRelativesBornAfter(1990))
            {
                Console.WriteLine($"- {person.Name} ({person.BirthYear})");
            }

            Console.WriteLine("\nВидаляємо Марію...");
            tree.RemoveRelative("Марія");

            Console.WriteLine("\nУсі родичі:");
            foreach (var person in tree.AllRelatives)
            {
                Console.WriteLine($"- {person.Name} ({person.BirthYear})");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public string ParentName { get; set; }

        public Person(string name, int birthYear, string parentName)
        {
            Name = name;
            BirthYear = birthYear;
            ParentName = parentName;
        }
    }

    class FamilyTree
    {
        private List<Person> people = new List<Person>();

        public IEnumerable<Person> AllRelatives => people;

        public void AddRelative(string name, int birthYear, string parentName)
        {
            if (people.Any(p => p.Name == name))
                throw new ArgumentException("Такий родич вже існує.");
            people.Add(new Person(name, birthYear, parentName));
        }

        public void RemoveRelative(string name)
        {
            people.RemoveAll(p => p.Name == name || p.ParentName == name);
        }

        public List<Person> GetChildren(string parentName)
        {
            return people.Where(p => p.ParentName == parentName).ToList();
        }

        public List<Person> GetRelativesBornAfter(int year)
        {
            return people.Where(p => p.BirthYear > year).ToList();
        }
    }
}
