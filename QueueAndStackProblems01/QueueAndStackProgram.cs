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
            ImplementBrowserBackButton();
        }

        public static void ImplementBrowserBackButton()
        {
            // Problem: Use a stack to implement a browser's back button functionality.

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
