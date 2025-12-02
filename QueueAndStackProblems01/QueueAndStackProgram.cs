using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.ReadFromUser; 

namespace QueueAndStackProblems01
{
    internal class QueueAndStackProgram
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ReadInput.ReadChoice(1, 10, "Enter a number").ToString());
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
