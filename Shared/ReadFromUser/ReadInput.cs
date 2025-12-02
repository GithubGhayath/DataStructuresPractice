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
}
