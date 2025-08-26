using System;

namespace ConsoleExercises;

internal class RectangleAreaCalculator
{
    public double Calculate(double b, double h)
    {
        Func<double, double, double> calculateArea = (b, h) => b * h;
        return calculateArea(b, h);
    }
}

internal class Ex03
{
    public static void Run()
    {
        Console.WriteLine("--- Exercise 3: Area Calculation Using Func ---");

        double b = default;
        while (b == default)
        {
            Console.Write("Base of the rectangle: ");
            double.TryParse(Console.ReadLine(), out b);
            if (b == default)
            {
                Console.WriteLine("Invalid input.");
            }
        }

        double height = default;
        while (height == default)
        {
            Console.Write("Height of the rectangle: ");
            double.TryParse(Console.ReadLine(), out height);
            if (height == default)
            {
                Console.WriteLine("Invalid input.");
            }
        }

        var calculator = new RectangleAreaCalculator();
        double area = calculator.Calculate(b, height);

        Console.WriteLine($"Area: {area}");
    }
}