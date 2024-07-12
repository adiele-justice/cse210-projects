using System;
using System.Threading;

// Base class for all activities
public abstract class Activity
{
    protected string activityName;
    protected int durationInSeconds;

    // Constructor
    public Activity(string name)
    {
        activityName = name;
    }

    // Method to start the activity
    public virtual void Start()
    {
        DisplayStartingMessage();
        Thread.Sleep(3000); // Pause for 3 seconds
        PerformActivity();
        DisplayEndingMessage();
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    // Common starting message for all activities
    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {activityName} activity...");
        Console.WriteLine($"Duration set to {durationInSeconds} seconds.");
        Console.WriteLine("Get ready to begin.");
        Console.WriteLine();
    }

    // Common ending message for all activities
    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"You've completed the {activityName} activity for {durationInSeconds} seconds.");
        Console.WriteLine("Great job!");
    }

    // Abstract method to be implemented in derived classes
    protected abstract void PerformActivity();
}

// Activity for deep breathing exercise
public class BreathingActivity : Activity
{
    public BreathingActivity(string name) : base(name) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("Clear your mind and focus on your breathing.");
        for (int i = 1; i <= durationInSeconds; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
        }
    }
}

// Activity for reflection exercise
public class ReflectionActivity : Activity
{
    private string[] reflectionPrompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    public ReflectionActivity(string name) : base(name) { }

    protected override void PerformActivity()
    {
        Random random = new Random();
        int randomIndex = random.Next(reflectionPrompts.Length);
        string prompt = reflectionPrompts[randomIndex];

        Console.WriteLine($"Reflecting on: {prompt}");
        Console.WriteLine("Let's consider this experience deeply:");
        Thread.Sleep(3000); // Pause for 3 seconds

        // Simulating reflection questions
        string[] questions = {
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

        foreach (var question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(5000); // Pause for 5 seconds
        }
    }
}

// Activity for listing exercise
public class ListingActivity : Activity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt at peace this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name) : base(name) { }

    protected override void PerformActivity()
    {
        Random random = new Random();
        int randomIndex = random.Next(listingPrompts.Length);
        string prompt = listingPrompts[randomIndex];

        Console.WriteLine($"Listing: {prompt}");
        Console.WriteLine("Think about this category and start listing:");

        // Simulating listing items
        int itemCounter = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(durationInSeconds);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
                break;
            itemCounter++;
        }

        Console.WriteLine($"You listed {itemCounter} items in {durationInSeconds} seconds.");
    }
}

// Main program
class Program
{
    static void Main()
    {
        // Display menu and handle user choice
        while (true)
        {
            Console.WriteLine("Mindfulness Program Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ExecuteActivity(new BreathingActivity("Breathing"));
                    break;
                case "2":
                    ExecuteActivity(new ReflectionActivity("Reflection"));
                    break;
                case "3":
                    ExecuteActivity(new ListingActivity("Listing"));
                    break;
                case "4":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Method to execute selected activity
    static void ExecuteActivity(Activity activity)
    {
        Console.Clear(); // Clear console before starting activity
        Console.WriteLine($"You selected {activity.GetType().Name} Activity.");
        Console.WriteLine();

        // Set duration
        Console.Write("Enter duration in seconds: ");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number: ");
        }
        activity.Start();

        // Pause before returning to menu
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
        Console.Clear(); // Clear console before returning to menu
    }
}
