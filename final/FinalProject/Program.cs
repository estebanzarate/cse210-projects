class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.LoadFile();
        int opt = -1;
        while (opt != 7)
        {
            menu.RenderMenu();
            Console.Write("\nChoose an option from the menu:\n\t-->>  ");
            opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n* LIST OF PERSONS *\n");
                    menu.ListPersons();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n* ADD PERSON *\n");
                    menu.AddPerson();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("\n* EDIT PERSON *\n");
                    menu.ListPersons();
                    Console.Write("\nEnter the number of the person to edit\n\t-->>  ");
                    int indexEdit = int.Parse(Console.ReadLine());
                    menu.EditPerson(indexEdit);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("\n* REMOVE PERSON *\n");
                    menu.ListPersons();
                    Console.Write("\nEnter the number of the person to remove\n\t-->>  ");
                    int indexRemove = int.Parse(Console.ReadLine());
                    menu.RemovePerson(indexRemove);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("\n* SEND MESSAGES *\n");
                    menu.SendMessages();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("\n* CONFIGURE YOUR ACCOUNT *\n");
                    menu.ConfigureAccount();
                    break;
            }
        }
        Console.Clear();
    }
}