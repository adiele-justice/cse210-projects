using System;

class Program
{
    static void Main()
    {
        // Prompt user for grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();

        // Convert input to integer
        if (!int.TryParse(input, out int percentage))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer percentage.");
            return;
        }

        // Determine the letter grade
        char letter;
        if (percentage >= 90)
        {
            letter = 'A';
        }
        else if (percentage >= 80)
        {
            letter = 'B';
        }
        else if (percentage >= 70)
        {
            letter = 'C';
        }
        else if (percentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        // Output the letter grade
        Console.WriteLine($"Your letter grade is: {letter}");

        // Check if the user passed or failed
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed this course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass this course. Keep trying!");
        }
    }
}