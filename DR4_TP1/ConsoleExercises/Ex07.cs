using System;
using System.IO;

namespace ConsoleExercises;

public class Ex07
{
    public static void Run()
    {
        Console.WriteLine("--- Exercise 7: Robust Delegate Invocation ---");
        var logger = new Logger();
        Action<string> logAction = null; // Start with a null delegate

        Console.WriteLine("\n--- Testing with a null delegate ---");
        Console.WriteLine("Invoking the delegate with ?.Invoke(). No methods are attached.");
        logAction?.Invoke("This will be a ignored message.");
        Console.WriteLine("No exception was thrown, as expected.");

        Console.WriteLine("\n--- Testing with a populated delegate ---");
        logAction += logger.LogToConsole;
        logAction += logger.LogToFile;
        logAction += logger.LogToDatabase;

        Console.Write("Message to log: ");
        var message = Console.ReadLine();
        if (!string.IsNullOrEmpty(message))
        {
            logAction?.Invoke(message);
        }
    }
}