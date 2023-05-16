using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(222);
        Fraction fraction3 = new Fraction(333, 666);
        Console.WriteLine(fraction1.GetTop());
        Console.WriteLine(fraction1.GetBottom());
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine(fraction2.GetTop());
        Console.WriteLine(fraction2.GetBottom());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine(fraction3.GetTop());
        Console.WriteLine(fraction3.GetBottom());
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
    }
}