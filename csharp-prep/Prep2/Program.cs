using System;

class Program
{
    static void Main(string[] args)
    {
        string letter;
        Console.Write("Grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        if (grade >= 90) letter = "A";
        else if (grade >= 80) letter = "B";
        else if (grade >= 70) letter = "C";
        else if (grade >= 60) letter = "D";
        else letter = "F";
        Console.WriteLine($"Grade: {letter}");
        if (grade >= 70) Console.WriteLine("Congratulations..!!");
        else Console.WriteLine("Try next time..!!");
    }
}