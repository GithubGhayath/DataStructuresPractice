using Microsoft.VisualBasic;
using Shared.Print;
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 01
        TestCopyFunction();
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
}