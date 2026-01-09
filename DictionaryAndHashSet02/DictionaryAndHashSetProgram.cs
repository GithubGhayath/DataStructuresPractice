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
            // problem 01
            // StudentGrades();

            Dictionary<string, string> Dic = ReadInput.ReadInfoAsKayValueFormat("Enter as format Kay/value");
         
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
    }
}
