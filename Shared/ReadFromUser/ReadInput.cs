namespace Shared.ReadFromUser;



public static class ReadInput
{
  
    public static int ReadChoice(int from, int to, string message)
    {
        int Choice = 0;
        bool Result = true;



        do
        {
            if (!Result)
                Console.WriteLine("Wrong choice try again!");

            Console.WriteLine(message);

            if (int.TryParse(Console.ReadLine(), out int c))
                Choice = c;

        } while (Result = (Choice < from || Choice > to));

        return Choice;
    }

    public static Queue<string> ReadInputInSpecificOrder(string message)
    {
        Queue<string> InPutQueue = new Queue<string>();
        char letter = 'y';
        do
        {
            Console.Clear();
            Console.WriteLine(message);
            InPutQueue.Enqueue(Console.ReadLine()!);

            Console.WriteLine("Do you want to add more tasks? [y/n]");
            letter = Convert.ToChar(Console.ReadLine()!);

        } while (letter == 'y');
        Console.Clear();
        return InPutQueue;
    }

    public static string ReadText(string message) 
    {
        string Text = string.Empty;
        bool TestResult = false;
        do
        {
            if (TestResult)
                Console.WriteLine("Invalid input try again");

            Console.WriteLine(message);
            Text = Console.ReadLine();

        } while (TestResult = string.IsNullOrEmpty(Text));

        return Text!;
    }
    public static Dictionary<string, string> ReadInfoAsKayValueFormat(string message) 
    {
        char _letter = 'n';
        bool _Result = true;
        Dictionary<string, string> Dictionary = new Dictionary<string, string>();

        do
        {
            if (_Result)
            {
                Console.WriteLine(message); // Accepted format Key/Value
                string _Input = Console.ReadLine()!;
                string _Key = _Input.Substring(0, _Input.IndexOf('/'));
                string _Value = _Input.Substring(_Input.IndexOf('/') + 1, (_Input.Length  - _Key.Length)-1 ) ;
                Dictionary.Add(_Key, _Value);
                Console.Clear();
            }

            Console.Write("Do you want to add more items [y/n]: ");
            _letter = Convert.ToChar(Console.ReadLine()!);

        } while (_Result = (_letter == 'y'));


        return Dictionary;
    }
}
