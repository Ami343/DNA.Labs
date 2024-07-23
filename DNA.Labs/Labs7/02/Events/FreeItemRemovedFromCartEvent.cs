namespace DNA.Labs.Labs7._02.Events;

public sealed class FreeItemRemovedFromCartEvent : IDomainEvent
{
    public Cart Cart { get; }

    internal FreeItemRemovedFromCartEvent(Cart cart) => Cart = cart;
}