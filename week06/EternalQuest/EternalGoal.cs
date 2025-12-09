public class EternalGoal : Goal
{
    public int TimesCompleted { get; set; }
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        TimesCompleted = 0;
    }

    public override void RecordEvent()
    {
        TimesCompleted++;
    }

    public override string GetStatus()
    {
        return $"[∞] {Name} ({Description}) -- Completed {TimesCompleted} times";
    }

    public override string Serialize()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}|{TimesCompleted}";
    }

    public static EternalGoal Deserialize(string data)
    {
        var parts = data.Split('|');
        var goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
        goal.TimesCompleted = int.Parse(parts[4]);
        return goal;
    }
}