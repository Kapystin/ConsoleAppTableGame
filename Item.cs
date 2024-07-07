namespace ItemManagement;

public abstract class Item
{
    public abstract int Id
    {
        get;
    }
    
    private readonly string _name;
    private int _count;
    
    protected Item(string name, int count)
    {
        _name = name;
        _count = count;
    }
    
    public string GetName()
    {
        return _name;
    }

    public int GetCount()
    {
        return _count;
    }

    public void SetCount(int value)
    {
        _count = value;
    }
}