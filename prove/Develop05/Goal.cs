public class Goal
{
    private string _goalName;
    private string _goalDescription;
    private int _goalPoints;
    private bool _isCompleted = false;
    public Goal(string goalName, string goalDescription, int goalPoints)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _goalPoints = goalPoints;
    }
    public string GetGoalName()
    {
        return _goalName;
    }
    public string GetGoalDescription()
    {
        return _goalDescription;
    }
    public int GetGoalPoints()
    {
        return _goalPoints;
    }
    public virtual int GetPointsEarned()
    {
        return GetGoalPoints();
    }
    public bool GetIsCompleted()
    {
        return _isCompleted;
    }
    public void SetIsCompleted()
    {
        _isCompleted = true;
    }
    public virtual string GetGoal()
    {
        return $"[{IsCompleted()}] {GetGoalName()} ({GetGoalDescription()})";
    }
    public virtual string GoalToSave()
    {
        return $"{GetType()}:{GetGoalName()},{GetGoalDescription()},{GetGoalPoints()}";
    }
    public virtual string IsCompleted()
    {
        if (_isCompleted)
        {
            return "X";
        }
        else
        {
            return " ";
        }
    }
    public virtual void CheckIsCompleted()
    {
        if (!GetIsCompleted())
        {
            _isCompleted = true;
        }
    }
}