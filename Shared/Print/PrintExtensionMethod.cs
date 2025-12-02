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
}
