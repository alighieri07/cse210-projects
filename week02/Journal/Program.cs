// I added a welcome message to improve the user experience.

using System;

class Program
{
    static void Main(string[] args)
    {
        string userChoice = "";
        Journal myJournal = new Journal();

        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Console.WriteLine("Welcome to your Personal Journal!");
        Console.WriteLine("This program helps you record and reflect on your daily experiences.");
        Console.WriteLine();

        while (userChoice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                Console.WriteLine("You selected: Write a new entry");
                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                Random random = new Random();
                int index = random.Next(prompts.Count);
                newEntry._prompt = prompts[index];
                Console.Write("Your response: ");
                newEntry._response = Console.ReadLine();
                Console.WriteLine("Here is your entry:");
                newEntry.Display();

                myJournal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {
                Console.WriteLine("You selected: Display the journal");
            }
            else if (userChoice == "3")
            {
                Console.WriteLine("You selected: Save the journal to a file");
                Console.Write("Enter the filename to save the journal: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
                Console.WriteLine("Journal saved successfully.");
            }
            else if (userChoice == "4")
            {
                Console.WriteLine("You selected: Load the journal from a file");
                Console.Write("Enter the filename to load the journal: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded successfully.");
            }
            else if (userChoice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
    