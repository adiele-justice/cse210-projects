using System;
using System.Collections.Generic;
using System.Linq;

// Reference class to handle scripture references
public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int VerseEnd { get; private set; }

    // Constructor for single verse reference
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = verse;
    }

    // Constructor for verse range reference
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    // Method to format the reference as a string
    public override string ToString()
    {
        if (VerseStart == VerseEnd)
            return $"{Book} {Chapter}:{VerseStart}";
        else
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
    }
}

// Scripture class to handle the text and word operations
public class Scripture
{
    private Reference reference;
    private string[] words;
    private Word[] wordObjects;

    // Constructor to initialize the scripture with reference and text
    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ');
        wordObjects = words.Select(word => new Word(word)).ToArray();
    }

    // Method to display the scripture
    public void Display()
    {
        Console.WriteLine(reference.ToString());
        Console.WriteLine(string.Join(" ", wordObjects.Select(w => w.IsHidden ? "_".PadRight(w.Text.Length) : w.Text)));
    }

    // Method to hide a random word in the scripture
    public bool HideRandomWord()
    {
        var random = new Random();
        var visibleWords = wordObjects.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count == 0)
            return false;

        int index = random.Next(visibleWords.Count);
        visibleWords[index].Hide();
        return true;
    }

    // Method to check if all words are hidden
    public bool AllWordsHidden()
    {
        return wordObjects.All(w => w.IsHidden);
    }
}

// Word class to represent each word in the scripture
public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}

// Program class to handle user interaction and main logic
class Program
{
    static void Main()
    {
        // Example usage:
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to hide a word, or type 'quit' to exit.");

        while (true)
        {
            scripture.Display();
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            if (scripture.HideRandomWord())
                Console.Clear();
            else
                break; // No more words to hide

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words hidden. Exiting program.");
                break;
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
