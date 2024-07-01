class Program
{
    static void Main(string[] args)
    {
        // Initialize scripture
        string scriptureRef = "John 3:16";
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(scriptureRef, scriptureText);

        // Main loop
        bool continueHiding = true;

        do
        {
            Console.WriteLine("Press Enter to continue hiding words, or type 'quit' to exit.");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                continueHiding = false;
            }
            else
            {
                Console.Clear();
                scripture.HideRandomWord();
                scripture.Display();
                continueHiding = !scripture.AllWordsHidden();
            }

        } while (continueHiding);

        Console.WriteLine("All words hidden. Program ended.");
    }
}
