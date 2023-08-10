namespace ConsoleApp1
{
    class Program
    {
        private new static readonly List<string> _dictionary =
          new List<string>();

        private static Dictionary<char, int> _charPositions =
          new Dictionary<char, int>();

        private static Dictionary<string, string> _results =
          new Dictionary<string, string>();

        private static string findSuffix(string query)
        {
            string result = string.Empty;
            if (!_results.TryGetValue(query, out result))
            {
                result = Reverse(_dictionary.First(s => s != query));

                int i = 0;
                if (_charPositions.TryGetValue(query[0], out i))
                {
                    int j = 0;
                    while (i < _dictionary.Count)
                    {
                        if (j >= query.Length)
                        {
                            break;
                        }

                        if (j < _dictionary[i].Length && query[j] == _dictionary[i][j])
                        {
                            var equal = true;
                            for (var k = 0; equal && k < j; ++k)
                            {
                                equal = (query[k] == _dictionary[i][k]);
                            }
                            if (!equal)
                            {
                                break;
                            }

                            equal = query.Length == _dictionary[i].Length;

                            for (var k = j; equal && k < query.Length; ++k) 
                            { 
                                equal = (query[k] == _dictionary[i][k]); 
                            }
                            if (!equal)
                            {
                                result = Reverse(_dictionary[i]);
                                j++;
                                continue;
                            }
                        }
                        i++;
                    }
                }
                _results[query] = result;
            }
            return result;
        }

        static void Main()
        {
            // read dictionary
            var dictionaryLength = int.Parse(Console.ReadLine());
            for (var i = 0; i < dictionaryLength; ++i)
            {
                _dictionary.Add(Reverse(Console.ReadLine()));
            }
            _dictionary.Sort();

            // find starting positions
            for (int i = 0; i < _dictionary.Count; ++i)
            {
                if (!_charPositions.ContainsKey(_dictionary[i][0]))
                {
                    _charPositions[_dictionary[i][0]] = i;
                }
            }

            // suffixes
            var suffixes = new List<string>();

            // read queries
            var queries = new List<string>();
            var queriesLength = int.Parse(Console.ReadLine());
            for (var i = 0; i < queriesLength; ++i)
            {
                suffixes.Add(findSuffix(Reverse(Console.ReadLine())));
            }

            foreach (var suffix in suffixes)
            {
                Console.WriteLine(suffix);
            }
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}