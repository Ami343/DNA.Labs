using System.Collections.Concurrent;
using DNA.Labs.Labs7._02.SharedKernel;

namespace DNA.Labs.Labs7._02.Repositories;

public class CartRepository : ICartRepository
{
    private readonly ConcurrentDictionary<Guid, Cart> _carts;

    public CartRepository()
    {
        _carts = new ConcurrentDictionary<Guid, Cart>();
    }

    public void InsertCart(Cart cart)
    {
        if (_carts.ContainsKey(cart.Id)) throw new InvalidOperationException("Item already exist.");

        _carts.TryAdd(cart.Id, cart);
    }

    public Maybe<Cart> GetCart(Guid id)
    {
        if (_carts.TryGetValue(id, out var fetchedCart))
            return Maybe<Cart>.From(fetchedCart);

        return Maybe<Cart>.None;
    }
}