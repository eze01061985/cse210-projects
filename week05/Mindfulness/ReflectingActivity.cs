class ReflectingActivity : Activity
{
    private string[] _prompts =
    {
        "Think of a time when you stood up for someone.",
        "Think of a time when you finished something difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you put someone else's needs first."
    };

    private string[] _questions =
    {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "What kept you going when it got hard?",
        "How did you feel when it was over?",
        "Who helped you along the way?",
        "What would you do the same next time?",
        "What did you learn about yourself?",
        "How could you use what you learned in another situation?",
        "What would help you remember this experience?"
    };

    public ReflectingActivity()
        : base("Reflecting", "Think about a time you showed strength and what you can learn from it.")
    {
    }

    public void Run()
    {
        if (!DisplayStartingMessage())
        {
            return;
        }

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {_prompts[Random.Shared.Next(_prompts.Length)]} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        if (Console.ReadLine() == null)
        {
            return;
        }

        Console.Write("Now reflect on the following questions. You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine();

        List<string> remainingQuestions = new List<string>(_questions);
        DateTime endTime = GetEndTime();
        while (DateTime.UtcNow < endTime)
        {
            if (remainingQuestions.Count == 0)
            {
                remainingQuestions.AddRange(_questions);
            }

            int index = Random.Shared.Next(remainingQuestions.Count);
            Console.Write($"> {remainingQuestions[index]} ");
            remainingQuestions.RemoveAt(index);
            ShowSpinner(Math.Min(5, GetSecondsLeft(endTime)));
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
