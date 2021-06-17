

public interface IItemContainer 
{
    Item RemoveItem(string itemID);
    bool RemoveItem(Item item);
    bool AddItem(Item item);
    bool IsFull();
    bool ContainsItem(Item item);
    int ItemCount(Item item);
}
