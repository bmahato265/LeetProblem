
using System.Runtime.CompilerServices;

public class CollectionPractice
{
   public static void Main(string[] args)
    {
        // Console.WriteLine(String.Join(" ", RemoveDuplicates()));
        var dictResponse = CountCharFrequency("Hriday Narayan Shah Kanu");
        foreach(var dict in dictResponse)
        {
        Console.WriteLine($"{dict.Key}:{dict.Value}");
        }

    }
   
    public static Dictionary<char, int> CountCharFrequency(string input)
    {
        //Given input is "progromming"
        /*
        Approach: step 1: Create a empty dictionary having <char, frequencyCount<int>>.
        step 2: Add the fresh char to the dictionary with frequencyCount = 1
        step 3: Repeating char should be incremented by frequencyCount += 1 and so on.
        */
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach(char c in input.ToLower().Trim())
        {
            if (dict.TryGetValue(c, out int count))
            {
                dict[c] = count + 1;
            }
            else
            {
                dict[c] = 1;
            }
        }
        return dict;
    }

     public static HashSet<int> RemoveDuplicates()
    {
        List<int> arr = new List<int>{1, 2, 3, 2, 4, 1, 5 };
        HashSet<int> hashArray = [.. arr];
        return hashArray;
    }
}
