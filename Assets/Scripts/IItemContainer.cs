

public interface IItemContainer 
{

    bool CanAddItem(Item item, int amount = 1);
    Item RemoveItem(string itemID);
    bool RemoveItem(Item item);
    bool AddItem(Item item);
    bool IsFull();
    bool ContainsItem(Item item);
    int ItemCount(Item item);
}
