using Shared.ReadFromUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAndHashSet02
{
    internal class DictionaryAndHashSetProgram
    {
        public static void Main(string[] args)
        {
            // problem 02
            BookInfo();

            // problem 01
            // StudentGrades();
        }

        // problem: Store the grades of students using their names as keys and retrieve Bob's info using student name
        public static void StudentGrades()
        {
            Dictionary<string, int> _StudentGrades = new Dictionary<string, int>();

            _StudentGrades.Add("Maya", 25);
            _StudentGrades.Add("Maher", 45);
            _StudentGrades.Add("Sham", 54);
            _StudentGrades.Add("Yara", 76);
            _StudentGrades.Add("Ghayath", 56);
            _StudentGrades.Add("Issra", 45);
            _StudentGrades.Add("Bob", 88);

            if (_StudentGrades.TryGetValue("Bob", out int Grades))
            {
                Console.WriteLine($"Bob: {Grades}");
            }
            else
            {
                Console.WriteLine("Bob is not in list");
            }

            if (_StudentGrades.TryGetValue("Salah", out int G))
            {
                Console.WriteLine($"Salah: {G}");
            }
            else
            {
                Console.WriteLine("Salah is not in list");
            }
        }

        // problem: Store information about books (Title,Author) using their ISBN as the key
        public static void BookInfo()
        {
            Dictionary<string, (string, string)> BooksInfo = new Dictionary<string, (string, string)>();
            BooksInfo.Add("6516146465165", ("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie"));
            BooksInfo.Add("3453425436654", ("Introduction to Algorithms", "Thomas H. Cormen"));
            BooksInfo.Add("2143546675745", ("First Design Patterns", "F. Scott"));

            foreach (var kvp in BooksInfo) 
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value.Item1} | {kvp.Value.Item2}");
            }
        }
    }
}
