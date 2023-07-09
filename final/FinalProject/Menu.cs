using System.Net;
using System.Net.Mail;
public class Menu
{
    private List<Person> persons = new List<Person>();
    private List<string> menu = new List<string>() { "List persons", "Add person", "Edit person", "Remove person", "Send Messages", "Configure Account", "Exit program" };
    private Profile profile = new Profile("", "", "");
    public void RenderMenu()
    {
        Console.WriteLine("\n--- BIRTHDAY MESSAGE ---\n");
        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {menu[i]}");
        }
    }
    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter("data.txt"))
        {
            foreach (Person p in persons)
            {
                writer.WriteLine(p.FormatToSave());
            }
        }
    }
    public int LoadFile()
    {
        using (StreamReader reader = new StreamReader("profile.txt"))
        {
            string line = reader.ReadLine();
            string[] profileData = line.Split(",");
            string email = profileData[0];
            string smtpClient = profileData[1];
            string password = profileData[2];
            profile.SetEmail(email);
            profile.SetSmtpClient(smtpClient);
            profile.SetPassword(password);
        }
        string[] lines = System.IO.File.ReadAllLines("data.txt");
        foreach (string line in lines)
        {
            string[] data = line.Split(",");
            string name = data[0];
            string lastName = data[1];
            string email = data[2];
            string[] birthday = data[3].Split("/");
            int day = int.Parse(birthday[0]);
            int month = int.Parse(birthday[1]);
            Person person = new Person(name, lastName, email, new DateTime(1, month, day));
            persons.Add(person);
        }
        return lines.Length;
    }
    public void ListPersons()
    {
        persons.Clear();
        int personsCount = LoadFile();
        if (personsCount == 0)
        {
            Console.WriteLine("You have no person added");
            return;
        }
        SaveToFile();
        for (int i = 0; i < persons.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {persons[i].GetPersonData()}");
        }
    }
    public void AddPerson()
    {
        Console.Write("Add the name\n\t-->>  ");
        string name = Console.ReadLine();
        Console.Write("\nAdd the last name\n\t-->>  ");
        string lastName = Console.ReadLine();
        Console.Write("\nAdd the email\n\t-->>  ");
        string email = Console.ReadLine();
        Console.Write("\nAdd the birthday in number format\n\t-->>  ");
        int day = int.Parse(Console.ReadLine());
        Console.Write("\nAdd the month of the birthday in numerical format\n\t-->>  ");
        int month = int.Parse(Console.ReadLine());
        Person person = new Person(name, lastName, email, new DateTime(1, month, day));
        persons.Add(person);
        SaveToFile();
        Console.WriteLine("\n[+] Person added successfully");
    }
    public void EditPerson(int index)
    {
        List<string> personAttrs = new List<string>() { "Name", "Lastname", "Email", "Birthday Date" };
        Person personToEdit = persons[index - 1];
        Console.WriteLine($"\n{personToEdit.GetPersonData()}");
        Console.WriteLine();
        for (int i = 0; i < personAttrs.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {personAttrs[i]}");
        }
        Console.Write("\nWhat attribute do you want to edit?\n\t-->>  ");
        int opt = int.Parse(Console.ReadLine());
        switch (opt)
        {
            case 1:
                Console.WriteLine($"\nCurrent name: {personToEdit.GetName()}");
                Console.Write($"Enter the new name -> ");
                string newName = Console.ReadLine();
                personToEdit.SetName(newName);
                break;
            case 2:
                Console.WriteLine($"\nCurrent lastname: {personToEdit.GetLastName()}");
                Console.Write($"Enter the new lastname -> ");
                string newLastname = Console.ReadLine();
                personToEdit.SetLastName(newLastname);
                break;
            case 3:
                Console.WriteLine($"\nCurrent email: {personToEdit.GetEmail()}");
                Console.Write($"Enter the new email -> ");
                string newEmail = Console.ReadLine();
                personToEdit.SetEmail(newEmail);
                break;
            case 4:
                Console.WriteLine($"\nCurrent birthday date: {personToEdit.GetBirthDayDate()}");
                Console.Write($"Enter the new day -> ");
                int newDay = int.Parse(Console.ReadLine());
                Console.Write($"Enter the new month -> ");
                int newMonth = int.Parse(Console.ReadLine());
                personToEdit.SetBirthdayDate(newDay, newMonth);
                break;
        }
        SaveToFile();
        Console.WriteLine($"\n{personToEdit.GetPersonData()}");
        Console.WriteLine("\n[+] Attribute updated");
    }
    public void RemovePerson(int index)
    {
        persons.RemoveAt(index - 1);
        SaveToFile();
        Console.WriteLine();
        ListPersons();
        Console.WriteLine("\n[+] Person removed successfully");
    }
    public void SendMessages()
    {
        SmtpClient clientSmtp = new SmtpClient(profile.GetSmtpClient());
        clientSmtp.EnableSsl = true;
        clientSmtp.Credentials = new NetworkCredential(profile.GetEmail(), profile.GetPassword());
        DateTime today = DateTime.Now;
        List<Person> personsToSendMsg = persons.Where(person => person.GetBirth().Day == today.Day && person.GetBirth().Month == today.Month).ToList();
        foreach (Person person in personsToSendMsg)
        {
            MailMessage message = new MailMessage(profile.GetEmail(), person.GetEmail(), "Happy Birthday", $"Happy Birthday {person.GetName()}");
            clientSmtp.Send(message);
        }
        Console.WriteLine("\n[+] The messages were sent");
    }
    public void ConfigureAccount()
    {
        Console.WriteLine($"Email -->> {profile.GetEmail()}");
        Console.WriteLine($"SMTP client -->> {profile.GetSmtpClient()}");
        Console.WriteLine($"Password -->> {profile.GetPassword()}");
        Console.Write("\nAdd your email\n\t-->>  ");
        string email = Console.ReadLine();
        profile.SetEmail(email);

        Console.Write("Add your SMTP client\n\t-->>  ");
        string smtpClient = Console.ReadLine();
        profile.SetSmtpClient(smtpClient);

        Console.Write("Add your password\n\t-->>  ");
        string password = Console.ReadLine();
        profile.SetPassword(password);

        profile.SaveToFile();
    }
}