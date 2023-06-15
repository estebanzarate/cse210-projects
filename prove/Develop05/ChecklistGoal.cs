public class ChecklistGoal : Goal
{
    private int _bonus;
    private int _times;
    private int _currentTimes = 0;
    public ChecklistGoal(string goalName, string goalDescription, int goalPoints, int times, int bonus) : base(goalName, goalDescription, goalPoints)
    {
        _times = times;
        _bonus = bonus;
    }
    public ChecklistGoal(string goalName, string goalDescription, int goalPoints, int bonus, int times, int currentTimes) : base(goalName, goalDescription, goalPoints)
    {
        _bonus = bonus;
        _times = times;
        _currentTimes = currentTimes;
    }

    public override int GetPointsEarned()
    {
        if (GetIsCompleted())
        {
            return GetGoalPoints() + GetGoalBonus();
        }
        return GetGoalPoints();
    }
    public int GetGoalBonus()
    {
        return _bonus;
    }
    public int GetGoalTimes()
    {
        return _times;
    }
    public int GetGoalCurrentTimes()
    {
        return _currentTimes;
    }
    public void SetGoalCurrentTimes()
    {
        if (GetGoalCurrentTimes() < GetGoalTimes())
        {
            _currentTimes++;
            if (GetGoalCurrentTimes() == GetGoalTimes())
            {
                SetIsCompleted();
                return;
            }
        }
    }
    public override string GetGoal()
    {
        return $"[{IsCompleted()}] {GetGoalName()} ({GetGoalDescription()}) -- Currently completed: {GetGoalCurrentTimes()}/{GetGoalTimes()}";
    }
    public override string GoalToSave()
    {
        return $"{GetType()}:{GetGoalName()},{GetGoalDescription()},{GetGoalPoints()},{GetGoalBonus()},{GetGoalTimes()},{GetGoalCurrentTimes()}";
    }
    public override void CheckIsCompleted()
    {
        if (!GetIsCompleted())
        {
            SetGoalCurrentTimes();
        }
    }
}