using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        Console.WriteLine($"Hello, {userName}!");
        int userNumber = PromptUserNumber();
        Console.WriteLine($"Your favorite number is {userNumber}.");
        int squaredNumber = SquareNumber(userNumber);
        Console.WriteLine($"The square of your favorite number is {squaredNumber}.");
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    
}

   