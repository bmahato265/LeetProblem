/*
Title: K sized Subarray Maximum
Given an array arr[] of positive integers and an integer k. You have to find the maximum value for each 
contiguous subarray of size k. Return an array of maximum values corresponding to each contiguous subarray.
Example:
Input: arr[] = [1, 2, 3, 1, 4, 5, 2, 3, 6], k = 3
Output: [3, 3, 4, 5, 5, 5, 6]
Explanation: 
1st contiguous subarray [1, 2, 3], max = 3
2nd contiguous subarray [2, 3, 1], max = 3
3rd contiguous subarray [3, 1, 4], max = 4
4th contiguous subarray [1, 4, 5], max = 5
5th contiguous subarray [4, 5, 2], max = 5
6th contiguous subarray [5, 2, 3], max = 5
7th contiguous subarray [2, 3, 6], max = 6
Approach:
Step 1: Create contaguous block of size k in a loop
step 2: Condition to check the array end bound and its sizes.
step 2: Declare an array[int] that holds the max value of each contaguous block for each iterations.
Lets Start Coding...
*/
public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = [1, 2, 3, 1, 4, 5, 2, 3, 6];
        int k = 3;
        List<int> output = maxOfSubArrays(arr, k);
        // List<int> output = CalculateKSizedSubarray(arr, k);
        
        Console.WriteLine(String.Join(" ", output));
    }
    public static List<int> CalculateKSizedSubarray(int[] arr, int k)
    {
        /*
        arr.Length = 9, for i=6 and k=3 the loop must exit for array [1, 2, 3, 1, 4, 5, 2, 3, 6]
        hence, i<9-3+1 = 6<7 enter
        or for i = 7 => 7 < 9-3+1 => 7< 7 false
        */
        List<int> maxNumOfBlock = new List<int>();
        for(int i=0; i < arr.Length - k + 1; i++)
        {
            int[] tempArr = new int[k];
            tempArr = arr[i..(i+k)]; //small slice of an array
            // Array.Copy(arr, i, tempArr, i+k, k);
            maxNumOfBlock.Add(tempArr.Max());

        }
        return maxNumOfBlock;
    }
    public  static List<int> maxOfSubArrays(int[] arr, int k)
    {
        List<int> result = new List<int>();
        LinkedList<int> deque = new LinkedList<int>(); //stores indices
        for(int i = 0; i<arr.Length; i++)
        {
        //remove indices out of window
            if(deque.Count>0 && deque.First.Value <= i - k)
            {
                deque.RemoveFirst();
                
            }
            //remove smaller elements
            while(deque.Count>0 && arr[deque.Last.Value]< arr[i])
            {
                deque.RemoveLast();
            }
            
            deque.AddLast(i);

            
            // Add max for current window
            if (i >= k - 1)
                result.Add(arr[deque.First.Value]);
        }
        return result;
    }
}