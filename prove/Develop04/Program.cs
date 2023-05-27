using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Menu menu = new Menu();
        while (menu.GetUserOpt() != 4)
        {
            menu.DisplayMenu();
            menu.ChooseOpt();
        }
    }
}