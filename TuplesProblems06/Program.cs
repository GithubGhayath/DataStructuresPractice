internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 03
        EmployeesData();

        // Problem 02
        // PlayerData();

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

    // Use tuples to store and display a player's name, health, and score in a game.
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

    // Use tuples to store employee names and salaries, and compare them.
    public static void EmployeesData()
    {
        (string, double)[] Emps =
        {
           ("Alice", 5000.50),
           ("Bob", 6200.75),
           ("Charlie", 5800.00),
           ("David", 7200.25),
           ("Eve", 6600.80),
           ("Frank", 5400.40),
           ("Grace", 8100.90),
           ("Hannah", 4700.10),
           ("Ibrahim", 6900.60),
           ("Julia", 7500.00)
        };
        IEnumerable<(string,double)> OrderdEmps= Emps.OrderByDescending(e => e.Item2);

        Console.WriteLine("Employees order by salary: \n");
        
        foreach (var e in OrderdEmps)
            Console.WriteLine($"Name: {e.Item1} | Salary: {e.Item2}");
    }
}