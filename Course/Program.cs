internal class Program
{
    private static void Main(string[] args)
    {


        Console.Write("Enter file full path: ");
        string path = Console.ReadLine();
        try
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] votingRecord = sr.ReadLine().Split(',');
                    string candidate = votingRecord[0];
                    int votes = int.Parse(votingRecord[1]);

                    if (map.ContainsKey(candidate))
                    {
                        map[candidate] += votes;
                    }
                    else
                    {
                        map[candidate] = votes;
                    }

                }
            }

            foreach (var mapp in map)
            {
                Console.WriteLine(mapp.Key + ": " + mapp.Value);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}