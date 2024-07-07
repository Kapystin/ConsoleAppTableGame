using System.Reflection;

namespace ItemManagement;

public class Inventory : Container
{
    public override void ShowAllItems()
    {
        Console.WriteLine($"You look at inventory and see:");
        base.ShowAllItems();
    }
    
    public override void TakeItem(Item item, int amount = 1)
    {
        var foundItem = GetItems().Find(x => x.Id == item.Id);

        if (foundItem == null)
        {
            Console.WriteLine($"There's no such item [{item.GetName()}] in inventory");
            return;
        }

        var currentCount = foundItem.GetCount();
        currentCount -= amount;

        if (currentCount <= 0)
        {
            RemoveItem(foundItem);
        }
        else
        {
            foundItem.SetCount(currentCount);
        }
        
        Console.WriteLine($"You took the item [{foundItem.GetName()}] in the amount {amount} from the inventory");
    }

    public override void PlaceItem(Item item, int amount = 1)
    {
        var foundItem = GetItems().Find(x => x.Id == item.Id);
        
        if (foundItem == null)
        {
            var newItem = Activator.CreateInstance(item.GetType(), item.GetName(), amount) as Item;
            AddItem(newItem);
            
            Console.WriteLine($"Item [{item.GetName()}] placed in inventory. Total: [{amount}]");
            return;
        }

        var currentCount = foundItem.GetCount();
        currentCount += amount;

        foundItem.SetCount(currentCount);
        
        Console.WriteLine($"Item [{item.GetName()}] placed in inventory. Total: [{item.GetCount()}]");
    }
}