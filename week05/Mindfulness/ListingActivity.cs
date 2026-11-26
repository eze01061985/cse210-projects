class ListingActivity : Activity
{
    private string[] _prompts =
    {
        "Who are some people you appreciate?",
        "What are some of your strengths?",
        "Who have you helped this week?",
        "What are some small things you are grateful for today?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing", "List as many good things as you can in the area described by the prompt.")
    {
    }

    public void Run()
    {
        if (Console.IsInputRedirected)
        {
            Console.WriteLine("Start this activity in a terminal so you can type your responses.");
            return;
        }

        if (!DisplayStartingMessage())
        {
            return;
        }

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[Random.Shared.Next(_prompts.Length)]} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine("Press Enter after each item.");

        int count = CountResponses(GetEndTime());
        Console.WriteLine($"You listed {count} items!");
        DisplayEndingMessage();
    }

    private int CountResponses(DateTime endTime)
    {
        int count = 0;
        string item = "";
        Console.Write("> ");

        // Check the clock while waiting for a key so Enter is not needed to finish.
        while (DateTime.UtcNow < endTime)
        {
            if (!Console.KeyAvailable)
            {
                Thread.Sleep(50);
                continue;
            }

            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    count++;
                }

                item = "";
                Console.WriteLine();
                Console.Write("> ");
            }
            else if (key.Key == ConsoleKey.Backspace && item.Length > 0)
            {
                item = item.Remove(item.Length - 1);
                Console.Write("\b \b");
            }
            else if (!char.IsControl(key.KeyChar))
            {
                item += key.KeyChar;
                Console.Write(key.KeyChar);
            }
        }

        Console.WriteLine();
        return count;
    }
}
