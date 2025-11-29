using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAndStackProblems01
{
    internal class QueueAndStackProgram
    {
        public static void Main(string[] args)
        {

        }

        public static void ImplementBrowserBackButton()
        {
            // Problem: Use a stack to implement a browser's back button functionality.

            Stack<Page> Pages = new Stack<Page>();
            int Choies = 0;

            Console.WriteLine("Choose the page number:");
            Console.WriteLine("[1]. the Science page");
            Console.WriteLine("[2]. the Games page");
            Console.WriteLine("[3]. the Animals page");

        }
        public static int ReadChoice(int from , int to,string message)
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

            } while (Result=(Choice < from || Choice > to));

            return Choice;
        }
        public static Stack<Page> InspectChoice(Stack<Page>Pages,int choice,string message)
        {

           
            Stack<Page> pages = Pages;

            switch (choice)
            {
                case 1:
                    {
                        pages.Push(new Page("Animals", "This page talks about different animals", 1));
                        break;
                    }
                case 2:
                    {
                        pages.Push(new Page("Games", "This page includes information about various games", 2));
                        break;
                    }
                case 3:
                    {
                        pages.Push(new Page("Science", "This page explains basic science ideas", 3));
                        break;
                    }
            }

            return pages;

        }
    }

    public class Page
    {
        private int _PageNumber { get; }
        private string _Title { get; }
        private string _body { get; }

        public Page(string title, string body, int PageNumber) 
        {
            this._PageNumber = PageNumber;
            this._Title = title;
            this._body = body;
        }
        public override string ToString()
        {
            return $"The page order: {this._PageNumber}\nPage Title: {this._Title}\n\n{_body}";
        }
      
    }
}
