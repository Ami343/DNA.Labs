namespace DNA.Labs.Labs7._02.Events;

public sealed class ItemAddedToCartEvent : IDomainEvent
{
    public Cart Cart { get; }

    internal ItemAddedToCartEvent(Cart cart) => Cart = cart;
}