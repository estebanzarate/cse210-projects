using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;
        int total = 0;
        int avg = 0;
        int max = 0;

        while (number != 0)
        {
            numbers.Add(number);
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            total += number;
            if (number > max) max = number;
        }
        avg = total / (numbers.Count - 1);
        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Average: {avg}");
        Console.WriteLine($"Largest: {max}");
    }
}