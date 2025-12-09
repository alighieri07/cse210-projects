using System;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();
    public static Goal Deserialize(string data)
    {
        var parts = data.Split('|');
        switch (parts[0])
        {
            case "SimpleGoal":
                return SimpleGoal.Deserialize(data);
            case "EternalGoal":
                return EternalGoal.Deserialize(data);
            case "ChecklistGoal":
                return ChecklistGoal.Deserialize(data);
            default:
                throw new Exception("Unknown goal type");
        }
    }
}