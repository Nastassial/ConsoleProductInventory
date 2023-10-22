namespace ConsoleProductInventory.Classes;

internal class Product
{
    private readonly string _id;
    private decimal _price;
    private int _count;

    public string Name { get => _id; }
    public decimal Price { get => _price; set => _price = value; }
    public int Count { get => _count; set => _count = value; }

    public Product(string id) => _id = id;

    public Product(string id, decimal price) : this(id) => Price = price;

    public Product(string id, decimal price, int count) : this(id, price) => Count = count;

    public bool Remove(int count)
    {
        if (count <= 0) return false;

        if (Count > count) 
            Count -= count;

        return true;
    }

    public bool Add(int count)
    {
        if (count <= 0) return false;

        Count += count;

        return true;
    }
}
