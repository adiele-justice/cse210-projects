using System;

// Address class to encapsulate address information
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {ZipCode}";
    }
}

// Base Event class
public class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    // Standard details message
    public virtual string GetStandardDetails()
    {
        return $"Event: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}\n";
    }

    // Full details message
    public virtual string GetFullDetails()
    {
        return GetStandardDetails(); // Base class only provides standard details
    }

    // Short description message
    public virtual string GetShortDescription()
    {
        return $"Type: Generic Event\nEvent: {title}\nDate: {date.ToShortDateString()}\n";
    }
}

// Lecture class inheriting from Event
public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    // Override full details message for Lecture
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() +
               $"Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}\n";
    }
}

// Reception class inheriting from Event
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    // Override full details message for Reception
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() +
               $"Type: Reception\nRSVP Email: {rsvpEmail}\n";
    }
}

// OutdoorGathering class inheriting from Event
public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    // Override full details message for OutdoorGathering
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() +
               $"Type: Outdoor Gathering\nWeather Forecast: {weatherForecast}\n";
    }
}

// Main program
class Program
{
    static void Main()
    {
        // Create an Address instance
        Address eventAddress = new Address("123 Main St", "Anytown", "CA", "90210");

        // Create instances of each event type
        Event genericEvent = new Event("Generic Event", "An event for demonstration purposes", DateTime.Now.Date, new TimeSpan(18, 0, 0), eventAddress);
        Lecture lectureEvent = new Lecture("Tech Talk", "Exciting developments in technology", DateTime.Now.Date.AddDays(7), new TimeSpan(14, 0, 0), eventAddress, "Dr. Smith", 50);
        Reception receptionEvent = new Reception("Networking Mixer", "Come network with professionals", DateTime.Now.Date.AddDays(14), new TimeSpan(19, 0, 0), eventAddress, "rsvp@example.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Summer Picnic", "Enjoy food and games outdoors", DateTime.Now.Date.AddDays(21), new TimeSpan(11, 0, 0), eventAddress, "Sunny with a chance of clouds");

        // Generate and print marketing messages for each event
        Console.WriteLine("=== Standard Details ===");
        Console.WriteLine(genericEvent.GetStandardDetails());
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine(outdoorEvent.GetStandardDetails());

        Console.WriteLine("=== Full Details ===");
        Console.WriteLine(genericEvent.GetFullDetails());
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine(outdoorEvent.GetFullDetails());

        Console.WriteLine("=== Short Descriptions ===");
        Console.WriteLine(genericEvent.GetShortDescription());
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}
