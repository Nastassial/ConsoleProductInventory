namespace ConsoleProductInventory.Classes;

internal class Product
{
    private readonly int _id;
    private readonly string _name;
    private decimal _price;

    public int Id { get => _id; }
    public string Name { get => _name; }
    public decimal Price { get => _price; }
    public int Count { get; private set; }

    public Product(int id, string name)
    {  
        _id = id; 
        _name = name;
    }

    public Product(int id, string name, decimal price) : this(id, name) => _price = price;

    public Product(int id, string name, decimal price, int count) : this(id, name, price) => Count = count;

    public bool Remove(int count)
    {
        if (count <= 0 || Count < count) return false;

        Count -= count;

        return true;
    }

    public bool Add(int count)
    {
        if (count < 0) return false;

        Count += count;

        return true;
    }
}
