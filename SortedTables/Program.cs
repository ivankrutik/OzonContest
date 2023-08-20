namespace SortedTables
{
    static class Program
    {
        private static int[,] SwitchRows(int[,] array, List<Tuple<int, int>> sortList)
        {
            int iterator = 0;
            int x = array.GetLength(0);
            int y = array.GetLength(1);
            int[,] res = new int[x, y];

            foreach (var s in sortList)
            {
                for (int i = 0; i < y; i++)
                {
                    res[iterator, i] = array[s.Item1, i];
                }

                iterator++;
            }
            return res;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int x;
            int y;
            string temp;
            int[,] arr;
            int[] sortArr;
            int iterator = 0;
            List<Tuple<int, int>> sortList = new List<Tuple<int, int>>();
            List<string> res = new List<string>();

            for (int i = 0; i < count; i++)
            {
                Console.ReadLine();

                temp = Console.ReadLine();
                x = int.Parse(temp.Split(' ')[0]);
                y = int.Parse(temp.Split(' ')[1]);
                arr = new int[x, y];

                for (int row = 0; row < x; row++)
                {
                    iterator = 0;
                    foreach (var col in Console.ReadLine().Split(' ').Select(int.Parse).ToArray())
                    {
                        arr[row, iterator] = col;
                        iterator++;
                    }
                }

                var countSort = int.Parse(Console.ReadLine());
                sortArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                /*logic*/
                foreach (var s in sortArr)
                {
                    iterator = 0;
                    for (var row = 0; row < x; row++)
                    {
                        sortList.Add(new Tuple<int, int>(iterator, arr[row, s - 1]));
                        iterator++;
                    }
                    sortList = sortList.OrderBy(x => x.Item2).ToList();
                    arr = SwitchRows(arr, sortList);
                    sortList.Clear();
                }

                temp = string.Empty;
                for (int row = 0; row < x; row++)
                {
                    for (int col = 0; col < y; col++)
                    {
                        if (col == 0)
                        {
                            temp = arr[row, col].ToString();
                        }
                        else
                        {
                            temp = temp + ' ' + arr[row, col];
                        }
                    }
                    res.Add(temp);
                    temp = string.Empty;
                }
                res.Add(string.Empty);
            }

            foreach (var r in res)
            {
                Console.WriteLine(r);
            }
        }
    }
}
