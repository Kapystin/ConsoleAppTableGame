namespace ItemManagement.Items;

public class Coins : Item
{
    public override int Id => 3;
    
    public Coins(string name, int count = 1) : base(name, count)
    {
    }
}