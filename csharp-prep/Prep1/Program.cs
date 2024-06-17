using System;

class Program
{
    static void Main()
    {
        // Prompting user for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompting user for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Outputting the formatted name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
