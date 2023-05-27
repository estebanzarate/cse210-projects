public class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity(string name, string desc) : base(name, desc) { }

    // Methods
    public void Run()
    {
        DisplayStartMsg();
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(2);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            DisplayMsg("Breathe in...");
            DisplayMsg("Now breathe out...");
            Console.WriteLine();
        }
        DisplayEndMsg();
        PauseSpinner(2);
        Console.Clear();
    }
    public void DisplayMsg(string msg)
    {
        Console.WriteLine();
        Console.Write($"{msg} ");
        PauseCounter(5);
    }
}