namespace ItemManagement;

public abstract class Container
{
    private List<Item> _items;

    protected Container()
    {
        _items = new List<Item>();
    }

    public abstract void TakeItem(Item item, int amount = 1);
    public abstract void PlaceItem(Item item, int amount = 1);
    
    public virtual void ShowAllItems()
    {
        if (_items.Count <= 0)
        {
            Console.WriteLine($"There is no items");
            return;
        }
        
        for (int i = 0; i < _items.Count; i++)
        {
            var item = _items[i];
            Console.Write($"=> [item id:{item.Id}] {item.GetName()} (Count: {item.GetCount()}) | ");
        }
        
        Console.WriteLine();
    }

    public void AddItem(Item item)
    {
        if (_items.Contains(item)) return;
        
        _items.Add(item);
    }

    protected void RemoveItem(Item item)
    {
        if (_items.Contains(item) == false) return;
        
        _items.Remove(item);
    }
    
    public List<Item> GetItems()
    {
        return _items;
    }

    ~Container()
    {
        _items = null;
    }
}