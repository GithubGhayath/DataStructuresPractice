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
            // Problem 02
            ShoppinngProcess();


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


        // Manage a list of tasks dynamically allowing addition,removal,and status updates
    }
}
