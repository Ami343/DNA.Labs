namespace DNA.Labs.Labs7._02.Events;

public sealed class ItemRemovedFromCartEvent : IDomainEvent
{
    public Cart Cart { get; }

    internal ItemRemovedFromCartEvent(Cart cart) => Cart = cart;
}