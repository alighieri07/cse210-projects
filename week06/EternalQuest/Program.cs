using System;

using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Type: ");
        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());
        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }
        ListGoals();
        Console.Write("Select goal number: ");
        int idx = int.Parse(Console.ReadLine()) - 1;
        if (idx < 0 || idx >= goals.Count)
        {
            Console.WriteLine("Invalid goal.");
            return;
        }
        var goal = goals[idx];
        int before = score;
        if (goal is SimpleGoal && !goal.IsComplete)
        {
            goal.RecordEvent();
            score += goal.Points;
        }
        else if (goal is EternalGoal)
        {
            goal.RecordEvent();
            score += goal.Points;
        }
        else if (goal is ChecklistGoal cg)
        {
            if (!cg.IsComplete)
            {
                cg.RecordEvent();
                score += cg.Points;
                if (cg.IsComplete)
                {
                    score += cg.Bonus;
                    Console.WriteLine($"Bonus! +{cg.Bonus} points");
                }
            }
            else
            {
                Console.WriteLine("Goal already complete.");
            }
        }
        else if (goal.IsComplete)
        {
            Console.WriteLine("Goal already complete.");
        }
        Console.WriteLine($"Points earned: {score - before}");
    }

    static void SaveGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(score);
            foreach (var goal in goals)
            {
                sw.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }
        goals.Clear();
        string[] lines = File.ReadAllLines(file);
        score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            goals.Add(Goal.Deserialize(lines[i]));
        }
        Console.WriteLine("Goals loaded.");
    }
}