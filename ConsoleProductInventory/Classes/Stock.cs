using System.Text;

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
            CommonCost += product.Price * product.Count;
        }
    }

    public bool Remove(int index)
    {
        Product? product = GetProduct(index);

        if (product == null) return false;

        Remove(product);

        ComputeCommonCost();

        return true;
    }
    public bool Remove(Product product)
    {
        if (!Contains(product)) return false;

        Products.Remove(product);

        ComputeCommonCost();

        return true;
    }

    public void RemoveRange(List<Product> products)
    {
        foreach (var product in products)
        {
            Remove(product);
        }

        ComputeCommonCost();
    }

    public bool Add(Product product)
    {
        if (Contains(product)) return false;

        Products.Add(product);

        ComputeCommonCost();

        return true;
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

    public bool Contains(int id)
    {
        foreach (var product in Products)
        {
            if (product.Id == id) return true;
        }

        return false;
    }

    public Product? GetProduct(int index)
    {
        foreach(var product in Products)
        {
            if (product.Id == index) 
                return product;
        }

        return null;
    }

    public string GetProductList() 
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < Products.Count; i++)
        {
            result.AppendLine($"{Products[i].Id}: Наименование - {Products[i].Name}, цена - {Products[i].Price}, количество - {Products[i].Count}");
        }

        result.AppendLine($"\nОбщая стоимость товаров - {CommonCost}");

        return result.ToString();
    }
}
