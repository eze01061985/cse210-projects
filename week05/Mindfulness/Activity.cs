class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected bool DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            if (input == null)
            {
                return false;
            }

            if (int.TryParse(input, out _duration) && _duration > 0)
            {
                break;
            }

            Console.WriteLine("Please enter a positive number of seconds.");
        }

        Console.WriteLine();
        Console.Write("Get ready... ");
        ShowSpinner(3);
        Console.WriteLine();
        return true;
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.Write("Well done! ");
        ShowSpinner(2);
        Console.WriteLine();
        Console.Write($"You have completed another {_duration} seconds of the {_name} Activity. ");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected DateTime GetEndTime()
    {
        return DateTime.UtcNow.AddSeconds(_duration);
    }

    protected int GetSecondsLeft(DateTime endTime)
    {
        return Math.Max(0, (int)Math.Ceiling((endTime - DateTime.UtcNow).TotalSeconds));
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", @"\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
