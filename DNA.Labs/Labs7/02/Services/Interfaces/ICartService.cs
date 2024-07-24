using DNA.Labs.Labs7._02.SharedKernel;

namespace DNA.Labs.Labs7._02.Services.Interfaces;

public interface ICartService
{
    Maybe<Cart> GetCart(Guid cartId);
    void AddItem(Item item, Guid cartId);
    void RemoveItem(Item item, Guid cartId);
}