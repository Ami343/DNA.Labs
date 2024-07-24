using System.Collections.Concurrent;
using DNA.Labs.Labs7._02.SharedKernel;

namespace DNA.Labs.Labs7._02.Repositories;

public interface ICartRepository
{
    void InsertCart(Cart cart);
    Maybe<Cart> GetCart(Guid id);
}