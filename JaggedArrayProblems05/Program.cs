using Shared.Print;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem06
        SurveyResponses();


        // Problem05
        // FlightSeats();


        // Problem04
        // ProductsSales();

        // Problem03
        // ClassroomSeats();

        // Problem02
        // CompanySales();

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

    // Each row in a classroom has a different number of seats. Store the seating arrangement and access each seat dynamically.
    public class Seat
    {
        public Seat(int seatNumber, string seatName)
        {
            SeatNumber = seatNumber;
            SeatName = seatName;
        }

        public int SeatNumber { get; set; }
        public string SeatName {  get; set; }

        public override string ToString()
        {
            return $"Seat Number: {this.SeatNumber} | Seat Name: {this.SeatName}";
        }
    }
    public static void ClassroomSeats()
    {
        Seat[][] Seats = new Seat[5][];
        Seats[0] = new Seat[4] {new Seat(1,"First Disk"), new Seat(2, "Second Disk"), new Seat(3, "Third Disk"), new Seat(4, "Fourth Disk") };
        Seats[1] = new Seat[3] {new Seat(5,"Fifth Disk"), new Seat(6, "Sixth Disk"), new Seat(7, "Seventh Disk") };
        Seats[2] = new Seat[2] {new Seat(8,"Eighth Disk"), new Seat(9, "Nighnth Disk")};
        Seats[3] = new Seat[1] {new Seat(10,"Tenth Disk") };
        Seats[4] = new Seat[4] {new Seat(11,"Eleventh Disk"), new Seat(12, "Twelvth Disk"), new Seat(13, "Therrteenth Disk"), new Seat(14, "Fourteenth Disk") };

        Seats.Print("Seat row", "Classroom:");
    }

    // Store the sales for different products, where each product has varying daily sales.
    public static void ProductsSales()
    {
        int[][] Products = new int[5][];
        Products[0] = new int[4] {123,432,546,234 };
        Products[1] = new int[3] {123,432,546 };
        Products[2] = new int[2] {123,432 };
        Products[3] = new int[6] {123,432,546,234,76,32};
        Products[4] = new int[1] {123};

        Products.Print("Product", "Product Sales: ");
    }

    // Store seat availability for multiple flights where each flight has a different number of seats.
    public static void FlightSeats()
    {
        bool[][] FlightSeat = new bool[6][];
        FlightSeat[0] = new bool[4] { false, true, false,true };
        FlightSeat[1] = new bool[6] { false, true, false,true, false, true };
        FlightSeat[2] = new bool[7] { false, true, false,true, false, true, false};
        FlightSeat[3] = new bool[2] { false, true };
        FlightSeat[4] = new bool[1] { false };
        FlightSeat[5] = new bool[9] { false, true, true, true, true, false, true, false,true };

        FlightSeat.Print("Flight", "Seat availability: ");
    }
    // Store survey responses where each respondent answers a different number of questions.
    public static void SurveyResponses()
    {
        bool[][] SurveyResponses = new bool[6][];
        SurveyResponses[0] = new bool[4] { false, true, false, true };
        SurveyResponses[1] = new bool[6] { false, true, false, true, false, true };
        SurveyResponses[2] = new bool[7] { false, true, false, true, false, true, false };
        SurveyResponses[3] = new bool[2] { false, true };
        SurveyResponses[4] = new bool[1] { false };
        SurveyResponses[5] = new bool[9] { false, true, true, true, true, false, true, false, true };

        SurveyResponses.Print("Answer", "Survey responses");
    }

}