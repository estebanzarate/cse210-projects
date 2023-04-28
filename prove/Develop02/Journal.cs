using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddingAnEntry()
    {
        Console.WriteLine();
        PromptGenerator promptGenerator = new PromptGenerator();
        string prompt = promptGenerator.GeneratePrompt();
        Console.WriteLine(prompt);
        Console.Write("-->>  ");
        string userEntry = Console.ReadLine();
        Entry newEntry = new Entry();
        DateTime theCurrentTime = DateTime.Now;
        newEntry._date = theCurrentTime.ToShortDateString();
        newEntry._prompt = prompt;
        newEntry._entry = userEntry;
        _entries.Add(newEntry);
        Console.WriteLine("[+] Entry added successfully\n");
    }
    public void DisplayingAllTheEntries()
    {
        Console.WriteLine("\nEntries:");
        if (_entries.Count == 0) Console.WriteLine("[!] Your journal is empty, add an entry or load a file\n");
        else foreach (Entry entry in _entries) entry.Display();
    }
    public void LoadingFromAFile()
    {
        Console.WriteLine("\nWhat is the filename?");
        string fileName = Console.ReadLine();
        Console.WriteLine();

        string[] db = System.IO.File.ReadAllLines(fileName);
        _entries.Clear();
        foreach (string line in db)
        {
            string[] dbLine = line.Split("~~");

            Entry entry = new Entry();
            entry._date = dbLine[0];
            entry._prompt = dbLine[1];
            entry._entry = dbLine[2];
            _entries.Add(entry);
        }
        Console.WriteLine("[+] File loaded successfully\n");
    }
    public void SavingToAFile()
    {
        Console.WriteLine("\nWhat is the filename?");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries) outputFile.WriteLine($"{entry._date}~~{entry._prompt}~~{entry._entry}");
        }
        Console.WriteLine("[+] File saved successfully\n");
    }
}