using Shared.Print;
using Shared.ReadFromUser; 
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAndStackProblems01
{
    internal class QueueAndStackProgram
    {
        public static void Main(string[] args)
        {


            // Problem 5:
            SimulateVehiclesWaitingAtaTrafficSignal();





            // Problem 4:
            //PrintJob();



            // Problem 3:
            //UndoFunctionalityInCalculator();


            // Problem 2:
            //Console.WriteLine($"The 24 in binary: {ConvertDecimalNumberIntoBinary(24).PrintBinaryFormat()}");


            // Problem 1:
            //ImplementBrowserBackButton();




        }

        // Problem: Simulate vehicles waiting at a traffic signal.

        public static void SimulateVehiclesWaitingAtaTrafficSignal()
        {
            Queue<string> Vehicles = new Queue<string>();
            Vehicles.Enqueue("Car 1");
            Vehicles.Enqueue("Truck 1");
            Vehicles.Enqueue("Bike");
            Vehicles.Enqueue("Bus");


            Console.Write("Traffic Signal Simulation Started");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }

            while (Vehicles.Count > 0)
            {
                Thread.Sleep(2000);

                Console.WriteLine($"\n\n {Vehicles.Peek()} has passed the signal.");


                Console.WriteLine($"\nVehicles waiting: {string.Join(" , ", Vehicles)}");

                Vehicles.Dequeue();
            }

            Console.WriteLine("\n\nNo vehicles waiting.");
            Console.WriteLine("Traffic Signal Simulation Ended.");
        }
        // Problem: Use a queue to manage printer jobs.
        public static void PrintJob()
        {
            Queue<string> Jobs = new Queue<string>();
            string JobName = string.Empty;
            int count = 0;
            char letter = 'y';
            do
            {
                Console.WriteLine("Enter a job name: ");
                JobName = Console.ReadLine()!;
                Jobs.Enqueue(JobName);

                Console.WriteLine("\n\nComplete? [y/n]");
                letter = Convert.ToChar(Console.ReadLine()!);

            } while (letter == 'y');

            while (Jobs.Count > 0)
            {
                count = Jobs.Count;

                Console.WriteLine("\n\n\n");
                Console.WriteLine($" The {count} job: {Jobs.Peek()} in progress!");
                Jobs.Dequeue();
            }
        }

        // Problem: Implement undo functionality in a calculator.
        public static void UndoFunctionalityInCalculator()
        {
            Stack<decimal> ResultHistory = new Stack<decimal>();

            char letter = 'y';
            int Number1 = 0;
            int Number2 = 0;

            do
            {
                Console.WriteLine("Enter first number to sum: ");
                if (int.TryParse(Console.ReadLine(), out Number1))
                { }

                Console.WriteLine("Enter second number to sum: ");
                if (int.TryParse(Console.ReadLine(), out Number2))
                { }

                int Result = Number1 + Number2;
                Console.WriteLine($"\nThe result is : {Result}");
                ResultHistory.Push(Result);

                Console.WriteLine("\n\n Back Result [y/n]: ");
                letter = Convert.ToChar(Console.ReadLine()!);

                if (letter == 'y')
                {
                    break;
                }
              

            } while (true);

            do
            {
                if (ResultHistory.Count == 0) return;
                Console.WriteLine("\n The last result is: " + ResultHistory.Peek());
                ResultHistory.Pop();

                Console.WriteLine("\n Back Result [y/n]: ");
                letter = Convert.ToChar(Console.ReadLine()!);
            } while (letter == 'y');

        }

        // Problem 2: Convert a decimal number to binary using a stack.

        public static Stack<int> ConvertDecimalNumberIntoBinary(int DecimalNumber)
        {
            Stack<int> BinaryNumber = new Stack<int>();
            int Quotient = DecimalNumber;
            int Remainder = 0;

            while (Quotient > 0)
            {
                Remainder = Quotient % 2;


                Quotient = Convert.ToInt32(Math.Floor((decimal)Quotient / 2));

                BinaryNumber.Push(Remainder);
            }

            return BinaryNumber;
        }

        // Problem 1: Use a stack to implement a browser's back button functionality.
        public static void ImplementBrowserBackButton()
        {

            Stack<Page> Pages = new Stack<Page>();
            int Choies = 0;

         


            do
            {
                if (Choies != 0)
                    Pages = InspectChoice(Pages, Choies);

                Console.WriteLine("Choose the page number:");
                Console.WriteLine("[1]. the Animals page");
                Console.WriteLine("[2]. the Games page");
                Console.WriteLine("[3]. the Science page");
                Console.WriteLine("[4]. back.");


                Choies = ReadInput.ReadChoice(1, 4, "Enter a number from [1 ----> 4]: ");

            } while (Choies != 4);

         

            do
            {
                Pages = GetBackPage(Pages);

                Console.WriteLine("\n\n1. Back");
                Choies = ReadInput.ReadChoice(1, 1, "Enter a number 1: ");

            } while (Pages.Count > 0);


        }
        public static Stack<Page> GetBackPage(Stack<Page> Pages)
        {
            Stack<Page> pagesTemp = Pages;

            pagesTemp.Pop();
            Console.WriteLine(pagesTemp.Peek());

            return pagesTemp;
        }
        public static Stack<Page> InspectChoice(Stack<Page>Pages,int choice)
        {  
            Stack<Page> pages = Pages;
            Page Temp = new Page(); 
            switch (choice)
            {
                case 1:
                    {
                        Temp = new Page("Animals", "This page talks about different animals");
                        pages.Push(Temp);
                        Console.WriteLine(Temp);
                        break;
                    }
                case 2:
                    {
                        Temp = new Page("Games", "This page includes information about various games");
                        pages.Push(Temp);
                        Console.WriteLine(Temp);
                        break;
                    }
                case 3:
                    {
                        Temp = new Page("Science", "This page explains basic science ideas");
                        pages.Push(Temp);
                        Console.WriteLine(Temp);
                        break;
                    }
            }

            return pages;

        }
    }

    public class Page
    {
     
        private string _Title { get; }
        private string _body { get; }

        public Page(string title, string body) 
        {
           
            this._Title = title;
            this._body = body;
        }
        public Page() { }
        public override string ToString()
        {
            return $"\n\n\nPage Title: {this._Title}\n\n{_body}\n\n";
        }
      
    }
}
