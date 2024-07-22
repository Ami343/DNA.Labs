using DNA.Labs.Labs7._02.SharedKernel;

namespace DNA.Labs.Labs7._02.Services;

public interface ICartService
{
    void AddCart(Cart cart);
    Maybe<Cart> GetCart(Guid cartId);
    void AddItem(Item item, Guid cartId);
    void RemoveItem(Item item, Guid cartId);
    void IntentionallyRemoveFreeItem(Item item, Guid cartId);
    void AddBackFreeItem(Item item, Guid cartId);
}