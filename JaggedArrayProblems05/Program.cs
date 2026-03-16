using Shared.Print;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem01
        StudentMarks();
    }

    // Use a jagged array to store marks of students across different subjects.
    public static void StudentMarks()
    {
        int[][] Marks = new int[3][];
        Marks[0] = new int[3] {90,85,88 };
        Marks[1] = new int[2] {90,85};
        Marks[2] = new int[4] {90,85,88,70 };

        Marks.Print("Student");
    }
}