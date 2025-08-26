using System;

namespace ConsoleExercises;

internal class DiscountCalculator
{
    public delegate decimal CalculateDiscount(decimal price);

    public decimal ApplyStandardDiscount(decimal price)
    {
        return price * 0.90m; // 10% discount
    }
}

internal class Ex01
{
    public static void Run()
    {
        Console.WriteLine("--- Exercise 1: Custom Delegate for Discounts ---");

        decimal originalPrice = default;
        while (originalPrice == default)
        {
            Console.Write("Price: ");
            decimal.TryParse(Console.ReadLine(), out originalPrice);
            if (originalPrice == default)
            {
                Console.WriteLine("Invalid input.");
            }
        }

        var calculator = new DiscountCalculator();
        DiscountCalculator.CalculateDiscount discountDelegate = calculator.ApplyStandardDiscount;
        decimal finalPrice = discountDelegate(originalPrice);
        Console.WriteLine($"Discounted price: {finalPrice:C}");
    }
}
