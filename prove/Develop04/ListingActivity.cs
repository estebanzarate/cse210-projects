public class ListingActivity : Activity
{
    // Attributes
    List<string> _prompts = new List<string>() { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };
    public ListingActivity(string name, string desc) : base(name, desc) { }

    // Methods
    public void Run()
    {
        DisplayStartMsg();
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(2);
        Console.WriteLine();
        int rnd = new Random().Next(_prompts.Count);
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[rnd]} ---");
        Console.Write("You may begin in: ");
        PauseCounter(5);
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (item != "")
            {
                i++;
            }
        }
        Console.WriteLine($"You listed {i} items!");
        DisplayEndMsg();
        PauseSpinner(2);
        Console.Clear();
    }
}