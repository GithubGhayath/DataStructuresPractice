internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 01
        PrintStudentInfo();
    }

    // Create a function that returns a student's name, age, and grade.
    public static (string, int, int) GetStudentInfo()
    {
        return ("Ghayath", 24, 13);
    }
    public static void PrintStudentInfo()
    {
        (string, int, int) StudentInfo = GetStudentInfo();
        Console.WriteLine($"{StudentInfo.Item1} | {StudentInfo.Item2} | {StudentInfo.Item3}");
    }
}