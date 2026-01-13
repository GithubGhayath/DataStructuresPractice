namespace Shared.Print;

public static class PrintExtensionMethod
{
    public static string PrintBinaryFormat<TSource>(this Stack<TSource> source)
    {
        // The input
        //0
        //0
        //0
        //1
        //0
        //1
        //1

        // The result:
        //0001011
        string Result = string.Empty;

        while (source.Count > 0)
        {
            Result += source.Peek();
            source.Pop();
        }
        return Result;
    }

    public static string PrintQueue<TSource>(this Queue<TSource> sources,string Message)
    {
        return $"{Message} {string.Join(" , ", sources)}";
    }
    public static Queue<TSource> ConvertListToQueue<TSource>(this List<TSource> source)
    {
        Queue<TSource> Result = new Queue<TSource>();

        foreach (TSource item in source) 
        {
            Result.Enqueue(item);
        }

        return Result;
    }

    public static void Print<Tkey,TValue>(this Dictionary<Tkey, TValue> Dictionary,string Message)
    {
        Console.WriteLine($"\n\n{Message}");
        foreach (KeyValuePair<Tkey, TValue> kvp in Dictionary) 
        {
            Console.WriteLine($"{kvp.Key} | {kvp.Value}");
        }
    }

    public static void Print<T>(this HashSet<T> HashSet,string message)
    {
        Console.WriteLine($"\n\n{message}");
        foreach (T item in HashSet)
        {
            Console.Write(item + " ");
        }
    }
}
