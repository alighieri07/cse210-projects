public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent()
    {
        IsComplete = true;
    }

    public override string GetStatus()
    {
        return $"[{(IsComplete ? "X" : " ")}] {Name} ({Description})";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{IsComplete}";
    }

    public static SimpleGoal Deserialize(string data)
    {
        var parts = data.Split('|');
        var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
        goal.IsComplete = bool.Parse(parts[4]);
        return goal;
    }
}