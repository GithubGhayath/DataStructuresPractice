using Microsoft.VisualBasic;
using Shared.Print;
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 02
        RemoveDubplicate();

        // Problem 01
        // TestCopyFunction();
    }

    // Write a program to copy all key-value pairs from one Hashtable to another.
    private static Hashtable CopyHashTable(Hashtable ht)
    {
        Hashtable hashtable = new Hashtable();
        foreach (DictionaryEntry kvp in ht)
        {
            hashtable.Add(kvp.Key, kvp.Value);
        }
        return hashtable;
    }

    public static void TestCopyFunction()
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("a", "b");
        hashtable.Add(23, 123);
        hashtable.Add("a3", "dfa");


        CopyHashTable(hashtable).Print("The copied hash table: ");
    }

    // Given a list with duplicate values, use a SortedSet to remove duplicates and sort it.
    public static void RemoveDubplicate()
    {
        List<int> Numbers = new List<int> { 1, 1, 1, 1, 2, 3, 4, 3, 3, 4, 5, 5, 3, 2, 1, 6, 7, 5, 5, 4, 4, 3, 4, 5, 6, 7, 7, 8, 8, 9, 9, 9, 0, 10, 6, 7, 8, 9, 5, 4 };

        SortedSet<int> Number1 = new SortedSet<int>(Numbers);
        Numbers.Print("List With duplicate: ");
        Number1.Print("\n\nList without duplicate:");
    }


}