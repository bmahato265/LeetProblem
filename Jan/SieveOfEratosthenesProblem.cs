using System.ComponentModel;

public class SieveOfEratosthenesProblem
{
    /*
    * Given a number n, find all prime numbers less than or equal to n.
    * We have multiple approach to solve this. The most naive approach is using for loop which will take 
    O(log n*n)) time and O(1) for space.
    * The best to solve this problem is using Sieve of Eratosthenes approach.
    */
    static void Main(string[] args)
    {
        Console.WriteLine(String.Join(",", SieveArray(10)));
       
    }
    static List<int> SieveArray(int n)
    {
        /*
        step 1: create a boolean array with all true values, true values will represent the prime numbers.
        step 2: Starting for p from 2, we calculate p*p <= n and marked them false as it is divisible by 
        other numbers. Ignore the 0 and 1 ( these are not primes)
        step 3: Ending the loops, we have an array with True values. Grab the index values and this is what 
        so called prime numbers
        */
        bool[] primes = new bool[n+1];
        for(int i=0; i<n+1; i++){
            primes[i]=true;
        }
        for(int p = 2; p*p < n+1; p++)
        {
            if (primes[p])
            {
                for(int i = p*p; i<n+1; i += p)
                {
                    Console.WriteLine($"i = {i}, p={p}");
                    /*
                    i = 4, p=2
                    i = 6, p=2
                    i = 8, p=2
                    i = 10, p=2
                    i = 9, p=3
                    [2,3,5,7]

                    Conclusion: The loop is started with 2 and incremented by 2 up to n. Set the bool prime
                    to false. Same for 3 and so on.
                    */
                    primes[i]=false;
                }
            }
        }
        List<int> primeNums = new List<int>();
        for(int i=2; i < n+1; i++)
        {
            if (primes[i])
            {
                primeNums.Add(i);
            }
        }
        return primeNums;
    }
}