using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Console.WriteLine("\nWelcome to the Journal Program!\n");
        string opt = "0";
        while (opt != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\n");
            Console.Write("What would you like to do? ");
            opt = Console.ReadLine();
            if (opt == "1") journal.AddingAnEntry();
            else if (opt == "2") journal.DisplayingAllTheEntries();
            else if (opt == "3") journal.LoadingFromAFile();
            else if (opt == "4") journal.SavingToAFile();
            else if (opt == "5")
            {
                Console.WriteLine("'\nBYE!!");
                return;
            }
        }
    }
}