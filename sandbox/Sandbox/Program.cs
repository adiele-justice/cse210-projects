using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string choice;

        do
        {
            DisplayMenu();
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    DisplayJournal(journal);
                    break;
                case "3":
                    SaveJournalToFile(journal);
                    break;
                case "4":
                    LoadJournalFromFile(journal);
                    break;
                case "5":
                    Console.WriteLine($"Total entries: {journal.CountEntries()}");
                    break;
                case "6":
                    Console.WriteLine("Exiting program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != "6");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nJournal Program Menu");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display journal entries");
        Console.WriteLine("3. Save journal to a file");
        Console.WriteLine("4. Load journal from a file");
        Console.WriteLine("5. Count total entries");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
    }

    static void WriteNewEntry(Journal journal)
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        string prompt = prompts[index];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        journal.AddEntry(new JournalEntry(prompt, response, date));
    }

    static void DisplayJournal(Journal journal)
    {
        Console.WriteLine("\nJournal Entries:");
        journal.DisplayEntries();
    }

    static void SaveJournalToFile(Journal journal)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine($"Journal saved to {filename}");
    }

    static void LoadJournalFromFile(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine($"Journal loaded from {filename}");
    }
}