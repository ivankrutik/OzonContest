var res = new List<string>();
var dict = new Dictionary<int, object>();
int prevValue = -1;
bool isExit = false;

int count = int.Parse(Console.ReadLine());
for (int i = 0; i < count; i++)
{
    int countTask = int.Parse(Console.ReadLine());
    int[] tasks = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

    dict.Clear();
    prevValue = -1;
    isExit = false;

    foreach (var task in tasks)
    {
        if (task == prevValue)
        {
            continue;
        }
        prevValue = task;

        try
        {
            dict.Add(task, null);
        }
        catch
        {
            res.Add("NO");
            isExit = true;
            break;
        }
    }
    if (!isExit)
    {
        res.Add("YES");
    }
}

foreach (var r in res)
{
    Console.WriteLine(r);
}