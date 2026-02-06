/*
Given n, count all 'a' and 'b' that satisfy the condition a^3 + b^3 = n. Where (a, b) and (b, a) are 
considered two different pairs
*/
public class Program
{
    public static void Main(string[] args)
    {
        int n = 36;
        Dictionary<int, int> pairs = PairCubeCount(n);
        int totalPairs = pairs.Count;
        Console.WriteLine($"Total Pairs: {totalPairs}");
        foreach(KeyValuePair<int, int> dict in pairs)
        {
            Console.WriteLine($"[{dict.Key}, {dict.Value}]");
        }

    }
    public static Dictionary<int, int> PairCubeCount(int n)
    {
        Dictionary<int, int> pairs = new Dictionary<int, int>();
        int i = 1;
        int maxCbrt = (int)Math.Pow(n, (1.0/3.0));
        while (i<=maxCbrt)
        {
            int diff = n - (i*i*i);
            int cbrt = (int)Math.Pow(diff, (1.0/3.0));
            if(cbrt * cbrt * cbrt == diff)
            {
                pairs.Add(i, cbrt);
            }
            i++;
        }
        return pairs;
    }
}