using ItemManagement.Items;

namespace ItemManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game start!");
            
            var isExit = false;
            var items = new List<Item>()
            {
                new Amulet("Amulet"), 
                new Book("Book"), 
                new Coins("Coins", 33)
            };
            
            var table = new Table();
            var inventory = new Inventory();

            foreach (var item in items)
            {
                table.AddItem(item);
            }
            
            items = null;

            do
            {
                Console.WriteLine($"====================================================");
                Console.Write($"Control legend:");
                Console.WriteLine($" write: [exit] or [close] => for close application");
                Console.WriteLine($"                write: [show all] or [sa] => for look at your inventory");
                Console.WriteLine($"                write: [show inventory] or [si] => for look at your inventory");
                Console.WriteLine($"                write: [show table] or [st] => for look at your inventory");
                Console.WriteLine($"                write: [take] => for take item from table");
                Console.WriteLine($"                write: [place] => for place item to table");

                Console.Write($"==> ");
                var input = Console.ReadLine()?.ToLower().Trim();
                
                switch (input)
                {
                    case "exit" or "close":
                        isExit = true;
                        break;
                    case "show all" or "sa":
                        table.ShowAllItems();
                        inventory.ShowAllItems();
                        break;
                    case "show inventory" or "si":
                        inventory.ShowAllItems();
                        break;
                    case "show table" or "st":
                        table.ShowAllItems();
                        break;
                    case "take":
                        TransferBetweenContainers(table, inventory);
                        break;
                    case "place":
                        TransferBetweenContainers(inventory, table);
                        break;
                    default:
                        Console.WriteLine($"Undefined command! Please enter command from legend below");
                        break;
                }
            } 
            while (isExit == false);
            
            Console.WriteLine($"Good Luck!");
        }

        private static void TransferBetweenContainers(Container containerA, Container containerB)
        {
            var amount = 1;
            
            containerA.ShowAllItems();
            Console.Write($"==> Enter name or id of item: ");
            var userInputLine = Console.ReadLine().ToLower().Trim();

            if (string.IsNullOrEmpty(userInputLine))
            {
                Console.WriteLine($"You enter empty value. Please try again");
                return;
            }
            
            var isId = int.TryParse(userInputLine, out int id);

            if (isId)
            {
                var itemById = Utils.GetItemByItemId(id, containerA.GetItems());

                if (itemById is null)
                {
                    Console.WriteLine($"There's no such item with [id:{id}]");
                    return;
                }

                amount = GetAmountOfItemToTake(itemById);
                
                containerA.TakeItem(itemById, amount);
                containerB.PlaceItem(itemById, amount);
                return;
            }
                        
            var itemByName = Utils.GetItemByName(userInputLine, containerA.GetItems());
                        
            if (itemByName is null)
            {
                Console.WriteLine($"There's no such item with [name: {userInputLine}]");
                return;
            }

            amount = GetAmountOfItemToTake(itemByName);
                        
            containerA.TakeItem(itemByName, amount);
            containerB.PlaceItem(itemByName, amount);
        }

        private static int GetAmountOfItemToTake(Item item)
        {
            var currentCount = item.GetCount();
            var amount = 1;
                
            if (currentCount > 1)
            {
                Console.WriteLine($"There are [{currentCount}] of item {item.GetName()}");
                Console.Write($"==> Enter amount of item you would like to take: ");
            
                var userInputLine = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrEmpty(userInputLine))
                {
                    Console.WriteLine($"You enter empty value. By default you will take [{amount}] {item.GetName()}");
                }
            
                if (int.TryParse(userInputLine, out var _amount))
                {
                    if (_amount > currentCount)
                    {
                        amount = currentCount;
                    }
                    else if (_amount <= 0)
                    {
                        amount = 1;
                        Console.WriteLine($"You enter invalid value [{_amount}]. By default you will take [{amount}] {item.GetName()}");
                    }
                    else
                    {
                        amount = _amount;
                    }
                }
                else
                {
                    Console.WriteLine($"You enter invalid value [{userInputLine}]. By default you will take [{amount}] {item.GetName()}");
                }
            }

            return amount;
        }
    }
}