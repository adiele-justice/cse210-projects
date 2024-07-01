// Word class to represent each word in the scripture
public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

// ScriptureReference class to handle scripture references
public class ScriptureReference
{
    public string Reference { get; private set; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }
}

// Scripture class to handle the scripture text and operations
public class Scripture
{
    private ScriptureReference reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = new ScriptureReference(reference);
        words = new List<Word>();

        // Split the text into words
        string[] wordArray = text.Split(' ');

        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine($"Scripture Reference: {reference.Reference}");
        foreach (Word word in words)
        {
            if (word.IsHidden)
                Console.Write("_ ");
            else
                Console.Write(word.Text + " ");
        }
        Console.WriteLine();
    }

    public bool HideRandomWord()
    {
        // Find a word that is not hidden
        List<Word> visibleWords = words.Where(w => !w.IsHidden).ToList();

        if (visibleWords.Count == 0)
            return false; // No more words to hide

        Random rand = new Random();
        int index = rand.Next(0, visibleWords.Count);
        visibleWords[index].IsHidden = true;

        return true;
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden);
    }
}
