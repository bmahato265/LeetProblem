interface IA
{
    void Show();
}
interface IB
{
    void Show();
}
class ConcreteC: IA, IB
{
    public void Show()
    {
        Console.WriteLine("Executed");
    }
    public static void Main(string[] args)
    {
        ConcreteC c = new ConcreteC();
        c.Show();
    }
}