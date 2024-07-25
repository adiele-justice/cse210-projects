using System;
using System.Collections.Generic;

// Base Activity class
public class Activity
{
    // Common attributes
    private string activityType;
    private double durationMinutes;

    // Constructor
    public Activity(string activityType, double durationMinutes)
    {
        this.activityType = activityType;
        this.durationMinutes = durationMinutes;
    }

    // Virtual methods for polymorphism
    public virtual double GetDistance()
    {
        return 0.0; // Default implementation
    }

    public virtual double GetSpeed()
    {
        return 0.0; // Default implementation
    }

    public virtual double GetPace()
    {
        return 0.0; // Default implementation
    }

    // Method to get summary information
    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"Activity Type: {activityType}\n" +
               $"Duration: {durationMinutes} minutes\n" +
               $"Distance: {distance} km\n" +
               $"Speed: {speed} km/h\n" +
               $"Pace: {pace} min/km";
    }
}

// Derived class for Running activity
public class RunningActivity : Activity
{
    private double distanceKm;

    public RunningActivity(double durationMinutes, double distanceKm) : base("Running", durationMinutes)
    {
        this.distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return distanceKm;
    }

    public override double GetSpeed()
    {
        return (distanceKm / durationMinutes) * 60.0; // km/h
    }

    public override double GetPace()
    {
        return durationMinutes / distanceKm; // min/km
    }
}

// Derived class for Cycling activity
public class CyclingActivity : Activity
{
    private double distanceKm;

    public CyclingActivity(double durationMinutes, double distanceKm) : base("Cycling", durationMinutes)
    {
        this.distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return distanceKm;
    }

    public override double GetSpeed()
    {
        return (distanceKm / durationMinutes) * 60.0; // km/h
    }

    public override double GetPace()
    {
        return durationMinutes / distanceKm; // min/km
    }
}

// Derived class for Swimming activity
public class SwimmingActivity : Activity
{
    private int laps;

    public SwimmingActivity(double durationMinutes, int laps) : base("Swimming", durationMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        // Convert laps to kilometers
        return laps * 50.0 / 1000.0;
    }

    public override double GetSpeed()
    {
        double distanceKm = GetDistance();
        return (distanceKm / durationMinutes) * 60.0; // km/h
    }

    public override double GetPace()
    {
        double distanceKm = GetDistance();
        return durationMinutes / distanceKm; // min/km
    }
}

public class Program
{
    public static void Main()
    {
        // Create a list to hold different activities
        List<Activity> activities = new List<Activity>();

        // Add different activities to the list
        activities.Add(new RunningActivity(30.0, 5.0)); // Running for 5 km in 30 minutes
        activities.Add(new CyclingActivity(45.0, 15.0)); // Cycling for 15 km in 45 minutes
        activities.Add(new SwimmingActivity(25.0, 20)); // Swimming 20 laps in 25 minutes

        // Iterate through the list and display the summary of each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine("----------------------------");
        }
    }
}
