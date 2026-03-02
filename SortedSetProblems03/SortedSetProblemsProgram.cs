using Shared.Print;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SortedSetProblems03
{
    internal static class SortedSetProblemsProgram
    {

        public static void Main(string[] args)
        {
            // problem 10
            CheckIfSortedSetContainsElementsFromMultipleSpecifiedRange();


            // problem 09
            // GetNumberOfElementsLessThanOrEqualGivenValue();


            // problem 08
            // GetElementsOutSideRange();


            // problem 07
            // RemoveAllElementsWithinASpcifiedRange();


            // problem 06
            // CountNumberOfElementsThatGreaterThanSpicifiedValue();

            // problem 05
            // AllElementsLessThanGivenValue();


            // problem 04
            // RemoveElementsGreaterThanValue();


            // problem 03
            // UnionOfTwoSet();

            // problem 02
            // MaxAndMinElementInSortedSet();

            // problem 01
            // GetNumberBetween();
        }

        // Find Elements in a SortedSet within a given range range.
        private static SortedSet<T> GetViewBetween<T>(SortedSet<T> set, T Low, T High) where T : IComparable<T>
        {
            SortedSet<T> Result = new SortedSet<T>();

            foreach (T item in set)
            {

                if (Low.CompareTo(item) <= 0 && High.CompareTo(item) >= 0)
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

        // Find the smallest and largest element in a sorted set
        public static void MaxAndMinElementInSortedSet()
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
            Console.WriteLine($"\n\nThe minimum number in set: {Set.Min}");
            Console.WriteLine($"The maximum number in set: {Set.Max}");
        }

        // Find the union of two sorted set objects
        public static void UnionOfTwoSet()
        {
            SortedSet<int> Set1 = new SortedSet<int>();
            SortedSet<int> Set2 = new SortedSet<int>();

            Set1.Add(1);
            Set1.Add(3);
            Set1.Add(4);
            Set1.Add(6);
            Set1.Add(5);
            Set1.Add(2);


            Set2.Add(10);
            Set2.Add(11);
            Set2.Add(9);
            Set2.Add(8);
            Set2.Add(7);
            Set2.Add(6);
            Set2.Add(6);

            Set1.Print("Set 1 elements: ");
            Set2.Print("Set 2 elements: ");

            Console.WriteLine($"Set1 and Set2 after union: {string.Join(" , ",Set1.Union(Set2).ToList())}");

        }

        // Remove all elements from a sorted set that are greater than a spcified value.
        private static SortedSet<T> RemoveElementsGreaterThanValue<T>(SortedSet<T> Set, T Value) where T : IComparable<T>
        {
            SortedSet<T> Result = new SortedSet<T>();

            foreach (T item in Set)
            {
                if (item.CompareTo(Value) != 0)
                    Result.Add(item);
                else
                {
                    Result.Add(item);
                    break;
                }
            }

            return Result;
        }
        public static void RemoveElementsGreaterThanValue()
        {
            SortedSet<int> Set = new SortedSet<int>();
            Set.Add(11);
            Set.Add(2);
            Set.Add(4);
            Set.Add(3);
            Set.Add(1);
            Set.Add(6);
            Set.Add(9);
            Set.Add(10);
            Set.Add(7);
            Set.Add(8);
            Set.Add(5);

            Set.Print("List Elements: ");
            Set = RemoveElementsGreaterThanValue(Set, 6);
            Set.Print("List Elements after remove all element above 6 : ");

        }

        // Find all elements in a SortedSet less than a given value.
        public static void AllElementsLessThanGivenValue()
        {
            SortedSet<int> Set = new SortedSet<int>();
            SortedSet<int> Result = new SortedSet<int>();
            int GivenValue = 6;
            Set.Add(11);
            Set.Add(2);
            Set.Add(4);
            Set.Add(3);
            Set.Add(1);
            Set.Add(6);
            Set.Add(9);
            Set.Add(10);
            Set.Add(7);
            Set.Add(8);
            Set.Add(5);

            foreach(int element in Set)
            {
                if(element< GivenValue)
                    Result.Add(element);
                else
                {
                    Result.Add(element);
                    break;
                }
            }
            Set.Print("List Elements: ");
            Result.Print("\nList Elements less than [6]: ");


        }

        // Count the number of elements greater than a given value in a sortedSet
        private static int CountNumberOfElementsThatGreaterThanSpicifiedValue<T>(this SortedSet<T>Set,T GivenValue) where T : IComparable<T>
        {
            int Count = 0;

            foreach (T item in Set)
            {
                if(item.CompareTo(GivenValue)>0)
                    Count++;
            }

            return Count;
        }
        public static void CountNumberOfElementsThatGreaterThanSpicifiedValue()
        {
           

            SortedSet<int> Set = new SortedSet<int>();

            Set.Add(11);
            Set.Add(2);
            Set.Add(4);
            Set.Add(3);
            Set.Add(1);
            Set.Add(6);
            Set.Add(9);
            Set.Add(10);
            Set.Add(7);
            Set.Add(12);
            Set.Add(13);
            Set.Add(8);
            Set.Add(5);

            int Count = Set.CountNumberOfElementsThatGreaterThanSpicifiedValue(6);

            Set.Print("List Elements: ");
            Console.WriteLine($"The number of element that greater than [6] is : {Count}");
        }

        // Remove all elements within a specified range from a SortedSet.
        private static SortedSet<int> CompleteRange(int[] arr)
        {
            SortedSet<int> FullRange = new SortedSet<int>();

            int Counter = arr[0];

            while (arr[arr.Length - 1] >= Counter)
            {
                FullRange.Add(Counter);
                Counter ++;
            }

            return FullRange;
        }
        public static void RemoveAllElementsWithinASpcifiedRange()
        {
            int[] arr = new int[] { 5, 9 };

            SortedSet<int> Set1 = new SortedSet<int>();
            SortedSet<int> Set2 = new SortedSet<int>();

            Set1.Add(11);
            Set1.Add(2);
            Set1.Add(4);
            Set1.Add(3);
            Set1.Add(1);
            Set1.Add(6);
            Set1.Add(9);
            Set1.Add(10);
            Set1.Add(7);
            Set1.Add(12);
            Set1.Add(13);
            Set1.Add(8);
            Set1.Add(5);

            Set2 = CompleteRange(arr);

            Set1.Print("List Elements: ");

            Set1.ExceptWith(Set2);

            Console.WriteLine($"\nThe elements will be removed at the range: [{string.Join(" , ", arr)}]");
            Set1.Print("\nList Elements after removing: ");

        }

        // Find all elements in a sortedset that are outside a given range.
        public static void GetElementsOutSideRange() 
        {
            int[] Range = { 5, 8 };
            SortedSet<int> Set1 = new SortedSet<int>();
            SortedSet<int> Set2 = CompleteRange(Range);
            Set1.Add(11);
            Set1.Add(2);
            Set1.Add(4);
            Set1.Add(3);
            Set1.Add(1);
            Set1.Add(6);
            Set1.Add(9);
            Set1.Add(10);
            Set1.Add(7);
            Set1.Add(12);
            Set1.Add(13);
            Set1.Add(8);
            Set1.Add(5);

            Set1.Print("All Elements: ");
            Set2.Print("Range: ");

            Set1.ExceptWith(Set2);
            Set1.Print("Elements outside range: ");
        }

        // Count the number of elements in a sortedset less than or equal a given value.
        private static int GetNumberOfElementsLessThanOrEqualGivenValue(SortedSet<int>Set,int value)
        {
            int Count = 0;

            foreach (int item in Set)
            {
                if (item <= value)
                    Count++;
                else
                    break;
            }

            return Count;
        }
        public static void GetNumberOfElementsLessThanOrEqualGivenValue()
        {
            int GivenValue = 7;
            SortedSet<int> Set1 = new SortedSet<int>();
            Set1.Add(11);
            Set1.Add(2);
            Set1.Add(4);
            Set1.Add(3);
            Set1.Add(1);
            Set1.Add(6);
            Set1.Add(9);
            Set1.Add(10);
            Set1.Add(7);
            Set1.Add(12);
            Set1.Add(13);
            Set1.Add(8);
            Set1.Add(5);

            Set1.Print("List Elements: ");
            Console.WriteLine($"Number of elements that less of equal than [{GivenValue}] is: {GetNumberOfElementsLessThanOrEqualGivenValue(Set1, GivenValue)}");
        }

        // Check if a sortedSet contains elements from multiple specified ranges.
        public static void CheckIfSortedSetContainsElementsFromMultipleSpecifiedRange()
        {
            SortedSet<int> Set1 = new SortedSet<int>();
            Set1.Add(11);
            Set1.Add(2);
            Set1.Add(4);
            Set1.Add(3);
            Set1.Add(1);
            Set1.Add(6);
            Set1.Add(9);
            Set1.Add(10);
            Set1.Add(7);
            Set1.Add(12);
            Set1.Add(13);
            Set1.Add(8);
            Set1.Add(5);
            SortedSet<int> Set2 = new SortedSet<int>();
            Set2.Add(4);
            Set2.Add(3);
            Set2.Add(1);
            SortedSet<int> Set3 = new SortedSet<int>();
            Set3.Add(7);
            Set3.Add(12);
            Set3.Add(13);
            SortedSet<int> Set4 = new SortedSet<int>();
            Set4.Add(27);
            Set4.Add(132);
            Set4.Add(123);


            Set1.Print("Set1 Elements: ");
            Set2.Print("Set2 Elements: ");
            Set3.Print("Set3 Elements: ");
            Set4.Print("Set4 Elements: ");


            Console.WriteLine($"Does Set2 Hold by Set1: {Set2.IsSubsetOf(Set1)}");
            Console.WriteLine($"Does Set3 Hold by Set1: {Set3.IsSubsetOf(Set1)}");
            Console.WriteLine($"Does Set4 Hold by Set1: {Set4.IsSubsetOf(Set1)}");
        }

        // Track player's scores in a game, storted by player names.
    }
}
