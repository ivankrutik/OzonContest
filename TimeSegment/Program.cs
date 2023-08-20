List<string> res = new List<string>();
List<string> list = new List<string>();
List<Tuple<DateTime, DateTime>> dates = new List<Tuple<DateTime, DateTime>>();
DateTime[] segments = new DateTime[2];
int countSegment = 0;
bool IsBreak;

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    IsBreak = false;
    dates.Clear();
    list.Clear();

    countSegment = int.Parse(Console.ReadLine());

    for (int j = 0; j < countSegment; j++)
    {
        list.Add(Console.ReadLine());
    }

    foreach (var l in list)
    {
        try
        {
            segments = l.Split('-').Select(DateTime.Parse).ToArray();
            if (segments[0] > segments[1])
            {
                IsBreak = true;
                break;
            }
            foreach (var d in dates)
            {
                if ((d.Item1 <= segments[0] && segments[0] <= d.Item2) || 
                    (d.Item1 <= segments[1] && segments[1] <= d.Item2) || 
                    (segments[0] <= d.Item1 && d.Item1 <= segments[1]) || 
                    (segments[0] <= d.Item2 && d.Item2 <= segments[1]))
                {
                    IsBreak = true;
                    break;
                }
            }
            if (IsBreak)
            {
                break;
            }
            dates.Add(new(segments[0], segments[1]));
        }
        catch
        {
            IsBreak = true;
            break;
        }
    }

    if (IsBreak)
    {
        res.Add("NO");
    }
    else
    {
        res.Add("YES");
    }
}
foreach (var r in res)
{
    Console.WriteLine(r);
}