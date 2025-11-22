using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>();

        var video1 = new Video("How to Bake Bread", "Chef Emma", 420);
        video1.AddComment(new Comment("Alice", "Great Job!"));
        video1.AddComment(new Comment("Bob", "Can I use whole wheat flour?"));
        video1.AddComment(new Comment("Charlie", "Turned out perfect!"));
        videos.Add(video1);

        var video2 = new Video("Guitar Basics", "John Music", 315);
        video2.AddComment(new Comment("Dave", "Very helpful, thanks!"));
        video2.AddComment(new Comment("Eve", "What guitar do you recommend?"));
        video2.AddComment(new Comment("Frank", "Loved the tips!"));
        videos.Add(video2);

        var video3 = new Video("Travel Vlog: Japan", "Wanderlust", 600);
        video3.AddComment(new Comment("Grace", "Beautiful scenery!"));
        video3.AddComment(new Comment("Heidi", "Where did you stay?"));
        video3.AddComment(new Comment("Ivan", "I want to visit now!"));
        videos.Add(video3);

        var video4 = new Video("DIY Desk Setup", "Techie Tom", 480);
        video4.AddComment(new Comment("Judy", "Looks awesome!"));
        video4.AddComment(new Comment("Karl", "Where did you get the lamp?"));
        video4.AddComment(new Comment("Liam", "Can you share the parts list?"));
        videos.Add(video4);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}