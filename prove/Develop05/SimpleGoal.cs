public class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, string goalDescription, int goalPoints) : base(goalName, goalDescription, goalPoints) { }
    public SimpleGoal(string goalName, string goalDescription, int goalPoints, bool isCompleted) : base(goalName, goalDescription, goalPoints) { }
    public override string GoalToSave()
    {
        return $"{GetType()}:{GetGoalName()},{GetGoalDescription()},{GetGoalPoints()},{GetIsCompleted()}";
    }
}