using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        while (magicNumber != guess)
        {
            if (guess < magicNumber) Console.WriteLine("Higher");
            else Console.WriteLine("Lower");
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("You guessed it!");
    }
}