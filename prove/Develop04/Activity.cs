public class Activity
{
    // Attributes
    private string _name;
    private string _desc;
    private int _duration;
    public Activity(string name, string desc)
    {
        _name = name;
        _desc = desc;
    }

    // Methods
    public void DisplayStartMsg()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} activity.");
        Console.WriteLine();
        Console.WriteLine(_desc);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session?\n\t-->> ");
        int duration = int.Parse(Console.ReadLine());
        SetDuration(duration);
    }
    public void SetDuration(int duration)
    {
        _duration = duration;
    }
    public int GetDuration()
    {
        return _duration;
    }
    public void DisplayEndMsg()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        PauseSpinner(3);
        Console.WriteLine($"You have completed another {GetDuration()} seconds of the {_name} activity.");
        PauseSpinner(3);
    }
    public void PauseSpinner(int seconds)
    {
        List<string> animation = new List<string>() { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animation[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= animation.Count)
            {
                i = 0;
            }
        }
    }
    public void PauseCounter(int count)
    {
        for (int i = count; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}