namespace ConsoleApp1
{
    class Program
    {
        class TimePointComparer : IComparer<TimePoint>
        {
            public int Compare(TimePoint x, TimePoint y)
            { 
                return x.Time != y.Time ? x.Time.CompareTo(y.Time) : x.Task.CompareTo(y.Task);
            }
        }

        class TimePoint
        {
            public uint Time;
            public int Task;
            public ulong Duration;
        }

        static void Main(string[] args)
        {
            var lineIndex = 0;
            var lines = System.IO.File.ReadAllText(@"d:\123\19").Split('\n');
            Func<string> funcReadLine = () => { return lines[lineIndex++]; };

            var values = funcReadLine().Split();
            var n = uint.Parse(values[0]); // CPUs
            var m = uint.Parse(values[1]); // tasks

            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();

            values = funcReadLine().Split();
            var cpus = new SortedSet<int>();
            foreach (var value in values) { var a = int.Parse(value); cpus.Add(a); }

            //watch.Stop();
            //Console.WriteLine($"Reading CPUs: {watch.ElapsedMilliseconds} msec");
            //watch.Reset();
            //watch.Start();

            var timePoints = new List<TimePoint>();
            for (int i = 0; i < m; ++i)
            {
                values = funcReadLine().Split();
                var startTime = uint.Parse(values[0]);
                var duration = uint.Parse(values[1]);
                timePoints.Add(new TimePoint() { Time = startTime, Task = i + 1, Duration = duration });
                timePoints.Add(new TimePoint() { Time = startTime + duration, Task = -(i + 1), Duration = duration });
            }
            timePoints.Sort(new TimePointComparer());

            //watch.Stop();
            //Console.WriteLine($"Reading tasks: {watch.ElapsedMilliseconds} msec");
            //watch.Reset();
            //watch.Start();

            ulong result = 0;
            TimePoint prevTimePoint = null;
            var usedCPUs = new Dictionary<int, int>();
            foreach (var timePoint in timePoints)
            {
                if (timePoint.Task > 0)
                {
                    if (cpus.Count == 0) { continue; }

                    var cpu = cpus.First();
                    cpus.Remove(cpu);
                    usedCPUs[timePoint.Task] = cpu;
                }
                else
                {
                    if (!usedCPUs.ContainsKey(-timePoint.Task)) { continue; }

                    var cpu = usedCPUs[-timePoint.Task];
                    cpus.Add(cpu);
                    result += timePoint.Duration * (ulong)cpu;
                }
                prevTimePoint = timePoint;
            }

            //watch.Stop();
            //Console.WriteLine($"Caltulation: {watch.ElapsedMilliseconds} msec");

            Console.WriteLine($"{result}");
        }
    }
}