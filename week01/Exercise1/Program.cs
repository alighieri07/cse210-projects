using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstname = Console.ReadLine();
        Console.WriteLine($"You entered: {firstname}");

        Console.Write("What is you last name? ");
        string lastname = Console.ReadLine();
        Console.WriteLine($"You entered: {lastname}");

        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}");
    }
}