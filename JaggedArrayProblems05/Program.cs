using Shared.Print;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem02
        CompanySales();

        // Problem01
        // StudentMarks();
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

    // Store sales data for a company across different regions for various quarters.
    public static void CompanySales()
    {
        int[][] Sales = new int[][]
        {
            new int[]{1000,1200,1100},
            new int[]{1500,1600},
            new int[]{9000,9500,9800,10200},
        };

        Sales.Print("Region", "Sales for company region:");
        Console.WriteLine("\n\nQuarterly sales for each region:");

        for (int i = 0; i < Sales.Length; i++)
        {
            int Sum = 0;
            for (int j = 0; j < Sales[i].Length; j++)
            {
                Sum += Sales[i][j];
            }
            Console.WriteLine($"Quarterly sales for region [{i + 1}]: {Sum / 4}");
        }
    }
}