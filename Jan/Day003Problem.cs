public class Program
{
    public static void Main(string[] args)
    {
        int n = 8;
        int result = SumOfSquares(n);
        Console.WriteLine($"The sum is: {result}");
    }
    public static int SumOfSquares(int n)
    {
        int sum = 0;
        for(int i=1; i<=n; i++)
        {
            sum = sum + i*i;
        }
        return sum;
    }
}