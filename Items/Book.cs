namespace ItemManagement.Items;

public class Book : Item
{
    public override int Id => 2;
    
    public Book(string name, int count = 1) : base(name, count)
    {
    }
}