using System;
using System.Collections.Generic;

public class ListingActivity : Mindfulness.Activity
{
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void PerformActivity(int duration)
    {
        StartActivity(duration);
        Random rand = new Random();
        int promptIndex = rand.Next(_prompts.Length);
        Console.WriteLine("Prompt: " + _prompts[promptIndex]);
        Console.WriteLine("You will have a few seconds to think about your answer...");
        ShowCountdown(5);
        Console.WriteLine("Start listing items! Press Enter after each item.");

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }
        }
        Console.WriteLine($"You listed {items.Count} items!");
        EndActivity();
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            System.Threading.Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }
}
