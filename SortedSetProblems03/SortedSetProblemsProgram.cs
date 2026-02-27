using Shared.Print;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SortedSetProblems03
{
    internal class SortedSetProblemsProgram
    {

        public static void Main(string[] args)
        {
            // problem 01
            GetNumberBetween();
        }

        // Find Elements in a SortedSet within a given range range
      
        private static SortedSet<T> GetViewBetween<T>(SortedSet<T> set, T Low, T High) where T : IComparable<T>
        {
            SortedSet<T> Result = new SortedSet<T>();

            foreach (T item in set)
            {

                if (item.CompareTo(Low) >= 0 && item.CompareTo(High) <= 0)
                    Result.Add(item);
            }

            return Result;
        }

        public static void GetNumberBetween()
        {
            SortedSet<int> Set = new SortedSet<int>();
            Set.Add(1);
            Set.Add(1);
            Set.Add(5);
            Set.Add(6);
            Set.Add(8);
            Set.Add(7);
            Set.Add(3);
            Set.Add(2);
            Set.Add(0);
            Set.Add(4);
            Set.Print("Elements: ");
            GetViewBetween(Set, 3, 6).Print("\n\nElements between [3] and [6]");

        }
    }
}
