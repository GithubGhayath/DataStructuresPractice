using Microsoft.VisualBasic;
using Shared.Print;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 04
        MaintainUniqueActiveUsers();


        // Problem 03
        // FindMissingNumber();

        // Problem 02
        // RemoveDubplicate();

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

    // Given a range of numbers, find the missing numbers by comparing with a SortedSet.
    public static void FindMissingNumber()
    {
        List<int> Range = new List<int>() { 1, 2, 4, 5, 6, 7, 9, 1, 2, 9 };

        SortedSet<int> Nums = new SortedSet<int>(Range);

        List<int> MissingNumbers = new List<int>();

        Range.Print("List Element: ");
        Nums.Print("Sorted set elements: ");

        int RangeStartAt = Nums.ToList()[0];

        for (int i = 0; i < Nums.Count; i++)
        {
            if (Nums.ToList()[i] != RangeStartAt)
            {
                MissingNumbers.Add(RangeStartAt);
                i--;
            }

            RangeStartAt++;
        }


        MissingNumbers.Print("\n\nMissing number at range: ");

    }

    // Maintain a list of unique active users by their login times, and automatically sort them in chronological order.

    public class User
    {
        public int Id { get; set; }
        public string NameName { get; set; }
        public string Password { get; set; }

     
    }
    

    public static void MaintainUniqueActiveUsers()
    {
       
        SortedList<DateTime,User> activeUsers = new SortedList<DateTime,User>();

        activeUsers.Add(new DateTime(2022, 10, 2), new User { Id = 1, NameName = "Alice", Password = "password1" });
        activeUsers.Add(new DateTime(2024, 10, 2), new User { Id = 3, NameName = "Charlie", Password = "password3" });
        activeUsers.Add(new DateTime(2023, 10, 2), new User { Id = 2, NameName = "Bob", Password = "password2" });



        foreach (var user in activeUsers)
        {
            Console.WriteLine($"User: {user.Value.NameName}, Login Time: {user.Key}");
        }
    }
}