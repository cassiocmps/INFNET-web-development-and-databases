using System;

namespace ConsoleExercises;

public class TemperatureSensor
{
    public const double threshold = 100.0;
    public event Action<double> TemperatureExceeded;

    private double _temperature;

    public double Temperature
    {
        get => _temperature;
        set
        {
            _temperature = value;
            if (_temperature > threshold)
            {
                OnTemperatureExceeded(_temperature);
            }
        }
    }

    protected virtual void OnTemperatureExceeded(double temp)
    {
        TemperatureExceeded?.Invoke(temp);
    }
}

internal class Ex04
{
    public static void Run()
    {
        Console.WriteLine("--- Exercise 4: Temperature Monitoring with Custom Event ---");
        var sensor = new TemperatureSensor();
        sensor.TemperatureExceeded += ShowAlert;

        while (true)
        {
            Console.Write("Temperature reading (leave it blank to exit): ");
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                break;

            if (double.TryParse(input, out double temp))
                sensor.Temperature = temp;
            else
                Console.WriteLine("Invalid input.");
        }
    }

    private static void ShowAlert(double temp)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ALERT! Temperature has exceeded the limit {TemperatureSensor.threshold}: {temp}°C");
        Console.ResetColor();
    }
}
