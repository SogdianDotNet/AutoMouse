using System.Runtime.InteropServices;
using System.Timers;
using Timer = System.Timers.Timer;

Console.WriteLine("AutoMouse is welcoming you!");
Console.WriteLine("Every how many seconds would you like your mouse to move?");
var secondsFrequency = Console.ReadLine();
int seconds;

while (!int.TryParse(secondsFrequency, out seconds))
{
    Console.WriteLine("Provide a valid input (number)");
    secondsFrequency = Console.ReadLine();
}

Console.WriteLine($"You chose the frequency of every {seconds} seconds");
Console.WriteLine("Press ENTER to start the program.");
var enterKey = Console.ReadKey();

while (enterKey.Key != ConsoleKey.Enter)
{
    Console.WriteLine("Press ENTER to start the program.");
}

Console.WriteLine("Program started.");

var timer = new Timer(seconds * 1000);
timer.Elapsed += OnTimedEvent;
timer.AutoReset = true;
timer.Enabled = true;

Console.WriteLine("Press the Enter key to exit the program at any time... ");
enterKey = Console.ReadKey();

while (enterKey.Key != ConsoleKey.Enter)
{
    Console.WriteLine("Press ENTER to start the program.");
}

timer.Stop();
timer.Dispose();

Console.WriteLine("Program stopped.");

static void OnTimedEvent(Object source, ElapsedEventArgs e)
{
    GetCursorPos(out Point currentPos);
    SetCursorPos(currentPos.X + 10, currentPos.Y + 10);
    SetCursorPos(currentPos.X, currentPos.Y);
}

[DllImport("User32.dll")]
static extern bool SetCursorPos(int x, int y);

[DllImport("User32.dll")]
static extern bool GetCursorPos(out Point lpPoint);

[StructLayout(LayoutKind.Sequential)]
struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}