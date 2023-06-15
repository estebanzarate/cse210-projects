using System.IO;

public class Menu
{
    private List<string> _menu = new List<string>() { "Create New Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit" };
    private List<string> _types = new List<string>() { "Simple Goal", "Eternal Goal", "Checklist Goal" };
    private List<Goal> _goals = new List<Goal>();
    private int _totalPoints = 0;

    public void RenderMenu()
    {

        int userOptMenu = -1;
        while (userOptMenu != 6)
        {
            Console.WriteLine($"\nYou have {GetTotalPoints()} points.\n");
            Console.WriteLine("Menu Options:");
            for (int i = 0; i < _menu.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {_menu[i]}");
            }
            Console.Write($"Select a choice from the menu:\n\t-->>  ");
            userOptMenu = int.Parse(Console.ReadLine());
            switch (userOptMenu)
            {
                case 1:
                    GoalTypes();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
            }
        }
    }
    public int GetTotalPoints()
    {
        return _totalPoints;
    }
    public void SetTotalPoints(int points)
    {
        _totalPoints += points;
    }
    public void GoalTypes()
    {
        Console.WriteLine("\nThe types of Goals are:");
        for (int i = 0; i < _types.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_types[i]}");
        }
        Console.Write($"Which type of goal would you like to create?\n\t-->>  ");
        int userOptType = int.Parse(Console.ReadLine());

        Console.Write($"What is the name of your goal?\n\t-->>  ");
        string goalName = Console.ReadLine();

        Console.Write($"What is a short description of it?\n\t-->>  ");
        string goalDescription = Console.ReadLine();

        Console.Write($"What is the amount of points associated with this goal?\n\t-->>  ");
        int goalPoints = int.Parse(Console.ReadLine());

        switch (userOptType)
        {
            case 1:
                Goal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints);
                _goals.Add(simpleGoal);
                break;
            case 2:
                Goal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                _goals.Add(eternalGoal);
                break;
            case 3:
                Console.Write($"How many times does this goal need to be accomplished for a bonus?\n\t-->>  ");
                int times = int.Parse(Console.ReadLine());

                Console.Write($"What is the bonus for accomplishing it that many times?\n\t-->>  ");
                int bonus = int.Parse(Console.ReadLine());

                Goal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, times, bonus);
                _goals.Add(checklistGoal);
                break;
        }
    }
    public void ListGoals()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine($"[!] You don\'t have any goals yet.");
        }
        else
        {
            int index = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{index}. {goal.GetGoal()}");
                index++;
            }
        }
    }
    public void SaveGoals()
    {
        Console.Write("\nWhat is the filename for the goal file?\n\t-->>  ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(GetTotalPoints());
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GoalToSave());
            }
        }
    }
    public void LoadGoals()
    {
        Console.Write("\nWhat is the filename for the goal file?\n\t-->>  ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);

        _totalPoints = int.Parse(lines[0]);

        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split(":");

            string type = parts[0];
            string[] details = parts[1].Split(",");

            string goalName = details[0];
            string goalDescription = details[1];
            int goalPoints = int.Parse(details[2]);
            switch (type)
            {
                case "SimpleGoal":
                    Goal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints, Boolean.Parse(details[3]));
                    _goals.Add(simpleGoal);
                    break;
                case "EternalGoal":
                    Goal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                    _goals.Add(eternalGoal);
                    break;
                case "ChecklistGoal":
                    Goal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5]));
                    _goals.Add(checklistGoal);
                    break;
            }
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine($"[!] You don\'t have any goals yet.");
        }
        else
        {
            int index = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{index}. {goal.GetGoalName()}");
                index++;
            }
            Console.Write("Which goal did you accomplish?\n\t-->>  ");
            int usrOpt = int.Parse(Console.ReadLine());
            Goal goalSelected = _goals[usrOpt - 1];
            int goalPoints = goalSelected.GetPointsEarned();
            goalSelected.CheckIsCompleted();
            if (goalSelected.GetIsCompleted())
            {
                Console.WriteLine("[!] Task already completed");
                return;
            }
            SetTotalPoints(goalPoints);
            Console.WriteLine($"Congratulations! You have earned {goalPoints} points!");
            Console.WriteLine($"You now have {GetTotalPoints()} points.");
        }
    }
}