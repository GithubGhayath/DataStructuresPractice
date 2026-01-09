using Shared.Print;
using Shared.ReadFromUser; 
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QueueAndStackProblems01
{
    internal static class QueueAndStackProgram
    {
        public static void Main(string[] args)
        {
            // Problem 26
            EvaluateMathematicalExpression();

            // Problem 25
            //EvaluatePostfixExpression();

            // Problem 24
            // CheckBalancedParentheses();


            // Problem 23
            // ReverseStringUsingStack();


            // Problem 22
            //FindTheMiddleElementInQueue();


            // Problem 21
            // PerformRearrangeEvenAndOddElements();

            // Problem 20
            // PerformMissions();


            // Problem 19
            // PerformRearrangeQueue();

            // Problem 18
            // ImplementedQueue();

            // Problem 17
            // FirstNonRepeatingCharacter();


            // Problem 16
            // MergeTwoSortedQueues();


            // Problem 15
            // RotateAQueue(2);

            // Problem 14
            // InterleaveQueue();

            // Problem 13
            // PerformSorting();

            // Problem 12
            // GenerateBinaryNumbers(500000);


            // Problem 11
            // IsQueuePalindrome();


            // Problem 10
            // ReverseElementProblem();

            // Problem 9:
            // ProcessRequests();


            // Problem 8:
            // ServeCustomer();


            // Problem 7:
            // SimulateTheOrderOfExecutionTask(ReadInput.ReadInputInSpecificOrder("Enter a task?"));


            // Problem 6:
            // backtrackingMyDay();


            // Problem 5:
            // SimulateVehiclesWaitingAtaTrafficSignal();


            // Problem 4:
            // PrintJob();



            // Problem 3:
            // UndoFunctionalityInCalculator();


            // Problem 2:
            // Console.WriteLine($"The 24 in binary: {ConvertDecimalNumberIntoBinary(24).PrintBinaryFormat()}");


            // Problem 1:
            // ImplementBrowserBackButton();

        }
        // problem: Remove invalid parentheses  (())) ===> (())

        // problem: Check palindrome using a stack               input: madam = true    input: hello = false


        // problem: Clone a queue without using extra space
        
        
        
        
        
        // problem: Evaluate a mathematical expression containing +, -, (, ) without * or /.
        public static void EvaluateMathematicalExpression()
        {
            string Expression = string.Empty;
            Stack<double> Numbers = new Stack<double>();
            Stack<char> Operations = new Stack<char>();

            Expression = ReadInput.ReadText("Enter an expression: ");
            Expression = Expression.Trim();
            Console.WriteLine($"Evaluating expression: {Expression} ....."); // 1 + (2 - 3)  1+(2*(2+(1+2)))
            
            for (int i = 0; i < Expression.Length; i++)
            {
                if (Expression[i] == '+' || Expression[i] == '*' || Expression[i] == '/' || Expression[i] == '-')
                {
                    Operations.Push(Expression[i]);
                    continue;
                }

                if (char.IsNumber(Expression[i]))
                {
                    if (double.TryParse(Expression[i].ToString(), out double r))
                        Numbers.Push(r);
                    continue;
                }
            }

           

            while (Operations.Count > 0)
            {
                switch (Operations.Pop()) 
                {
                    case '*':
                        var LastTwoItemsToMultiply = GetLastTwoNumbersFromStack(Numbers);
                        Numbers.Push(LastTwoItemsToMultiply.Item2 * LastTwoItemsToMultiply.Item1);
                        break;


                    case '+':
                        var LastTwoItemsToSum = GetLastTwoNumbersFromStack(Numbers);
                        Numbers.Push(LastTwoItemsToSum.Item2 + LastTwoItemsToSum.Item1);
                        break;


                    case '/':
                        var LastTwoItemsToDivide = GetLastTwoNumbersFromStack(Numbers);
                        Numbers.Push(LastTwoItemsToDivide.Item2 / LastTwoItemsToDivide.Item1);
                        break;


                    case '-':
                        var LastTwoItemsToSub = GetLastTwoNumbersFromStack(Numbers);
                        Numbers.Push(LastTwoItemsToSub.Item2 - LastTwoItemsToSub.Item1);
                        break;
                }
            }
            Console.WriteLine($"The last element in the stack ({Numbers.Pop()}) is popped and returned as the result.");
        }
        // problem: Evaluate a postfix expression using a stack.
        private static (double, double) GetLastTwoNumbersFromStack(Stack<double> Numbers)
        {
            double FirstNumber = Numbers.Pop();
            double SecondNumber = Numbers.Pop();

            return (FirstNumber, SecondNumber);
        }
        public static void EvaluatePostfixExpression()
        {
            string Expression = string.Empty;
            Stack<double> Numbers = new Stack<double>();

            Expression = ReadInput.ReadText("Enter an expression: ");
            Expression = Expression.Trim();
            Console.WriteLine($"Evaluating expression: {Expression} .....");

            for (int i = 0; i < Expression.Length; i++)  // 231*+9- 
            {
                if (Expression[i] == '*')
                {
                    var LastTwoItems = GetLastTwoNumbersFromStack(Numbers);
                    Numbers.Push(LastTwoItems.Item1 * LastTwoItems.Item2);
                    continue;
                }

                if (Expression[i] == '-')
                {
                    var LastTwoItems = GetLastTwoNumbersFromStack(Numbers);
                    Numbers.Push(LastTwoItems.Item1 - LastTwoItems.Item2);
                    continue;
                }

                if (Expression[i] == '+')
                {
                    var LastTwoItems = GetLastTwoNumbersFromStack(Numbers);
                    Numbers.Push(LastTwoItems.Item1 + LastTwoItems.Item2);
                    continue;
                }

                if (Expression[i] == '/')
                {
                    var LastTwoItems = GetLastTwoNumbersFromStack(Numbers);
                    Numbers.Push(LastTwoItems.Item1 / LastTwoItems.Item2);
                    continue;
                }

                if (Expression[i] == '%')
                {
                    var LastTwoItems = GetLastTwoNumbersFromStack(Numbers);
                    Numbers.Push(LastTwoItems.Item1 % LastTwoItems.Item2);
                    continue;
                }
                if (double.TryParse(Expression[i].ToString(), out double r))
                {
                    Numbers.Push(r);
                }
            }
            Console.WriteLine($"The last element in the stack ({Numbers.Pop()}) is popped and returned as the result.");
        }
        // problem: Find Middle element in a queue 
        public static void FindTheMiddleElementInQueue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
        
            var Queue = queue.ToList();

          

            int MiddleElement = Queue[(int)Queue.Count / 2];

            queue.Print("Queue element: ");
            Console.WriteLine($"The middle element in queue {MiddleElement}");
        }
           
        // problem: Reverse a given string using a stack
        public static void ReverseStringUsingStack() 
        {
            string Word = "Hello";
            string ReversedWord = string.Empty;
            Stack<char> LettersTemp = new Stack<char>();
           
            
            for (int i = 0; i < Word.Length; i++)
            {
                LettersTemp.Push(Word[i]);
            }

            while (LettersTemp.Count > 0)
            {
                ReversedWord += LettersTemp.Pop();
            }

            Console.WriteLine($"The original word: {Word}");
            Console.WriteLine($"Word after revers: {ReversedWord}");

        }

        // problem: Check balanced parentheses
        public static void CheckBalancedParentheses()
        {
            Queue<char> ChartQueue = new Queue<char>();
            Stack<char> ChartStack = new Stack<char>();
            bool Result = false;
            string Text = ReadInput.ReadText("Enter parentheses: ");

            if (Text.Length % 2 != 0) 
            {
                Console.WriteLine("false");
                return;
            }
            int MiddleElement = Text.Length / 2;
            for (int i = 0; i < Text.Length; i++)
            {
                if (i <= MiddleElement - 1)
                    ChartQueue.Enqueue(Text[i]);
                else
                    ChartStack.Push(Text[i]);
            }


            while (ChartQueue.Count > 0)
            {

                char characterFromQueue = ChartQueue.Dequeue();
                char characterFromStack = ChartStack.Pop();

                if (characterFromQueue == '(')
                {
                    if (characterFromStack == ')')
                        Result = true;
                    else
                    {
                        Result = false;
                        break;
                    }
                }


                if (characterFromQueue == '{')
                {
                    if (characterFromStack == '}')
                        Result = true;
                    else
                    {
                        Result = false;
                        break;
                    }
                }


                if (characterFromQueue == '[')
                {
                    if (characterFromStack == ']')
                        Result = true;
                    else
                    {
                        Result = false;
                        break;
                    }
                }

            }

            Console.WriteLine(Result);
        }

        // problem: Rearrange even and odd elements
        private static bool CheckEvenNumber(int num)
        {
            return num % 2 == 0;
        }
        public static void PerformRearrangeEvenAndOddElements()
        {
            Queue<int> queue = new Queue<int>();
            Queue<int> Oddqueue = new Queue<int>();
            Queue<int> Evenqueue = new Queue<int>();
            int Count = 0;


            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            int TotelElemntNumber = queue.Count;


            queue.Print("Queue element: ");
            while (queue.Count > 0)
            {
                int temp = queue.Dequeue();

                if (CheckEvenNumber(temp))
                    Evenqueue.Enqueue(temp);
                else
                    Oddqueue.Enqueue(temp);
            }

            while (Count < TotelElemntNumber)
            {
                if (Evenqueue.Count > 0)
                    queue.Enqueue(Evenqueue.Dequeue());
                if (Evenqueue.Count == 0 && Oddqueue.Count > 0)
                    queue.Enqueue(Oddqueue.Dequeue());

                Count++;
            }

            queue.Print("Queue element after rearrange: ");
        }

        // problem: Priority Queue
        public class Mission
        {
            public string? Message { get; private set; }
            public int PriorityLevel { get; private set; }

            public Mission(int priorityLevel , string message)
            {
                this.PriorityLevel = priorityLevel;
                this.Message = message;
            }

            public override string ToString()
            {
                return $"{this.Message} | {this.PriorityLevel}";
            }
        }

        public static void PerformMissions()
        {
            Queue<Mission> queue = new Queue<Mission>();
            queue.Enqueue(new Mission(7, "Do homework."));
            queue.Enqueue(new Mission(5, "Go to gym."));
            queue.Enqueue(new Mission(4, "plying."));
            queue.Enqueue(new Mission(1, "codding."));
            queue.Enqueue(new Mission(6, "Studying."));
            queue.Enqueue(new Mission(2, "eating."));
            queue.Enqueue(new Mission(3, "go to university."));


            var SortedQueue = queue.OrderBy(o => o.PriorityLevel).ToList();


            Console.WriteLine("The missions ordered based on highest priority");
            SortedQueue.ForEach(m => Console.WriteLine(m));
        }


        // problem: Rearrange elements in  a queue alternately in increasing and decreasing order

        public static void PerformRearrangeQueue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);  // [1 , 2 , 3 , 4 , 5 , 6]
            queue.Print("Before Rearrange: ");
            RearrangeQueue(queue);
            queue.Print("After Rearrange: ");
        }
        public static void RearrangeQueue(Queue<int> queue)
        {
           
            Queue<int> FirstPart = new Queue<int>();
            Queue<int> SecondPart = new Queue<int>();
            Stack<int> Temp = new Stack<int>();
            int HalfOfQueueElementNumber = (int)Math.Ceiling((decimal)(queue.Count / 2));
            int Count = 0;
            int TotalCount = queue.Count;

            while (Count != HalfOfQueueElementNumber)
            {

                FirstPart.Enqueue(queue.Dequeue());
                Count++;
            }

            while (queue.Count>0)
            {

                Temp.Push(queue.Dequeue());
              
            }

            while (Temp.Count > 0)
            {

                SecondPart.Enqueue(Temp.Pop());
              
            }

            Count = 0;
            while (Count < TotalCount)
            {
                if (Count % 2 == 0)
                {
                    if (FirstPart.Count != 0)
                        queue.Enqueue(FirstPart.Dequeue());
                  
                }
                else
                {
                    if (SecondPart.Count != 0)
                        queue.Enqueue(SecondPart.Dequeue());
                }
                Count++;
            }


        }


        // problem: Implement a queue using two stacks. Enqueue() and Dequeue()
        public class CustomQueue<T> 
        {
            Stack<T> _EnqueueStack = new Stack<T>();    
            Stack<T> _DequeueStack = new Stack<T>();
            private int _NumberOfElement = 0;

            public int NumberOfElement
            {
                private set { _NumberOfElement = value; }
                get { return _NumberOfElement; }
            }

            public void Enqueue(T value) 
            {
                NumberOfElement++;
                _EnqueueStack.Push(value);
            }
          

            public T Dequeue()
            {
                ReverseStacks();
                _NumberOfElement--;
                return _DequeueStack.Pop();
            }

            private void ReverseStacks()
            {
                while (_EnqueueStack.Count > 0)
                {
                    _DequeueStack.Push(_EnqueueStack.Pop());
                }
            }
        }

        public static void ImplementedQueue()
        {
            CustomQueue<int> quque = new CustomQueue<int>();

            quque.Enqueue(1);
            quque.Enqueue(2);
            quque.Enqueue(3);
            quque.Enqueue(4);



            while (quque.NumberOfElement > 0)
            {
                Console.WriteLine(quque.Dequeue());
            }


        }

        // problem: First non-repeating character in a stream.

        private static void DictionaryCounter(Dictionary<char, int> Counter,char letter)
        {
            Dictionary<char, int> counter = Counter;

            if (counter.TryGetValue(letter, out int OldValue))
            {
                int NewValue = OldValue++;
                counter.Remove(letter);
                counter.Add(letter, NewValue);
            }
            else
            {
                counter.Add(letter, 1);
            }
        }

        public static (Queue<char>, Dictionary<char, int>) ReadCharFromUser()
        {
            Queue<char> chars = new Queue<char>();
            Dictionary<char, int> Counter = new Dictionary<char, int>();
            char letter = 'n';

            do
            {
                Console.Clear();
                Console.Write("Enter a char:  ");
                char InputChar = Convert.ToChar(Console.ReadLine()!);
                chars.Enqueue(InputChar);
                DictionaryCounter(Counter, InputChar);

                Console.WriteLine("\n\nDo you want to add more: [y/n]");
                letter = Convert.ToChar(Console.ReadLine()!);

            } while (letter == 'y');

            return (chars, Counter);
        }

        public static void FirstNonRepeatingCharacter()
        {
            var result = ReadCharFromUser();
            Queue<char> chars = result.Item1;
            Dictionary<char, int> Count= result.Item2;
            Queue<char> QueueNonRepeating = new Queue<char>();

            foreach (KeyValuePair<char, int> item in Count)
            {
                if (item.Value == 1)
                    QueueNonRepeating.Enqueue(item.Key);
            }

            chars.Print("\n\n\nThe user input: ");
            QueueNonRepeating.Print("\nUnique chars: ");
        }

        // problem: Merge two sorted queues.
        public static void MergeTwoSortedQueues()
        {
            Queue<int> FirstQueue = new Queue<int>();
            Queue<int> SecondQueue = new Queue<int>();
            Queue<int> SortedMergeQueue = new Queue<int>();
            int Count = 0;
            FirstQueue.Enqueue(2);
            FirstQueue.Enqueue(4);
            FirstQueue.Enqueue(3);
            FirstQueue.Enqueue(1); // [ 2 , 3  , 1]


            SecondQueue.Enqueue(8);
            SecondQueue.Enqueue(6);
            SecondQueue.Enqueue(7);
            SecondQueue.Enqueue(5); // [ 6 , 4  , 5]

            FirstQueue.Print("First queue:   ");
            SecondQueue.Print("Second queue:   ");

            FirstQueue = FirstQueue.OrderBy(i => i).ToList().ConvertListToQueue();
            SecondQueue = SecondQueue.OrderBy(i => i).ToList().ConvertListToQueue();
            int TotalCount = FirstQueue.Count + SecondQueue.Count;

            while (TotalCount > Count)
            {
                int FirstQueueElement;
                int SecondQueueElement;

                if (SecondQueue.Count > 0 && int.TryParse(SecondQueue.Peek().ToString(), out SecondQueueElement)) { }
                 else
                    SecondQueueElement = 0;
                if (FirstQueue.Count > 0 && int.TryParse(FirstQueue.Peek().ToString(), out FirstQueueElement)) { }
                else
                    FirstQueueElement = SecondQueueElement + 1;


                if (FirstQueueElement < SecondQueueElement)
                {
                    if (FirstQueue.Count > 0)
                        SortedMergeQueue.Enqueue(FirstQueue.Dequeue());
                }
                else
                {
                    if (SecondQueue.Count > 0)
                        SortedMergeQueue.Enqueue(SecondQueue.Dequeue());
                }

                Count++;
            }


            SortedMergeQueue.Print("After merge and sort:   ");

        }


        // problem: Rotate a queue by K positions.
        public static void RotateAQueue(int Kpositions)
        {
            Queue<int> Numbers = new Queue<int>();  // [ 1 , 2 , 3 , 4 , 5 , 6 ]
            Queue<int> Temp = new Queue<int>();
            Numbers.Enqueue(1);
            Numbers.Enqueue(2);
            Numbers.Enqueue(3);
            Numbers.Enqueue(4);
            Numbers.Enqueue(5);


            if (Kpositions < 0) return;
            if (Kpositions == 0)
                Numbers.Print($"Queue after rotate by {Kpositions}");
            if (Kpositions >= Numbers.Count)
                string.Join(" , ", Numbers.Reverse().ToList());

            for (int i = 0; i < Kpositions; i++)
            {
                Temp.Enqueue(Numbers.Dequeue());
                Numbers.Enqueue(Temp.Dequeue());
            }

            Numbers.Print($"Queue after rotate by K={Kpositions}:  ");
        }
        // problem: Interleave the first half of a queue with the second half.
        public static void InterleaveQueue()
        {
            Queue<int> Numbers = new Queue<int>();
            Stack<int> FirstHalf = new Stack<int>();
            Stack<int> SecondHalf = new Stack<int>();
            int Count = 0;
            Numbers.Enqueue(1);
            Numbers.Enqueue(2);
            Numbers.Enqueue(3);
            Numbers.Enqueue(4);
            Numbers.Enqueue(5);
            Numbers.Enqueue(6);
            Numbers.Enqueue(7);
            Numbers.Enqueue(8);
            Numbers.Enqueue(9);
            int HalfOfQueue = (int)Math.Ceiling((decimal)Numbers.Count / 2);

            Numbers.Print("Element queue before interleave: ");  // Element queue before interleave:  [ 1 , 2 , 3 , 4 , 5 , 6 ]

            while (Numbers.Count > 0)
            {
                if (Count < HalfOfQueue)
                    FirstHalf.Push(Numbers.Peek());
                else
                    SecondHalf.Push(Numbers.Peek());

                Numbers.Dequeue();
                Count++;
            }
           

            Count = 0;
            Numbers.Enqueue(FirstHalf.Pop());
           

            while (HalfOfQueue >= Count)
            {
                if (FirstHalf.Count != 0 && Numbers.Count % 2 == 0)
                    Numbers.Enqueue(FirstHalf.Pop());



                if (SecondHalf.Count != 0 && Numbers.Count % 2 != 0)
                    Numbers.Enqueue(SecondHalf.Pop());

                Count++;
            }

            Numbers.Print("\nElement queue After interleave: "); // Element queue After interleave:  [ 1 , 4 , 2 , 5 , 3 , 6 ]
        }

        // Problem: Sort elements in a queue in ascending order.
        public static Queue<int> SortQueueAsc(this Queue<int> queue)
        {
          


            List<int> Numbers = new List<int>();

            while (queue.Count > 0) 
            {
                Numbers.Add(queue.Peek());
                queue.Dequeue();
            }

            Numbers = Numbers.OrderBy(i => i).ToList();
            Numbers.ForEach(i => queue.Enqueue(i));

            return queue;

        }

        public static void PerformSorting()
        {
            Queue<int> Numbers = new Queue<int>();


            Numbers.Enqueue(5);
            Numbers.Enqueue(4);
            Numbers.Enqueue(6);
            Numbers.Enqueue(7);
            Numbers.Enqueue(2);
            Numbers.Enqueue(3);
            Numbers.Enqueue(1);


            Console.WriteLine(Numbers.PrintQueue("Unorder queue: "));

            Numbers = SortQueueAsc(Numbers);


            Console.WriteLine(Numbers.PrintQueue("order queue: "));
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
