using DNA.Labs.Labs7._02.Repositories;
using DNA.Labs.Labs7._02.SharedKernel;

namespace DNA.Labs.Labs7._02.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService()
    {
        _cartRepository = new CartRepository();
    }

    public void AddCart(Cart cart)
    {
        _cartRepository.InsertCart(cart);
    }

    public Maybe<Cart> GetCart(Guid cartId)
    {
        return _cartRepository.GetCart(cartId);
    }

    public void AddItem(Item item, Guid cartId)
    {
        var cart = GetCartIfExist(cartId);
        
        cart.AddItem(item);
    }

    public void RemoveItem(Item item, Guid cartId)
    {
        var cart = GetCartIfExist(cartId);
        
        cart.RemoveItem(item);
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