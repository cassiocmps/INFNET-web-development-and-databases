using System;
using System.IO;

namespace ConsoleExercises;

public class Logger
{
    public void LogToConsole(string message)
    {
        Console.WriteLine($"CONSOLE LOG: {message}");
    }

    public void LogToFile(string message)
    {
        File.AppendAllText("log.txt", $"FILE LOG: {message}\n");
        Console.WriteLine("(Logged to file)");
    }

    public void LogToDatabase(string message)
    {
        // Simulate logging to a database
        Console.WriteLine($"DATABASE LOG: {message}");
    }
}

public class Ex06
{
    public static void Run()
    {
        Console.WriteLine("--- Exercise 6: Logging System with Multicast Delegate ---");
        var logger = new Logger();
        Action<string> logAction = logger.LogToConsole;
        logAction += logger.LogToFile;
        logAction += logger.LogToDatabase;

        Console.Write("Message to log: ");
        var message = Console.ReadLine();

        if (!string.IsNullOrEmpty(message))
        {
            logAction(message);
        }
    }
}