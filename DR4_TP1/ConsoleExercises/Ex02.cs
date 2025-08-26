using System;

namespace ConsoleExercises;

internal class MultilingualWelcome
{
    public void WelcomeInPortuguese(string name)
    {
        Console.WriteLine($"Olá, {name}! Bem-vindo.");
    }

    public void WelcomeInEnglish(string name)
    {
        Console.WriteLine($"Hello, {name}! Welcome.");
    }

    public void WelcomeInSpanish(string name)
    {
        Console.WriteLine($"Hola, {name}! Bienvenido.");
    }
}

internal class Ex02
{
    public static void Run()
    {
        var welcome = new MultilingualWelcome();
        Console.WriteLine("--- Exercise 2: Multilingual Actions with Action<string> ---");
        Console.WriteLine("Choose a language (1-3):");
        Console.WriteLine("1. Portuguese");
        Console.WriteLine("2. English");
        Console.WriteLine("3. Spanish");

        string choice = default;
        while (string.IsNullOrEmpty(choice))
        {
            var input = Console.ReadLine();
            
            if (input == "1" || input == "2" || input == "3")
                choice = input;
            else
                Console.WriteLine("Invalid selection.");
        }

        Action<string> welcomeAction = null;

        switch (choice)
        {
            case "1":
                welcomeAction = welcome.WelcomeInPortuguese;
                break;
            case "2":
                welcomeAction = welcome.WelcomeInEnglish;
                break;
            case "3":
                welcomeAction = welcome.WelcomeInSpanish;
                break;
        }

        welcomeAction?.Invoke("User");
    }
}
