using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("Luke 3:9", "Then said he to the multitude that came forth to be baptized of him, O ageneration of vipers, who hath warned you to flee from the wrath to come? Bring forth therefore afruits bworthy of crepentance, and begin not to say within yourselves, dWe have eAbraham to our father: for I say unto you, That God is able of these stones to raise up children unto Abraham. And now also the aaxe is laid unto the root of the trees: every tree therefore which bringeth not forth good bfruit is hewn down, and cast into the fire.");

        Console.Clear();
        Console.WriteLine($"\n{scripture.GetRenderedText()}");
        Console.WriteLine("\nPress enter to hide words or type 'quit' to exit.");

        while (!scripture.IsCompletelyHidden())
        {
            string input = Console.ReadLine();
            if (input == "quit") break;
            scripture.HideWords();
            Console.Clear();
            Console.WriteLine($"\n{scripture.GetRenderedText()}");
            Console.WriteLine("\nPress enter to hide more words or type 'quit' to exit.");
        }

        Console.WriteLine("\nBYE!");
    }
}