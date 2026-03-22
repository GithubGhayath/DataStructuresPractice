internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 02
        PlayerData();

        // Problem 01
        // PrintStudentInfo();
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

    // Use tuples to store and display a player's name, health, and score in a game
    private static (string, int, int) _ReadPlayerData()
    {
        Console.WriteLine("Enter Player Data at format [name,health,score]");
        string[] Info = Console.ReadLine()!.Split(',');
        return (Info[0], Convert.ToInt32(Info[1]), Convert.ToInt32(Info[2]));
    }

    public static void PlayerData()
    {
        (string, int, int) PlayerData = _ReadPlayerData();
        Console.WriteLine($"{PlayerData.Item1} | {PlayerData.Item2} | {PlayerData.Item3}");
    }
}