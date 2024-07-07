namespace ItemManagement.Items;

public class Card : Item
{
    public Card(string name, int count) : base(name, count)
    {
    }

    public override int Id => 4;
}