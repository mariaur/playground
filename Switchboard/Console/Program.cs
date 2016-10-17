using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SwitchboardConsole
{
    using PhoneNumberLib;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Switchboard!");
            Console.WriteLine($"Please note, input length is unlimited, while phone number should include less than '{Consts.MAX_VALID_LENGTH}' digits");
            Console.WriteLine("====================================================================================");

            do
            {
                Console.WriteLine("Enter the first phone number to compare");
                var phoneA = Console.ReadLine();
                Console.WriteLine("enter the second number");
                var phoneB = Console.ReadLine();

                Console.WriteLine("Choose comparison method: l - using Linq, r - using Regex, s - using Serial string comparison");
                Console.WriteLine("In case other char than('l', 'r', 's') is entered comparison method will be default (Linq)");
                var compareMethod = Console.ReadLine();

                IEqualityComparer<string> comparer;
                switch (compareMethod)
                {
                    case "l":
                        comparer = new LinqCompare();
                        break;
                    case "r":
                        comparer = new RegexCompare();
                        break;
                    case "s":
                        comparer = new SerialCompare();
                        break;
                    default:
                        comparer = new LinqCompare();
                        break;
                }

                Stopwatch watch = new Stopwatch();
                watch.Start();

                var resultString = PhoneNumberComparer.AreEqual(phoneA, phoneB, comparer) ? "equal" : "not equal";
                Console.WriteLine($"Numbers are {resultString}, operation took: '{watch.Elapsed}'");
            }
            while (true);
        }
    }
}
