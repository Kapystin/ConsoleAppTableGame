namespace ItemManagement.Items;

public class Amulet : Item
{
    public override int Id => 1;
    
    public Amulet(string name, int count = 1) : base(name, count)
    {
    }
}