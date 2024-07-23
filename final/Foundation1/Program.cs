using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list to hold Video objects
        List<Video> videos = new List<Video>();

        // Create Video objects and add comments
        Video video1 = new Video("Introduction to C#", "John Doe", 180);
        video1.AddComment("Alice", "Great tutorial!");
        video1.AddComment("Bob", "Very helpful, thanks!");
        video1.AddComment("Carol", "Could be more detailed.");
        videos.Add(video1);

        Video video2 = new Video("Object-Oriented Programming Basics", "Jane Smith", 240);
        video2.AddComment("Eve", "This is confusing.");
        video2.AddComment("Mallory", "Not beginner-friendly.");
        videos.Add(video2);

        Video video3 = new Video("Advanced LINQ Techniques", "Andrew Johnson", 300);
        video3.AddComment("Olivia", "Mind-blowing content!");
        video3.AddComment("Sophia", "I wish there were more examples.");
        video3.AddComment("Liam", "Can you cover a sync programming next?");
        videos.Add(video3);

        // Display information for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string commentText)
    {
        Comments.Add(new Comment(commenterName, commentText));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string CommenterName { get; private set; }
    public string CommentText { get; private set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}
