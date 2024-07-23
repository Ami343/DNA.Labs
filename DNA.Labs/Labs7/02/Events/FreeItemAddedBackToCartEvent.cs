namespace DNA.Labs.Labs7._02.Events;

public class FreeItemAddedBackToCartEvent : IDomainEvent
{
    public Cart Cart { get; }

    internal FreeItemAddedBackToCartEvent(Cart cart) => Cart = cart;
}