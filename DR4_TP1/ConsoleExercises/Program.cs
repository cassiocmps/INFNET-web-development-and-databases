using System;

namespace ConsoleExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nSelect an exercise to run (1-7) or 0 to exit:");
                Console.WriteLine("1. Custom Delegate for Discounts");
                Console.WriteLine("2. Multilingual Actions with Action<string>");
                Console.WriteLine("3. Area Calculation Using Func");
                Console.WriteLine("4. Temperature Monitoring with Custom Event");
                Console.WriteLine("5. Download Completion Notification with Events");
                Console.WriteLine("6. Logging System with Multicast Delegate");
                Console.WriteLine("7. Robust Delegate Invocation");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Ex01.Run();
                        break;
                    case "2":
                        Ex02.Run();
                        break;
                    case "3":
                        Ex03.Run();
                        break;
                    case "4":
                        Ex04.Run();
                        break;
                    case "5":
                        Ex05.Run();
                        break;
                    case "6":
                        Ex06.Run();
                        break;
                    case "7":
                        Ex07.Run();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}