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
    internal static class QueueAndStackProgram
    {
        public static void Main(string[] args)
        {
            // Problem 12
            GenerateBinaryNumbers(500000);


            // Problem 11
            // IsQueuePalindrome();


            // Problem 10
            // ReverseElementProblem();

            // Problem 9:
            //ProcessRequests();


            // Problem 8:
            //ServeCustomer();


            // Problem 7:
            //SimulateTheOrderOfExecutionTask(ReadInput.ReadInputInSpecificOrder("Enter a task?"));


            // Problem 6:
            //backtrackingMyDay();


            // Problem 5:
            //SimulateVehiclesWaitingAtaTrafficSignal();


            // Problem 4:
            //PrintJob();



            // Problem 3:
            //UndoFunctionalityInCalculator();


            // Problem 2:
            //Console.WriteLine($"The 24 in binary: {ConvertDecimalNumberIntoBinary(24).PrintBinaryFormat()}");


            // Problem 1:
            //ImplementBrowserBackButton();

        }

        // Problem: Generate binary numbers from 1 to N using a queue.
        public static void GenerateBinaryNumbers(int n)
        {
            
          

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("1");


            for (int i = 0; i < n; i++)
            {
                string binary = queue.Dequeue();
                Console.WriteLine(binary);
                queue.Enqueue(binary + "0");
                queue.Enqueue(binary + "1");
            }
        }


     

        // Problem: Check if a queue is a palindrome (same forwards and backwards).   [1, 2, 3, 2, 1]
        public static void IsQueuePalindrome()
        {

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);

            Console.WriteLine(IsQueuePalindrome(queue));
        }

        public static bool IsQueuePalindrome(Queue<int> queue)
        {
            List<int> NormalOrder = queue.ToList();
            List<int> ReverseOrder = queue.Reverse().ToList();

            for (int i = 0; i < NormalOrder.Count; i++)
            {
                if (NormalOrder[i] != ReverseOrder[i])
                    return false;
            }
            return true;
        }

        // Problem: Given a queue, reverse its elements.
        public static void ReverseElementProblem()
        {
            Queue<int> numbers = new Queue<int>();  // 1 , 2 , 3 , 4
            numbers.Enqueue(1);
            numbers.Enqueue(2);
            numbers.Enqueue(3);
            numbers.Enqueue(4);

            Queue<string> Words = new Queue<string>();  // "Ghayath" , "Ali" , "Maher" , "Yara" 
            Words.Enqueue("Ghayath");
            Words.Enqueue("Ali");
            Words.Enqueue("Maher");
            Words.Enqueue("Yara");

            numbers.Print("The number before: ");
            Words.Print("The Words before: ");


            numbers = numbers.ManualReverse();
            Words = Words.ManualReverse();


            numbers.Print("The number after: ");
            Words.Print("The Words after: ");

        }
        public static Queue<TSource> ManualReverse<TSource>(this Queue<TSource> souce)
        {
            Queue<TSource> Qtemp = new Queue<TSource>();
            Stack<TSource> Stemp = new Stack<TSource>();

            foreach (TSource item in souce) 
            {
                Stemp.Push(item);
            }

            foreach (TSource item in Stemp)
            {
                Qtemp.Enqueue(item);
            }

            return Qtemp;
        }
        public static void Print<TSource>(this Queue<TSource> sources,string message)
        {
            Console.WriteLine($"{message}: {string.Join(" , ", sources)}");
        }
        // Problem: Simulate a web server that processes requests in the order they arrive:
        public static void ProcessRequests()
        {
            List<WebPage> webPages = GenerateWebPages(10);
            Queue<WebPage> Requests = new Queue<WebPage>();

            foreach (WebPage webPage in webPages) 
            {
                Thread.Sleep(2000);
                Requests = NewRequest(webPage, Requests);
            }
            Console.WriteLine("\n\n\n");

            while(Requests.Count > 0)
            {
                Thread.Sleep(1000);
                Requests = ProcessRequest(Requests);
            }

        }
        public static Queue<WebPage> ProcessRequest(Queue<WebPage> requests)
        {
            Queue<WebPage> Requests = requests;

            Console.WriteLine($"\nThe current request is processed: {Requests.Peek()}");

            Requests.Dequeue();

            if (Requests.Count > 0)
                Console.WriteLine($"The next request to process: {Requests.Peek()}");

            return Requests;
        }
        public static Queue<WebPage> NewRequest(WebPage webPage, Queue<WebPage> requests)
        {
            Queue<WebPage> Requests = requests;

            Requests.Enqueue(webPage);

            Console.WriteLine($"\nNew request arrives: {webPage}");

            return Requests;
        }
        public static List<WebPage> GenerateWebPages(int numberOfObjects)
        {
            List<WebPage> pages = new List<WebPage>();

            for (int i = 1; i <= numberOfObjects; i++)
            {
                pages.Add(new WebPage
                {
                    WebPageId = i,
                    Endpoint = $"https://example.com/page/{i}",
                    RequestDateAndTime = DateTime.Now.AddSeconds(-i)
                });
            }

            return pages;
        }
        public class WebPage
        {
            public int WebPageId { get; set; }
            public string? Endpoint { get; set; }
            public DateTime RequestDateAndTime { get; set; }

            public override string ToString()
            {
                return $"{this.WebPageId} | {this.Endpoint} | {this.RequestDateAndTime}";
            }

        }

        // Problem: Simulate a customer service system where customers are served in the order they arrive.
        public static void ServeCustomer()
        {
            List<Customer> CustomerGenerated = GenerateCustomers(10);
            Queue<Customer> customers = new Queue<Customer>();

            foreach(Customer customer in CustomerGenerated)
            {
                Thread.Sleep(2000);
                customers = NewCustomer(customer, customers);
            }
            Console.WriteLine("\n\n\n\n");

            while (customers.Count > 0)
            {
                Thread.Sleep(1000);
                customers = ServeCustomer(customers);
            }

            Console.WriteLine("\n\n The process is done...");
        }
        public static Queue<Customer> NewCustomer(Customer customer, Queue<Customer> List)
        {
            Queue<Customer> OrderList = List;

            OrderList.Enqueue(customer);

            Console.WriteLine($"New customer arrives: {customer}");

            return OrderList;
        }

        public static Queue<Customer> ServeCustomer(Queue<Customer> OrderList)
        {
            Queue<Customer> list = OrderList;

            Console.WriteLine($"The current customer is served{list.Peek()}");

            list.Dequeue();

            if (list.Count > 0)
                Console.WriteLine($"The Next customer to serve{list.Peek()}");

            return list;
        }

        public static List<Customer> GenerateCustomers(int numberOfObjects)
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 1; i <= numberOfObjects; i++)
            {
                customers.Add(new Customer
                {
                    OrderID = i,
                    CustomerName = $"Customer {i}",
                    OrderDateAndTime = DateTime.Now.AddMinutes(-i), // Just random variation
                    Contents = new List<string> { "Item A", "Item B", $"Item {i}" }
                });
            }

            return customers;
        }

        public class Customer
        {
            public int OrderID { get; set; }
            public string? CustomerName { get; set; }

            public List<string> Contents = new List<string>();

            public DateTime OrderDateAndTime { get; set; }

            public override string ToString()
            {
                return $"{this.OrderID} | {this.CustomerName} | {OrderDateAndTime}\n\t\t{string.Join(", ", Contents)}";
            }
        }


        // Problem: Given a set of tasks with a specific order, simulate the order of execution using a queue.
        public static void SimulateTheOrderOfExecutionTask(Queue<string> list)
        {
           
            Console.WriteLine($"Input: {string.Join(" , ", list)}");
            Console.WriteLine("\n\nExecute tasks in the order they appear.");
        }

        // Problem: Use a stack for backtracking My Day.
        public static void backtrackingMyDay()
        {

            string[] arr = new string[]
            {
                "Start",
                "Go to Gaz Station",
                "Go to Super Market",
                "Go To Work",
                "Go to Cafe",
                "Go Home"
            };

            Stack<string> BackTracking = new Stack<string>();

            for (int i = 0; i <= arr.Length - 1; i++)
                BackTracking.Push(arr[i]);



            Console.Write("Backtracking");
            for (int i = 0; i <= 5; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }

            Console.WriteLine();

            var ReversedStack = BackTracking.Reverse().ToList();
            Console.Write($"{ReversedStack[0]}");
            for (int i = 1; i <= ReversedStack.Count()-1; i++)
            {
                //Start -> Go to Gaz Station -> Go to Super Market -> Go To Work -> Go to Cafe -> Go Home.
                Thread.Sleep(500);
                Console.Write($" -> {ReversedStack[i]}");
            }
        
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
                Vehicles.Dequeue();


                Console.WriteLine($"\nVehicles waiting: {string.Join(" , ", Vehicles)}");

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
