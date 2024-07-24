using DNA.Labs.Labs7._02.Repositories;
using DNA.Labs.Labs7._02.Services.Interfaces;

namespace DNA.Labs.Labs7._02.Services;

public class CartFreeItemService : BaseCartService, ICartFreeItemService
{
    public CartFreeItemService(ICartRepository cartRepository)
        : base(cartRepository)
    {
    }

    public void IntentionallyRemoveFreeItem(Item item, Guid cartId)
    {
        var cart = GetCartIfExist(cartId);

        cart.RemoveFreeItemIntentionally(item);
    }

    public void AddBackFreeItem(Item item, Guid cartId)
    {
        var cart = GetCartIfExist(cartId);

        cart.AddBackFreeItem(item);
    }
}