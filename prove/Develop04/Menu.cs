public class Menu
{
    // Attributes
    private int _userOpt;
    private List<string> _menu = new List<string>() { "Start breathing activity", "Start reflecting", "Start listing activity", "Quit" };

    // Methods
    public void SetUserOpt(int userOpt)
    {
        _userOpt = userOpt;
    }
    public int GetUserOpt()
    {
        return _userOpt;
    }
    public void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        for (int i = 0; i < _menu.Count(); i++)
        {
            Console.WriteLine($"    [{i + 1}] {_menu[i]}");
        }
        Console.Write("Select a choice from the menu:\n\t-->> ");
        SetUserOpt(int.Parse(Console.ReadLine()));
    }
    public void ChooseOpt()
    {
        if (_userOpt == 1)
        {
            BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
            breathingActivity.Run();
        }
        else if (_userOpt == 2)
        {
            ReflectingActivity reflectionActivity = new ReflectingActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
            reflectionActivity.Run();
        }
        else if (_userOpt == 3)
        {
            ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
            listingActivity.Run();
        }
        else if (_userOpt == 4)
        {
            Console.Clear();
            return;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("[!] Select a choice from the menu");
            Console.WriteLine();
        }
    }
}