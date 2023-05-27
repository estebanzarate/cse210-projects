public class ReflectingActivity : Activity
{
    // Attributes
    List<string> _prompts = new List<string>() { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
    List<string> _questions = new List<string>() { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };
    public ReflectingActivity(string name, string desc) : base(name, desc) { }

    // Methods
    public void Run()
    {
        DisplayStartMsg();
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(2);
        Console.WriteLine();
        int rnd = new Random().Next(_prompts.Count);
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {_prompts[rnd]} ---");
        Console.WriteLine();
        Console.Write("When you have something in mind, press enter to continue. ");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        PauseCounter(5);
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write($"> {_questions[i]} ");
            PauseSpinner(5);
            Console.WriteLine();
            i++;
        }
        DisplayEndMsg();
        PauseSpinner(2);
        Console.Clear();
    }
}