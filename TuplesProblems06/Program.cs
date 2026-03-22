using System.Net.Cache;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 04
        CheckStudentMarks();

        // Problem 03
        // EmployeesData();

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

    // Write a function that check the student mark and returns success status and the mark value.
    private static (int,string) _CheckStudentMark((string, int, int) Studnet)
    {
        return Studnet.Item3 >= 60 ? (Studnet.Item3, "Success") : (Studnet.Item3, "Failure");
    }
    public static void CheckStudentMarks()
    {
        (string, int, int) StudentInfo1 = ("Ghayath", 24, 70);
        (string, int, int) StudentInfo2 = ("Ali", 24, 48);

        Console.WriteLine($"Studnet: {StudentInfo1.Item1} is {_CheckStudentMark(StudentInfo1).Item2} with Mark: {_CheckStudentMark(StudentInfo1).Item1}");
        Console.WriteLine($"Studnet: {StudentInfo2.Item1} is {_CheckStudentMark(StudentInfo2).Item2} with Mark: {_CheckStudentMark(StudentInfo2).Item1}");
    }
}