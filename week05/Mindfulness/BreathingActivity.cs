using System;

public class BreathingActivity : Mindfulness.Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by focusing on your breathing.")
    {
    }

    public void PerformActivity(int duration)
    {
        StartActivity(duration);
        Console.WriteLine("Breathe in... Breathe out...");
        EndActivity();
    }
}