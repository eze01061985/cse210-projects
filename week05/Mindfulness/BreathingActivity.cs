class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "Take a moment to relax and focus on breathing in and out slowly.")
    {
    }

    public void Run()
    {
        if (!DisplayStartingMessage())
        {
            return;
        }

        DateTime endTime = GetEndTime();
        bool breatheIn = true;

        while (DateTime.UtcNow < endTime)
        {
            Console.Write(breatheIn ? "Breathe in... " : "Breathe out... ");
            ShowCountdown(Math.Min(breatheIn ? 4 : 6, GetSecondsLeft(endTime)));
            Console.WriteLine();
            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}
