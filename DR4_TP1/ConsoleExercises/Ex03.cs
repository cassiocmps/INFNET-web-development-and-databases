using System;

namespace ConsoleExercises;

internal class RectangleAreaCalculator
{
    public double Calculate(double base, double height)
    {
        Func<double, double, double> calculateArea = (b, h) => b * h;
        return calculateArea(base, height);
    }
}

internal class Ex03
{
    public static void Executar()
    {
        Console.WriteLine("--- Exercise 3: Area Calculation Using Func ---");

        double base;
        while (base == default)
        {
            Console.Write("Base of the rectangle: ");
            double.TryParse(Console.ReadLine(), out base);
            if (base == default)
            {
                Console.WriteLine("Invalid input.");
            }
        }

        double height;
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
        double area = calculator.Calculate(base, height);

        Console.WriteLine($"Area: {area}");
    }
}