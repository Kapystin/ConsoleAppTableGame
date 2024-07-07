namespace ItemManagement;

public static class Utils
{
    public static T? GetItemByItemId<T>(int id, List<T> items) where T : Item
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (id != items[i].Id) continue;

            return items[i];
        }

        return default;
    }

    public static T? GetItemByName<T>(string name, List<T> items) where T : Item
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (name.Equals(items[i].GetName().ToLower().Trim()) == false) continue;

            return items[i];
        }

        return default;
    }
}