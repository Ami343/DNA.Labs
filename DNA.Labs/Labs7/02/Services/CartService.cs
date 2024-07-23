using DNA.Labs.Labs7._02.Policies;
using DNA.Labs.Labs7._02.Repositories;
using DNA.Labs.Labs7._02.SharedKernel;

namespace DNA.Labs.Labs7._02.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IExtraItemPolicy _extraItemPolicy;

    public CartService(ICartRepository cartRepository, IExtraItemPolicy extraItemPolicy)
    {
        _cartRepository = cartRepository;
        _extraItemPolicy = extraItemPolicy;
    }

    public Maybe<Cart> GetCart(Guid cartId)
    {
        return _cartRepository.GetCart(cartId);
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

    private Cart GetCartIfExist(Guid cartId)
    {
        var cart = _cartRepository.GetCart(cartId);

        if (cart.HasNoValue) throw new InvalidOperationException("");

        return cart.Value;
    }
}