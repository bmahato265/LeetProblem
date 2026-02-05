public class Animal
{
    public readonly string _animalName;
    public Animal(string name)
    {
        _animalName = name;
    }
    public void Sleep()
    {
        Console.WriteLine($"{_animalName} sleeps.");
    }
}
public class Bird
{
    public void Fly()
    {
        Console.WriteLine("All birds fly");
    }
}
//Single Inheritance
public class Dog: Animal
{

    public Dog(string name) : base(name){
    }
    public void Bark()
    {
    Console.WriteLine($"{base._animalName} barks");
        base.Sleep();

    }
}

class Program
{
    public static void Main(string[] args)
    {
        Dog dog = new Dog("Maggie");
        dog.Sleep();
        dog.Bark();
    }
}