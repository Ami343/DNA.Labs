namespace DNA.Labs.Labs7._02.Services.Interfaces;

public interface ICartFreeItemService
{
    void IntentionallyRemoveFreeItem(Item item, Guid cartId);
    void AddBackFreeItem(Item item, Guid cartId);
}