namespace ConsoleProductInventory.Classes;

internal class Stock
{
    private static readonly List<Product> _emptyProductList = new List<Product>(0);

    private List<Product> Products;

    public int ProductTypesCount => Products.Count;

    public decimal CommonCost { get; private set; }

    public Stock()
    {
        Products = _emptyProductList;
        CommonCost = 0;
    }
    
    public Stock(List<Product> products) 
    {
        if (products == null) 
            Products = _emptyProductList;
        else
            Products = products;

        ComputeCommonCost();
    }

    private void ComputeCommonCost()
    {
        CommonCost = 0;

        foreach (var product in Products)
        {
            CommonCost += product.Price;
        }
    }

    public void Remove(int index)
    {
        Products.RemoveAt(index);

        ComputeCommonCost();
    }
    public void Remove(Product product)
    {
        Products.Remove(product);

        ComputeCommonCost();
    }

    public void RemoveRange(List<Product> products)
    {
        foreach (var product in products)
        {
            Products.Remove(product);
        }

        ComputeCommonCost();
    }

    public void Add(Product product)
    {
        Products.Add(product);

        ComputeCommonCost();
    }

    public void AddRange(List<Product> products)
    {
        Products.AddRange(products);

        ComputeCommonCost();
    }

    public void Clear()
    {
        Products.Clear();

        CommonCost = 0;
    }

    public bool Contains(Product product) => Products.Contains(product); 

    public bool Contains(string name)
    {
        foreach (var product in Products)
        {
            if (product.Name == name) return true;
        }

        return false;
    }

    public Product GetProduct(int index) => Products[index];

    public string GetProductList() 
    {
        string result = "";

        for (int i = 0; i < Products.Count; i++)
        {
            result += $"{i + 1}: Наименовение - {Products[i].Name}, цена - {Products[i].Price}, количество - {Products[i].Count}\n";
        }

        return result;
    }
}
