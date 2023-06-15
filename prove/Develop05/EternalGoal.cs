public class EternalGoal : Goal
{
    public EternalGoal(string goalName, string goalDescription, int goalPoints) : base(goalName, goalDescription, goalPoints) { }
    public override string GoalToSave()
    {
        return $"{GetType()}:{GetGoalName()},{GetGoalDescription()},{GetGoalPoints()}";
    }
    public override string IsCompleted()
    {
        return " ";
    }
    public override void CheckIsCompleted()
    {
        return;
    }
}