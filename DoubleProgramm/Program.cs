namespace DoubleProgramm
{
    public class Programmer
    {
        public int Position { get; set; }
        public int Value { get; set; }
        public bool IsPair { get; set; }
    }

    static class Program
    {
        public static List<Programmer>? Programs = new List<Programmer>();
        public static List<string>? Results = new List<string>();

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Programs.Clear();

                int countProgrammer = int.Parse(Console.ReadLine());
                int p = 0;
                foreach (var item in Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray())
                {
                    p++;
                    Programs.Add(new Programmer { Value = item, IsPair = false, Position = p });
                }

                foreach (var prog in Programs)
                {
                    if (prog.IsPair)
                    {
                        continue;
                    }
                    prog.IsPair = true;
                    var item = Programs.Where(w => w.IsPair == false).OrderBy(x => Math.Abs(x.Value - prog.Value)).ElementAt(0);
                    item.IsPair = true;
                    Results.Add(prog.Position.ToString() + " " + item.Position);
                }
                Results.Add(String.Empty);
            }
            foreach (var r in Results)
            {
                Console.WriteLine(r);
            }
        }
    }
}


