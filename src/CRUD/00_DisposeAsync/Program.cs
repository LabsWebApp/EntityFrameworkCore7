using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();
using (new Timer(_ => Thread.Sleep(1000), null, 0, Timeout.Infinite))
{
    await Task.Delay(100);
}
Console.WriteLine($"Duration: {stopwatch.ElapsedMilliseconds:#,0} msec");

stopwatch.Restart();
await using (new Timer(_ => Thread.Sleep(1000), null, 0, Timeout.Infinite))
{
    await Task.Delay(100);
}
Console.WriteLine($"Duration: {stopwatch.ElapsedMilliseconds:#,0} msec");

Console.ReadKey();