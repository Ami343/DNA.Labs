using DNA.Labs.Labs7._02.Policies;
using DNA.Labs.Labs7._02.Repositories;
using DNA.Labs.Labs7._02.Services.Interfaces;
using DNA.Labs.Labs7._02.SharedKernel;

namespace DNA.Labs.Labs7._02.Services;

public class CartService : BaseCartService, ICartService
{
    private readonly IExtraItemPolicy _extraItemPolicy;

    public CartService(ICartRepository cartRepository, IExtraItemPolicy extraItemPolicy)
        : base(cartRepository)
    {
        _extraItemPolicy = extraItemPolicy;
    }

    public Maybe<Cart> GetCart(Guid cartId)
    {
        return GetCartIfExist(cartId);
    }

    public void AddItem(Item item, Guid cartId)
    {
        var cart = GetCartIfExist(cartId);

        cart.AddItem(item, _extraItemPolicy);
    }

    public void RemoveItem(Item item, Guid cartId)
    {
        var cart = GetCartIfExist(cartId);

        cart.RemoveItem(item, _extraItemPolicy);
    }
}