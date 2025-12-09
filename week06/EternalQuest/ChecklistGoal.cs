public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus) : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        Bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            CurrentCount++;
            if (CurrentCount >= TargetCount)
            {
                IsComplete = true;
            }
        }
    }

    public override string GetStatus()
    {
        return $"[{(IsComplete ? "X" : " ")}] {Name} ({Description}) -- Completed {CurrentCount}/{TargetCount}";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{CurrentCount}|{TargetCount}|{Bonus}|{IsComplete}";
    }

    public static ChecklistGoal Deserialize(string data)
    {
        var parts = data.Split('|');
        var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
        goal.CurrentCount = int.Parse(parts[4]);
        goal.IsComplete = bool.Parse(parts[7]);
        return goal;
    }
}