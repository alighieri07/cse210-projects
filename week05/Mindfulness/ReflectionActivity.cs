using System;
using System.Diagnostics;

public class ReflectionActivity : Mindfulness.Activity
{
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on meaningful experiences in your life.")
    {
    }

    public void PerformActivity(int duration)
    {
        StartActivity(duration);
        Random rand = new Random();
        int promptIndex = rand.Next(_prompts.Length);
        Console.WriteLine("Prompt: " + _prompts[promptIndex]);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            int questionIndex = rand.Next(_questions.Length);
            Console.WriteLine(_questions[questionIndex]);
            ShowSpinner(4); 
        }
        EndActivity();
    }

    private void ShowSpinner(int seconds)
    {
        string[] spinner = {"|", "/", "-", "\\"};
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            System.Threading.Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }
}