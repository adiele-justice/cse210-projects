using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new EternalQuest instance
        EternalQuest eternalQuest = new EternalQuest();

        // Load goals and scores from file
        eternalQuest.LoadData();

        // Main menu loop
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n===== Eternal Quest Program =====");
            Console.WriteLine("1. List Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event (Achieve Goal)");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Enter your choice (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        eternalQuest.ListGoals();
                        break;
                    case 2:
                        eternalQuest.CreateNewGoal();
                        break;
                    case 3:
                        eternalQuest.RecordEvent();
                        break;
                    case 4:
                        eternalQuest.ShowScore();
                        break;
                    case 5:
                        eternalQuest.SaveData();
                        exit = true;
                        Console.WriteLine("Data saved. Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}

// Base class for goals
abstract class Goal
{
    protected string name;
    protected bool isCompleted;

    public Goal(string name)
    {
        this.name = name;
        isCompleted = false;
    }

    public abstract void RecordEvent();

    public abstract string GetProgress();
    
    public abstract int GetPoints();

    public override string ToString()
    {
        string status = isCompleted ? "[X]" : "[ ]";
        return $"{status} {name} - {GetProgress()}";
    }
}

// Simple goal class
class SimpleGoal : Goal
{
    private int points;

    public SimpleGoal(string name, int points) : base(name)
    {
        this.points = points;
    }

    public override void RecordEvent()
    {
        if (!isCompleted)
        {
            isCompleted = true;
        }
    }

    public override string GetProgress()
    {
        return isCompleted ? "Completed" : "Not Completed";
    }

    public override int GetPoints()
    {
        return isCompleted ? points : 0;
    }
}

// Eternal goal class
class EternalGoal : Goal
{
    private int pointsPerCompletion;

    public EternalGoal(string name, int pointsPerCompletion) : base(name)
    {
        this.pointsPerCompletion = pointsPerCompletion;
    }

    public override void RecordEvent()
    {
        // Eternal goals are never completed, but events can be recorded
    }

    public override string GetProgress()
    {
        return "Infinite";
    }

    public override int GetPoints()
    {
        return pointsPerCompletion;
    }
}

// Checklist goal class
class ChecklistGoal : Goal
{
    private int targetCount;
    private int pointsPerCompletion;
    private int currentCount;

    public ChecklistGoal(string name, int targetCount, int pointsPerCompletion) : base(name)
    {
        this.targetCount = targetCount;
        this.pointsPerCompletion = pointsPerCompletion;
        this.currentCount = 0;
    }

    public override void RecordEvent()
    {
        currentCount++;
        if (currentCount >= targetCount)
        {
            isCompleted = true;
        }
    }

    public override string GetProgress()
    {
        return $"Completed {currentCount}/{targetCount} times";
    }

    public override int GetPoints()
    {
        return isCompleted ? pointsPerCompletion + 500 : pointsPerCompletion;
    }
}

// Class to manage Eternal Quest functionality
class EternalQuest
{
    private List<Goal> goals;
    private int totalScore;

    public EternalQuest()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void ListGoals()
    {
        Console.WriteLine("\n===== Goals List =====");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal);
        }
    }

    public void CreateNewGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int typeChoice;
        if (int.TryParse(Console.ReadLine(), out typeChoice))
        {
            switch (typeChoice)
            {
                case 1:
                    Console.Write("Enter points for completing the goal: ");
                    int points = int.Parse(Console.ReadLine());
                    goals.Add(new SimpleGoal(name, points));
                    break;
                case 2:
                    Console.Write("Enter points for each completion: ");
                    int pointsPerCompletion = int.Parse(Console.ReadLine());
                    goals.Add(new EternalGoal(name, pointsPerCompletion));
                    break;
                case 3:
                    Console.Write("Enter target completion count: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter points for each completion: ");
                    pointsPerCompletion = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, targetCount, pointsPerCompletion));
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal not created.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Goal not created.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select goal to record event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i]}");
        }

        int goalChoice;
        if (int.TryParse(Console.ReadLine(), out goalChoice) && goalChoice >= 1 && goalChoice <= goals.Count)
        {
            goals[goalChoice - 1].RecordEvent();
            totalScore += goals[goalChoice - 1].GetPoints();
            Console.WriteLine($"Event recorded. You gained {goals[goalChoice - 1].GetPoints()} points.");
        }
        else
        {
            Console.WriteLine("Invalid choice. Event not recorded.");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"\n===== Total Score: {totalScore} =====");
    }

    public void SaveData()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                outputFile.WriteLine(goal.GetType().Name + "," + goal.ToString());
            }
        }

        using (StreamWriter outputFile = new StreamWriter("score.txt"))
        {
            outputFile.WriteLine(totalScore);
        }
    }

    public void LoadData()
    {
        try
        {
            goals.Clear(); // Clear existing goals before loading
            string[] lines = File.ReadAllLines("goals.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string type = parts[0];
                string details = parts[1];

                switch (type)
                {
                    case "SimpleGoal":
                        string[] simpleParts = details.Split('-');
                        string goalName = simpleParts[0].Trim();
                        int points = int.Parse(simpleParts[1].Trim());
                        goals.Add(new SimpleGoal(goalName, points));
                        break;
                    case "EternalGoal":
                        string[] eternalParts = details.Split('-');
                        string eternalGoalName = eternalParts[0].Trim();
                        int pointsPerCompletion = int.Parse(eternalParts[1].Trim());
                        goals.Add(new EternalGoal(eternalGoalName, pointsPerCompletion));
                        break;
                    case "ChecklistGoal":
                        string[] checklistParts = details.Split('-');
                        string checklistGoalName = checklistParts[0].Trim();
                        string[] checklistDetails = checklistParts[1].Trim().Split('/');
                        int currentCount = int.Parse(checklistDetails[0].Substring(10));
                        int targetCount = int.Parse(checklistDetails[1]);
                        int pointsForCompletion = int.Parse(checklistDetails[2]);
                        goals.Add(new ChecklistGoal(checklistGoalName, targetCount, pointsForCompletion));
                        ((ChecklistGoal)goals[goals.Count - 1]).RecordEvent(); // To set current count
                        for (int i = 0; i < currentCount; i++)
                        {
                            ((ChecklistGoal)goals[goals.Count - 1]).RecordEvent();
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown goal type in file.");
                        break;
                }
            }

            string scoreLine = File.ReadAllText("score.txt");
            totalScore = int.Parse(scoreLine);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No previous data found. Starting with a clean slate.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }
}
