using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option (1-4): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter duration in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                BreathingActivity breathing = new BreathingActivity();
                breathing.PerformActivity(duration);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else if (choice == "2")
            {
                Console.Write("Enter duration in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.PerformActivity(duration);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else if (choice == "3")
            {
                Console.Write("Enter duration in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                ListingActivity listing = new ListingActivity();
                listing.PerformActivity(duration);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else if (choice == "4")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option. Press Enter to try again.");
                Console.ReadLine();
            }
        }
        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}