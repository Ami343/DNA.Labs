using DNA.Labs.Labs7._02.Repositories;

namespace DNA.Labs.Labs7._02.Services;

public abstract class BaseCartService
{
    private readonly ICartRepository _cartRepository;

    protected BaseCartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    protected Cart GetCartIfExist(Guid cartId)
    {
        var cart = _cartRepository.GetCart(cartId);

        if (cart.HasNoValue) throw new InvalidOperationException("");

        return cart.Value;
    }
}