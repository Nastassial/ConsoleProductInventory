using System.Text;

namespace ConsoleProductInventory.Classes;

internal class Stock
{
    private List<Product> _products;

    public int ProductTypesCount => _products.Count;

    public decimal CommonCost { get; private set; }

    public Stock()
    {
        _products = new List<Product>(0);
        CommonCost = 0;
    }
    
    public Stock(List<Product> products) 
    {
        if (products == null)
            _products = new List<Product>(0);
        else
            _products = new List<Product>(products);

        ComputeCommonCost();
    }

    private void ComputeCommonCost()
    {
        CommonCost = 0;

        foreach (var product in _products)
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

        _products.Remove(product);

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

        _products.Add(product);

        ComputeCommonCost();

        return true;
    }

    public void AddRange(List<Product> products)
    {
        _products.AddRange(products);

        ComputeCommonCost();
    }

    public void Clear()
    {
        _products.Clear();

        CommonCost = 0;
    }

    public bool Contains(Product product) => _products.Contains(product); 

    public bool Contains(int id)
    {
        foreach (var product in _products)
        {
            if (product.Id == id) return true;
        }

        return false;
    }

    public Product? GetProduct(int index)
    {
        foreach(var product in _products)
        {
            if (product.Id == index) 
                return product;
        }

        return null;
    }

    public string GetProductList() 
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < _products.Count; i++)
        {
            result.AppendLine($"{_products[i].Id}: Наименование - {_products[i].Name}, цена - {_products[i].Price}, количество - {_products[i].Count}");
        }

        result.AppendLine($"\nОбщая стоимость товаров - {CommonCost}");

        return result.ToString();
    }
}
