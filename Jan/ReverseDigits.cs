using Microsoft.VisualBasic;

public class ReverseDigit
{
    public static void Main(string[] args)
    {
        int numbers = 12345;
        Console.WriteLine(CalculateReverseDigit(numbers));
    }
    public static int CalculateReverseDigit(int num)
    {
        //Lets given a originalDigit = 12345, reverse this digits as 54321.
       /*Approach:  Lets traverse from right to left. For this, we must create a revDigit ref and add one by 
       one digit from the original in reverse pattern. I use originalDigit % 10 to calculate the last one 
       and add it to the revDigit ref. Now originalDigit is refresh by originalDigit/10. Using this approach
       with while loop will solve the problem.
       Lets Start.
       */
       if (num <= 0) return 0;
       int revDigit = 0;
       while(num > 0)
        {
            //12345
             revDigit = revDigit * 10 + num % 10;
             num = num / 10;
        }
       return revDigit;//Output: 54321
    }
}