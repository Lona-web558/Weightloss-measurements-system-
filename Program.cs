using System;
using System.Collections.Generic;
using System.Linq;

class Measurement
{
    public DateTime Date { get; set; }
    public double Waist { get; set; }
    public double Hips { get; set; }
    public double Thighs { get; set; }
}

class Program
{
    static List<Measurement> measurements = new List<Measurement>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nWeight Loss Tracking System");
            Console.WriteLine("1. Add new measurement");
            Console.WriteLine("2. View progress");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddMeasurement();
                    break;
                case "2":
                    ViewProgress();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddMeasurement()
    {
        Measurement measurement = new Measurement
        {
            Date = DateTime.Now
        };

        Console.Write("Enter waist measurement (cm): ");
        measurement.Waist = double.Parse(Console.ReadLine());

        Console.Write("Enter hips measurement (cm): ");
        measurement.Hips = double.Parse(Console.ReadLine());

        Console.Write("Enter thighs measurement (cm): ");
        measurement.Thighs = double.Parse(Console.ReadLine());

        measurements.Add(measurement);
        Console.WriteLine("Measurement added successfully!");
    }

    static void ViewProgress()
    {
        if (measurements.Count == 0)
        {
            Console.WriteLine("No measurements recorded yet.");
            return;
        }

        Console.WriteLine("Progress Report:");
        Console.WriteLine("Date\t\tWaist\t\tHips\t\tThighs");

        foreach (var measurement in measurements)
        {
            Console.WriteLine($"{measurement.Date:yyyy-MM-dd}\t{measurement.Waist:F1}\t{measurement.Hips:F1}\t{measurement.Thighs:F1}");
        }

        if (measurements.Count > 1)
        {
            var first = measurements.First();
            var last = measurements.Last();
            var daysPassed = (last.Date - first.Date).Days;

            Console.WriteLine("\nOverall Progress:");
            Console.WriteLine($"Days passed: {daysPassed}");
            Console.WriteLine($"Waist change: {last.Waist - first.Waist:F1} cm");
            Console.WriteLine($"Hips change: {last.Hips - first.Hips:F1} cm");
            Console.WriteLine($"Thighs change: {last.Thighs - first.Thighs:F1} cm");
        }
    }
}

