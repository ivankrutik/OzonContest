// See https://aka.ms/new-console-template for more information
var count = int.Parse(Console.ReadLine().ToString());
var results = new List<int>();

for (int i = 0; i < count; i++)
{
    var arr = Console.ReadLine().ToString().Split(' ');
    results.Add(int.Parse(arr[0]) + int.Parse(arr[1]));
}
foreach (var result in results)
{
    Console.WriteLine(result);
}
