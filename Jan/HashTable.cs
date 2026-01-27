class HashTable
{
    private readonly int size;
    private List<KeyValuePair<int, string>>[] table;
    public HashTable(int size)
    {
        this.size = size;
        table = new List<KeyValuePair<int, string>>[size];
        for(int i=0; i<size; i++)
        {
            table[i] = new List<KeyValuePair<int, string>>();
        }
    }
    private int HashFunction(int key)
    {
        return key % size;
    }
    private void Insert(int key, string value)
    {
        int index = HashFunction(key);
        table[index].Add(new KeyValuePair<int, string>(key, value));
    }
    public string Search(int key)
    {
        int index = HashFunction(key);
        foreach(var pair in table[index])
        {
            if(pair.Key == key)
            return pair.Value;
        }
        return null;
    }
    public static void Main(string[] args)
    {
        HashTable ht = new HashTable(5);
        ht.Insert(1, "Apple");
        ht.Insert(2, "Orange");
        ht.Insert(6, "Kiwi");

        Console.WriteLine(ht.Search(1));
        Console.WriteLine(ht.Search(2));
        Console.WriteLine(ht.Search(6));

    }
}