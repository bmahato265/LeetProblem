using Microsoft.VisualBasic;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> nums = new List<int>{0,1,2,3,4,5,6,7,9};
        int targetValue = 9;
        var result = GetTargetPairs(nums, targetValue);
        foreach(KeyValuePair<int, int> dict in result)
        {
            Console.WriteLine($"[{dict.Key}, {dict.Value}]");
        }
    }
    public static Dictionary<int, int> GetTargetPairs(List<int> nums, int targetValue)
    {
        Dictionary<int, int> pairs = new Dictionary<int, int>();
        int i = 0;
        while(i < nums.Count)
        {
            int nextPair = targetValue - nums[i];
            int indexAt = nums.IndexOf(nextPair);
            if (indexAt > -1 && nums[i] < nums[indexAt])
            {
                pairs.Add(nums[i], nums[indexAt]);
            }
            i++;
        }
        return pairs;
    }
}