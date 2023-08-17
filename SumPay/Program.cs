var res = new List<int>();

var countRead = int.Parse(Console.ReadLine());
for (int i = 0; i < countRead; i++)
{
    var sum = 0;
    int repeatCount = 0;
    int previewValue = -1;
    var countProduct = Console.ReadLine();
    var prices = Console.ReadLine().Split(' ');
    Array.Sort(prices);

    foreach (var price in prices)
    {
        if (previewValue == int.Parse(price))
        {
            repeatCount ++;
        }
        else
        {
            repeatCount = 0;
        }
        if (repeatCount == 2)
        {
            repeatCount = 0;
            previewValue = -1;
            continue;
        }
        else
        {
            sum += int.Parse(price);
        }
        previewValue = int.Parse(price);
    }
    res.Add(sum);
}

foreach (var price in res)
{
    Console.WriteLine(price);
}
