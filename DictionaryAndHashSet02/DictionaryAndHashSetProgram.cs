using Shared.Print;
using Shared.ReadFromUser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DictionaryAndHashSet02
{
    internal class DictionaryAndHashSetProgram
    {
        public static void Main(string[] args)
        {
            // problem 15
            CommonCharactersInWords();

            // problem 14
            // FindMissingNumbersInAnArray();

            // problem 13
            // WordsTypedUseingQWERTY();

            // problem 12
            // UniqueElements();

            // problem 11
            // DuplicateElementInArray();


            // problem 10
            // MajorityElementInArray();


            // problem 09
            // CountTheFrequencyCharacterInString();

            // problem 08
            // MatchingSkills();


            // problem 07
            // CheckDuplicateData();


            // problem 06
            // PerformTracking();


            // problem 05
            // Phonebook();

            // problem 04
            // CountTheFrequencyOfWords();

            // problem 03
            // TranslateSomeWorld();

            // problem 02
            // BookInfo();

            // problem 01
            // StudentGrades();
        }

        // problem: Store the grades of students using their names as keys and retrieve Bob's info using student name.
        public static void StudentGrades()
        {
            Dictionary<string, int> _StudentGrades = new Dictionary<string, int>();

            _StudentGrades.Add("Maya", 25);
            _StudentGrades.Add("Maher", 45);
            _StudentGrades.Add("Sham", 54);
            _StudentGrades.Add("Yara", 76);
            _StudentGrades.Add("Ghayath", 56);
            _StudentGrades.Add("Issra", 45);
            _StudentGrades.Add("Bob", 88);

            if (_StudentGrades.TryGetValue("Bob", out int Grades))
            {
                Console.WriteLine($"Bob: {Grades}");
            }
            else
            {
                Console.WriteLine("Bob is not in list");
            }

            if (_StudentGrades.TryGetValue("Salah", out int G))
            {
                Console.WriteLine($"Salah: {G}");
            }
            else
            {
                Console.WriteLine("Salah is not in list");
            }
        }

        // problem: Store information about books (Title,Author) using their ISBN as the key.
        public static void BookInfo()
        {
            Dictionary<string, (string, string)> BooksInfo = new Dictionary<string, (string, string)>();
            BooksInfo.Add("6516146465165", ("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie"));
            BooksInfo.Add("3453425436654", ("Introduction to Algorithms", "Thomas H. Cormen"));
            BooksInfo.Add("2143546675745", ("First Design Patterns", "F. Scott"));

            foreach (var kvp in BooksInfo) 
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value.Item1} | {kvp.Value.Item2}");
            }
        }

        // problem: Create a dictionary for translating words from one language to another.
        public static void TranslateSomeWorld()
        {
            Dictionary<string, string> Words = new Dictionary<string, string>();
            Words.Add("Hello", "Hola");
            Words.Add("Goodbye", "Adios");

            foreach (KeyValuePair<string,string> kvp in Words) 
            {
                Console.WriteLine($"{kvp.Key} in Spanish: {kvp.Value}");
            }
        }

        // problem: Count the frequency of each word in a given text.
        private static bool _IsWordInDictionary(string Word, Dictionary<string, int> Words)
        {
            foreach (KeyValuePair<string, int> kvp in Words)
            {
                if (kvp.Key == Word)
                    return true;
            }
            return false;
        }
        public static void CountTheFrequencyOfWords()
        {
            Dictionary<string, int> WordsWithCount = new Dictionary<string, int>();

            string[] TextFromUser = ReadInput.ReadText("Enter a text: ").Split(" ");

         

            foreach (string word in TextFromUser) 
            {
                if (!_IsWordInDictionary(word, WordsWithCount))
                    WordsWithCount.Add(word, 1);
                else
                {
                    int NewCount = ++WordsWithCount[word];
                    WordsWithCount.Remove(word);
                    WordsWithCount.Add(word, NewCount);
                }
            }

            WordsWithCount.Print("");

        }
        // problem: Implement a phonebook where you can store and retrieve contact numbers using names.
        public static void Phonebook()
        {
            Dictionary<string, string> Phonebook = ReadInput.ReadInfoAsKayValueFormat("Enter a record as [Name/PhoneNumber] format");

            Phonebook.Print("The Contacts are:");
        }
        // problem: Track unique visitors to a website using Ip addresses
        public static void TrackingVisitors(List<string>Ips)
        {
            Dictionary<string, int> VisitorTracker = new Dictionary<string, int>();

            foreach (string Ip in Ips)
            {
                if (VisitorTracker.TryGetValue(Ip, out int VisitCount))
                {
                    VisitorTracker.Remove(Ip);
                    VisitorTracker.Add(Ip, ++VisitCount);
                }
                else
                {
                    VisitorTracker.Add(Ip, 1);
                }
            }

            VisitorTracker.Print("\nThe visitor tracker list:");
        }
        public static void PerformTracking()
        {
            List<string> Ips = new List<string> 
            {
                "172.15.0.1",
                "172.15.0.1",
                "172.15.0.1",
                "174.15.0.1",
                "174.15.0.1",
                "175.15.0.1",
                "175.15.0.1",
                "171.15.0.1",
                "171.15.0.1",
                "171.15.0.1",
                "171.15.0.1",
                "171.15.0.1",
                "174.15.0.1",
                "176.15.0.1",
                "176.15.0.1",
                "177.15.0.1",
                "178.15.0.1",
                "179.15.0.1",
                "179.15.0.1",
               
            };

            TrackingVisitors(Ips);
        }
        // problem: Detect duplicates as data added 
        public static void CheckDuplicateData()
        {
            string[] Text = ReadInput.ReadText("Enter a text: ").Split(" ");
            HashSet<string> Data = new HashSet<string>(Text);
            Data.Print("The data from text: ");
        }

        // problem: Match a Candidate skills to a job required skills
        public static void MatchingSkills()
        {
            HashSet<string> Candidate = new HashSet<string>();
            Candidate.Add("C#");
            Candidate.Add("SQL");
            Candidate.Add("JavaScript");

            string[] Skills = ReadInput.ReadText("Enter your skills at format: [skill1,skill2..etc]").Split(',');
            HashSet<string> JobRequirements = new HashSet<string>(Skills);

            HashSet<string> Matches = new HashSet<string>(JobRequirements.Intersect(Candidate));
            Matches.Print("Matching skills: ");
        }
        // problem: Count the frequency of each character in a string.
        private static bool _IsCharInDictionary(char _letter, Dictionary<char, int> Count)
        {
            foreach (KeyValuePair<char,int> kvp in Count)
            {
                if (kvp.Key == _letter) return true;
            }
            return false;
        }
        public static void CountTheFrequencyCharacterInString()
        {
            Dictionary<char, int> _Count = new Dictionary<char, int>();
            string Text = ReadInput.ReadText("Enter a text: ");
            for (int i = 0; i < Text.Length; i++)
            {
                if (_IsCharInDictionary(Text[i], _Count))
                {
                    int OldValue = _Count[Text[i]];
                    _Count.Remove(Text[i]);
                    _Count.Add(Text[i], ++OldValue);
                }
                else
                    _Count.Add(Text[i], 1);
            }
            _Count.Print("OutPut:");
        }

        // problem: Find the length of the longest consecutuve sequence in an array






        // problem: Find the majority element in an array (element that appearing more than n/2 times)
        public static bool _IsNumberInDictionary(int number, Dictionary<int, int> NumberWithFrequency) 
        {
            foreach (KeyValuePair<int, int> kvp in NumberWithFrequency)
            {
                if(kvp.Key == number)
                    return true;
            }
            return false;
        }
        public static void MajorityElementInArray()
        {
            int[] arr = new int[] { 3, 2, 3, 2, 1 };
            Dictionary<int, int> NumberWithFrequency = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (_IsNumberInDictionary(arr[i], NumberWithFrequency))
                {
                    int OldFrequency = NumberWithFrequency[arr[i]];
                    NumberWithFrequency.Remove(arr[i]);
                    NumberWithFrequency.Add(arr[i], ++OldFrequency);
                }
                else
                {
                    NumberWithFrequency.Add(arr[i], 1);
                }
            }

            var ToPrint = NumberWithFrequency.Where(kvp => kvp.Value % 2 == 0).Select(kvp => kvp.Key).ToList();

            Console.WriteLine("The majority element in list [ 3, 2, 3, 2, 1 ]");
            ToPrint.ForEach(i=>Console.WriteLine(i));
        }

        // problem: Identify duplicate elements in an array
        public static void DuplicateElementInArray()
        {
            int[] arr = new int[] { 1, 3, 4, 1, 6, 7, 2, 5, 2 };
            Dictionary<int, int> _NumberwithFrequency = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (_IsNumberInDictionary(arr[i], _NumberwithFrequency))
                {
                    int OldFrequency = _NumberwithFrequency[arr[i]];
                    _NumberwithFrequency.Remove(arr[i]);
                    _NumberwithFrequency.Add(arr[i], ++OldFrequency);
                }
                else
                    _NumberwithFrequency.Add(arr[i], 1);
            }

            var DuplicateElements = _NumberwithFrequency.Where(kvp => kvp.Value % 2 == 0).Select(kvp => kvp.Key).ToList();
            Console.WriteLine("The duplicate elements in list [ 1, 3, 4, 1, 6, 7, 2, 5, 2 ] are:");
            Console.WriteLine($"{string.Join(" , ", DuplicateElements)}");
        }

        // problem: Return all unique elements from an array
        public static void UniqueElements()
        {
            int[] arr = new int[] { 1, 1, 2, 3, 2, 3, 4, 4, 5, 1, 2 };

            HashSet<int> UniquElement = new HashSet<int>(arr);

            Console.WriteLine("The unique elements at list [ 1, 1, 2, 3, 2, 3, 4, 4, 5, 1, 2 ] are: ");
            Console.WriteLine(string.Join(" , ", UniquElement));
        }

        // Problem: Return all words that can be typed using one row of a QWERTY keyboard.
        private static bool _IsLetterAtQWERTY_Row(char letter)
        {
            char[] FirstRow = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };

            for (int i = 0; i < FirstRow.Length; i++)
            {
                if(FirstRow[i] == letter) return true;
            }
            return false;
        }
        private static bool _IsLetterAtASDFGHJKL_Row(char letter)
        {
            char[] FirstRow = { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };

            for (int i = 0; i < FirstRow.Length; i++)
            {
                if (FirstRow[i] == letter) return true;
            }
            return false;
        }
        private static bool _IsLetterAtZXCVBNM_Row(char letter)
        {
            char[] FirstRow = { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };

            for (int i = 0; i < FirstRow.Length; i++)
            {
                if (FirstRow[i] == letter) return true;
            }
            return false;
        }

        private static bool _IsWordAtQWERTY_Row(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (_IsLetterAtQWERTY_Row(char.ToLower(word[i])))
                    continue;
                else
                    return false;
            }
            return true;
        }

        private static bool _IsWordASDFGHJKL_Row(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (_IsLetterAtASDFGHJKL_Row(char.ToLower(word[i])))
                    continue;
                else
                    return false;
            }
            return true;
        }

        private static bool _IsWordAtZXCVBNM_Row(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (_IsLetterAtZXCVBNM_Row(char.ToLower(word[i])))
                    continue;
                else
                    return false;
            }
            return true;
        }
        public static void WordsTypedUseingQWERTY()
        {
            string[] Words = ["Hello", "Alaska", "Dad", "Peace"];
            Dictionary<string, string> WordWithRowName = new Dictionary<string, string>();

            for (int i = 0; i < Words.Length; i++)
            {
                if (_IsWordAtQWERTY_Row(Words[i]))
                {
                    WordWithRowName.Add(Words[i], "QWERTYUIOP_ First Row");
                    continue;
                }
                if (_IsWordASDFGHJKL_Row(Words[i]))
                {
                    WordWithRowName.Add(Words[i], "ASDFGHJKL_ Second Row");
                    continue;
                }
                if (_IsWordAtZXCVBNM_Row(Words[i]))
                {
                    WordWithRowName.Add(Words[i], "ZXCVBNM_ Third Row"); 
                    continue;
                }
                else
                    WordWithRowName.Add(Words[i], "Mix letter");
            }

            WordWithRowName.Print("\nThe world orderd by keyboard rows: ");

        }

        // problem: Find the missing number in an array of size n, containing numbers from 0 to n.
        public static void FindMissingNumbersInAnArray()
        {
            int[] arr = new int[] { 3, 0, 1 ,2,5,8,10};
            List<int> MissingNumbers = new List<int>();
            var SortedElements = arr.Order().ToList();
            int Number = -1;


            for (int i = 0; i < SortedElements.Count; i++) 
            {
                Number++;

                if (SortedElements[i] == Number)
                    continue;
                else
                {
                    MissingNumbers.Add(Number);
                    i--;
                }
            }



          
            

            Console.WriteLine($"The missing number at array: [{string.Join(" , ", SortedElements)}]");
            MissingNumbers.ForEach(i => Console.Write($" {i}"));
        }

        // problem: Find common characters in strings, find all common characters between multiple string ["bella" , "label" , "roller"] ==> ["e" , "l"]  (reapeted over 3 times)
        private static bool _IsLetterInDictionary(char letter, Dictionary<char, int> LetterWithCount)
        {
            foreach (KeyValuePair<char, int> kvp in LetterWithCount)
            {
                if (letter == kvp.Key)
                    return true;
            }
            return false;
        }
        public static void CommonCharactersInWords()
        {
            string[] Words = new string[] { "bella", "label", "roller" };
            Dictionary<char, int> LetterWithCount = new Dictionary<char, int>();

            foreach (string word in Words) 
            {
                for (int i = 0; i < word.Length; i++) 
                {
                    if (_IsLetterInDictionary(word[i], LetterWithCount))
                    {
                        int OldFrequency = LetterWithCount[word[i]];
                        LetterWithCount.Remove(word[i]);
                        LetterWithCount.Add(word[i], ++OldFrequency);
                    }
                    else
                        LetterWithCount.Add(word[i], 1);
                }
            }

            var ToPrint = LetterWithCount.Where(kvp => kvp.Value >= 3).Select(kvp => kvp.Key).ToList();
            Console.WriteLine("The common characters in words: [\"bella\" , \"label\" , \"roller\"] are:");
            Console.WriteLine(string.Join(" , ", ToPrint));

        }
        

        // problem: Find all elements in the first array that are not in the second array (num1) = [1 , 2 , 3 , 4] ==> (num2) = [3 , 4 , 5 , 6]  ===> [1 , 2]

        // problem: find all numbers missing form the range 1 t0 n in an array [ 4 , 3 , 2 , 7 , 8 , 2 , 3 , 1 ] ==> [ 5 , 6 ]

    }
}
