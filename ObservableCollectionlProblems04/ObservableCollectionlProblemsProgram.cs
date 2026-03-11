using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace ObservableCollectionlProblems04
{
    internal class ObservableCollectionlProblemsProgram
    {
        public static void Main(string[] agrs)
        {
            // Problem 07
            ChatMessages();
            
            // Problem 06
            // DynamicListOfWeather();


            // Problem 05
            // NotificationOrderManagment();


            // Problem 04
            // ListOfTask();


            // Problem 03
            // StockSimulation();


            // Problem 02
            // ShoppinngProcess();


            // Problem 01
            // ClassRoom();
        }

        // Maintain and display a dynamic list of students in a classroom
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Level {  get; set; }
            public int Age {  get; set; }

            public Student(int id, string name, int level, int age)
            {
                Id = id;
                Name = name;
                Level = level;
                Age = age;
            }
            public override string ToString()
            {
                return $"{this.Id} | {this.Name} | {this.Level} | {this.Age}";
            }
        }

        public static void ClassRoom()
        {
            ObservableCollection<Student> _Students = new ObservableCollection<Student>();
            _Students.CollectionChanged += _Students_CollectionChanged;
            Student Student1 = new Student(1, "Ghayth Alali", 12, 23);
            Student Student2 = new Student(2, "Yara Almasri", 11, 24);
            Student Student3 = new Student(3, "Maya Jamal", 14, 19);
            Student Student4 = new Student(4, "Sham zeen", 23, 20);
            Student Student5 = new Student(5, "Roa Sham", 14, 21);
            Student Student6 = new Student(6, "Khalid ke", 15, 25);

            _Students.Add(Student1);
            _Students.Add(Student2);

            _Students.Remove(Student1);

            _Students.Add(Student3);

            _Students.Add(Student4);
            _Students.Add(Student5);

            _Students.Move(0, 3);
            _Students.Add(Student6);

            _Students[0] = Student3;
            
            _Students.Clear();
        }

        private static void _Students_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Console.WriteLine($"A new student added");
                        Console.WriteLine("\nClassroom now:");
                       foreach(var item in e.NewItems!)
                            Console.WriteLine(item.ToString());
                        break;
                    }

                case NotifyCollectionChangedAction.Remove:
                    {
                        Console.WriteLine($"A student Leave");
                        Console.WriteLine("\nClassroom now:");

                        foreach (var item in e.OldItems!)
                            Console.WriteLine(item.ToString());

                        break;
                    }

                case NotifyCollectionChangedAction.Move:
                    {
                        Console.WriteLine($"A student Moved");
                        Console.WriteLine("\nClassroom now:");

                        foreach (var item in e.OldItems!)
                            Console.WriteLine(item.ToString());
                        break;
                    }

                case NotifyCollectionChangedAction.Replace:
                    {
                        Console.WriteLine($"A student Replaced");
                        Console.WriteLine("\nClassroom now:");

                        foreach (var item in e.OldItems!)
                            Console.WriteLine(item.ToString());
                        break;
                    }

                case NotifyCollectionChangedAction.Reset:
                    {
                        Console.WriteLine($"Classroom is empty");
                        Console.WriteLine("\nNo one at Classroom now:");

                       
                        break;
                    }
            }
        }


        // Maintain a shopping cart where items can be addded removed or replaced and notify the ui
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Catigory { get; set; }
            public Product(int id, string name, string catigory)
            {
                Id = id;
                Name = name;
                Catigory = catigory;
            }

            public override string ToString()
            {
                return $"{this.Id} | {this.Name} | {this.Catigory}";
            }
        }

        public static void ShoppinngProcess()
        {
            Product product1 = new Product(1, "Laptop", "Elictric");
            Product product2 = new Product(2, "Mobile", "Elictric");
            Product product3 = new Product(3, "Chary", "Frute");
            Product product4 = new Product(4, "Eggs", "Food");
            Product product5 = new Product(5, "Tomato", "Food");
            Product product6 = new Product(6, "Bods", "Elictric");
            ObservableCollection<Product> Cart = new ObservableCollection<Product>();
            Cart.CollectionChanged += Cart_CollectionChanged;

            Cart.Add(product1);
            Cart.Add(product2);
            Cart.Add(product3);
            Cart.Add(product4);
            Cart.Add(product5);
            Cart.Remove(product1);
            Cart.Move(2,3);
            Cart[0]=product6;
        }

        private static void Cart_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add: 
                    {
                        Console.WriteLine("Prodect added to the cart");
                        break;
                    }

                case NotifyCollectionChangedAction.Remove:
                    {
                        Console.WriteLine("Prodect removed from the cart");
                        break;
                    }

                case NotifyCollectionChangedAction.Replace:
                    {
                        Console.WriteLine("Prodect replaced with another from the cart");
                        break;
                    }
                case NotifyCollectionChangedAction.Move:
                    {
                        Console.WriteLine("Prodect moved from the cart");
                        break;
                    }
                case NotifyCollectionChangedAction.Reset:
                    {
                        Console.WriteLine("The cart is empty");
                        break;
                    }

            }
        }


        // Display a list of real-time stock prices that update dynamically
        public static void StockSimulation()
        {
            Product product1 = new Product(1, "Laptop", "Elictric");
            Product product2 = new Product(2, "Mobile", "Elictric");
            Product product3 = new Product(3, "Chary", "Frute");
            Product product4 = new Product(4, "Eggs", "Food");
            Product product5 = new Product(5, "Tomato", "Food");
            Product product6 = new Product(6, "Bods", "Elictric");
            ObservableCollection<Product> Stock = new ObservableCollection<Product>();
            Stock.CollectionChanged += Stock_CollectionChanged;
            Stock.Add(product1);
            Stock.Add(product2);
            Stock.Add(product3);
            Stock.Add(product4);
            Stock.Add(product5);
            Stock.Remove(product1);
            Stock.Move(2, 3);
            Stock[0] = product6;
        }

        private static void Stock_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Console.WriteLine("Prodect added to the cart");
                        foreach(var item in e.NewItems!)
                            Console.WriteLine(item.ToString());
                        break;
                    }

                case NotifyCollectionChangedAction.Remove:
                    {
                        Console.WriteLine("Prodect removed from the cart");
                       
                        break;
                    }

                case NotifyCollectionChangedAction.Replace:
                    {
                        Console.WriteLine("Prodect replaced with another from the cart");
                        foreach (var item in e.NewItems!)
                            Console.WriteLine(item.ToString());
                        break;
                    }
                case NotifyCollectionChangedAction.Move:
                    {
                        Console.WriteLine("Prodect moved from the cart");
                        foreach (var item in e.NewItems!)
                            Console.WriteLine(item.ToString());
                        break;
                    }
                case NotifyCollectionChangedAction.Reset:
                    {
                        Console.WriteLine("The cart is empty");
                        break;
                    }

            }
        }

        // Manage a list of tasks dynamically allowing addition,removal,and status updates
        private static void _ReadTask(ObservableCollection<clsTask> list)
        {
            Console.WriteLine("Write the task at format id/TaskName/ImportantLevel");
            string TaskText = Console.ReadLine()!;
            string[]arr = TaskText.Split('/');
            list.Add(new clsTask(Convert.ToInt32(arr[0]), arr[1], Convert.ToInt32(arr[2])));
        }
        private static void _RemoveTask(ObservableCollection<clsTask> list)
        {
            
            Console.WriteLine("Enter index of task that you want to remove: ");
            int Index = Convert.ToInt32(Console.ReadLine())!;
            if (list.Count > Index && Index >= 0)
                list.RemoveAt(Index);
        }
        private static void _ReplaceTask(ObservableCollection<clsTask> list)
        {
            Console.WriteLine("Write the task at format id/TaskName/ImportantLevel");
            string TaskText = Console.ReadLine()!;
            string[] arr = TaskText.Split('/');
            Console.WriteLine("Enter index you want to reaplce with");
            int Index = Convert.ToInt32(Console.ReadLine());
           clsTask NewTaks = (new clsTask(Convert.ToInt32(arr[0]), arr[1], Convert.ToInt32(arr[2])));

            if (list.Count > Index && Index >= 0)
                list[Index] = NewTaks;
        }
        private static void _PrintList(ObservableCollection<clsTask> list)
        {
            Console.WriteLine("\n\n Task List: ");
            foreach(var item in  list)
                Console.WriteLine(item.ToString());
        }
        public class clsTask
        {
            public int Id { get; set; }
            public string? TaskName {  get; set; }
            public int ImportantLevel {  get; set; }
            public clsTask(int id, string? taskName, int importantLevel)
            {
                Id = id;
                TaskName = taskName;
                ImportantLevel = importantLevel;
            }
            public override string ToString()
            {
                return $"{this.Id} | {this.TaskName} | {this.ImportantLevel}";
            }
        }
        public static void ListOfTask()
        {
            char letter = 'n';
            int Choice = 0;
          
            ObservableCollection<clsTask> List = new ObservableCollection<clsTask>();
            List.CollectionChanged += List_CollectionChanged;
            do
            {
               
                Console.WriteLine("what do you want to do:\n[1]. Adding Task\n[2]. Remove Task\n[3]. Update Task\n[4]. Print Task list");
                Choice = Convert.ToInt32(Console.ReadLine());

                switch (Choice)
                {
                    case 1:
                        {
                            _ReadTask(List);
                            break;
                        }

                    case 2:
                        {
                            _RemoveTask(List);
                            break;
                        }

                    case 3:
                        {
                            _ReplaceTask(List);
                            break;
                        }
                    case 4:
                        {
                            _PrintList(List);
                            break;
                        }
                }

                Console.WriteLine("Do you want to do oparations at task list [y/n]:");
                letter = Convert.ToChar(Console.ReadLine()!);

            } while (letter == 'y');

        }
        private static void List_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Console.WriteLine("New task added to the list");
                       
                        break;
                    }

                case NotifyCollectionChangedAction.Remove:
                    {
                        Console.WriteLine("Task removed from the List");

                        break;
                    }

                case NotifyCollectionChangedAction.Replace:
                    {
                        Console.WriteLine("Task replaced with another from the list");
                       
                        break;
                    }
              

            }
        }

        // Display live chat messages in a chat application as they are received
        public class Message
        {
            public Message(int id, string content, DateTime dateTimeOfMessage, string sender)
            {
                Id = id;
                Content = content;
                DateTimeOfMessage = dateTimeOfMessage;
                Sender = sender;
            }

            public int Id { get; set; }
            public string Content { get; set; }
            public DateTime DateTimeOfMessage { get; set; }
            public string Sender { get; set; }
            

            public override string ToString()
            {
                return $"\n\n{this.Sender}\n{this.Content}\n\t{this.DateTimeOfMessage.ToString("g")}";
            }

        }
        public static void ChatMessages()
        {
            ObservableCollection<Message> Messages = new ObservableCollection<Message>();
            Messages.CollectionChanged += Messages_CollectionChanged;

            Messages.Add(new Message(1, "Hi,This is Ghayath Al.Ali", DateTime.Now, "Ghayath Alali"));
            Thread.Sleep(3000);
            Messages.Add(new Message(1, "Hello Ghayath, This is jumes form Customer service\nHow can i help you", DateTime.Now, "Jumes Customer service"));
            Thread.Sleep(3000);
            Messages.Add(new Message(1, "Hi Jumes,I faced a problem while trying the product that i bout yesterday!", DateTime.Now, "Ghayath Alali"));
            Thread.Sleep(3000);
            Messages.Add(new Message(1, "Ok Ghayth, Can you provide more detail, what product is talking about and do you still have a recept?", DateTime.Now, "Jumes Customer service"));
            Thread.Sleep(3000);
            Messages.Add(new Message(1, "Yessterday i bout a new laptop from your store, when i was trying to charge it, the charger or the charge port it didn't work", DateTime.Now, "Ghayath Alali"));
            Thread.Sleep(3000);
            Messages.Add(new Message(1, "Oh i'm so sorry about that,by the way you could return the product and get a refund or you can exchange it if you want that, as you know our symboles is that customer is king and king never bargens", DateTime.Now, "Jumes Customer service"));
            Thread.Sleep(3000);
            Messages.Add(new Message(1, "Ok jumse i appreachate that,i will came right now, Just the way distans, All greadents:)", DateTime.Now, "Ghayath Alali"));

        }

        private static void Messages_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine($"New message recived:\n{e.NewItems![0]}");
            }
        }


        // Display a dynamic list of weather updates for different cities
        public class Weather
        {
            public int Id {  get; set; }
            public int OldTemp {  get; set; }
            public int NewTemp { get; set; }
            public override string ToString()
            {
                return $"{this.Id} | {this.OldTemp} | {this.NewTemp}";
            }
            public Weather(int id, int oldTemp, int newTemp)
            {
                Id = id;
                OldTemp = oldTemp;
                NewTemp = newTemp;
            }
        }
        public static void DynamicListOfWeather()
        {
            ObservableCollection<Weather> WeatherList = new ObservableCollection<Weather>();
            WeatherList.CollectionChanged += WeatherList_CollectionChanged;

            WeatherList.Add(new Weather(1, 30, 32));
            Thread.Sleep(2000);
            WeatherList[0] = new Weather(2, 31, 35);
            Thread.Sleep(2000);
            WeatherList[0] = new Weather(3, 45, 36);
            Thread.Sleep(3000);
            WeatherList[0] = new Weather(4, 34, 37);
            Thread.Sleep(4000);
            WeatherList[0] = new Weather(5, 12, 38);
            Thread.Sleep(5000);
            WeatherList[0] = new Weather(6, 28, 30);
        }

        private static void WeatherList_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace) 
            {
                Console.WriteLine($"The new temp: {e.NewItems![0]}");
            }
        }

        // Display notifications about your order dynamically as they arrive
        public class Order
        {
            public Order(int id, string name, string orderNumber)
            {
                Id = id;
                Name = name;
                OrderNumber = orderNumber;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string OrderNumber {  get; set; }

            public override string ToString()
            {
                return $"{this.Id} | {this.Name} | {this.OrderNumber}";
            }
        }
        public static void NotificationOrderManagment()
        {
            ObservableCollection<Order> Orders = new ObservableCollection<Order>();
            Orders.CollectionChanged += Orders_CollectionChanged;
            Order order1 = new Order(1, Guid.NewGuid().ToString().Substring(0, 4), Guid.NewGuid().ToString().Substring(0, 13));
            Order order2 = new Order(2, Guid.NewGuid().ToString().Substring(0, 4), Guid.NewGuid().ToString().Substring(0, 13));
            Order order3 = new Order(3, Guid.NewGuid().ToString().Substring(0, 4), Guid.NewGuid().ToString().Substring(0, 13));
            Order order4 = new Order(4, Guid.NewGuid().ToString().Substring(0, 4), Guid.NewGuid().ToString().Substring(0, 13));
            Order order5 = new Order(5, Guid.NewGuid().ToString().Substring(0, 4), Guid.NewGuid().ToString().Substring(0, 13));
            Order order6 = new Order(6, Guid.NewGuid().ToString().Substring(0, 4), Guid.NewGuid().ToString().Substring(0, 13));
            Order order7 = new Order(7, Guid.NewGuid().ToString().Substring(0, 4), Guid.NewGuid().ToString().Substring(0, 13));

            Orders.Add(order1);
            Thread.Sleep(1000);
            Orders.Add(order2);
            Thread.Sleep(2000);
            Orders.Add(order3);
            Thread.Sleep(5000);
            Orders.Add(order4);
            Thread.Sleep(4000);
            Orders.Add(order5);
            Thread.Sleep(3000);
            Orders.Add(order6);
            Thread.Sleep(3000);
            Console.WriteLine("All Orders arrived!");

        }

        private static void Orders_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add) 
            {
                Console.WriteLine($"\n\nOrder {e.NewItems![0]} was receved");
            }
        }
    }
}
