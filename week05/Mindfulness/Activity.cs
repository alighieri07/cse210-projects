using System;

namespace Mindfulness

{
    public class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void StartActivity(int duration)
        {
            _duration = duration;
            Console.WriteLine($"Starting {_name} for {_duration} seconds.");
            Console.WriteLine(_description);
        }

        public void EndActivity()
        {
            Console.WriteLine($"Ending {_name}. You have completed {_duration} seconds of mindfulness.");
        }
    }
    
}