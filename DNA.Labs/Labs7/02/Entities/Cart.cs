using DNA.Labs.Labs7._02.Events;
using DNA.Labs.Labs7._02.Policies;
using DNA.Labs.Labs7._02.SharedKernel;

namespace DNA.Labs.Labs7._02;

public class Cart : AggregateRoot
{
    public Guid Id { get; private set; }
    public ICollection<Item> Items { get; private set; }
    
    public ICollection<Item> FreeItems { get; private set; }
    
    public ICollection<Item> IntentionallyRemovedItems { get; private set; }
    
    public static Cart CreateCart() => new(Guid.NewGuid());

    private Cart(Guid id)
    {
        Id = id;
        Items = new List<Item>();
        FreeItems = new List<Item>();
    }

    public void AddItem(Item item, IExtraItemPolicy extraItemPolicy)
    {
        Items.Add(item);

        extraItemPolicy.GetExtraItemFor(item).ForEach(freeItem => FreeItems.Add(freeItem));

        AddDomainEvent(new ItemAddedToCartEvent(this));
    }

    public Result AddBackFreeItem(Item item)
    {
        if (!WasItemIntentionallyRemoved(item)) return Result.Failure("Error");
        
        FreeItems.Add(item);
        IntentionallyRemovedItems.Remove(item);

        AddDomainEvent(new FreeItemAddedBackToCartEvent(this));

        return Result.Success();
    }

    public Result RemoveItem(Item item, IExtraItemPolicy extraItemPolicy)
    {
        if (!Items.Remove(item)) return Result.Failure("Error");
        
        extraItemPolicy.GetExtraItemFor(item).ForEach(freeItem => FreeItems.Remove(freeItem));

        AddDomainEvent(new ItemRemovedFromCartEvent(this));
        
        return Result.Success();
    }

    public Result RemoveFreeItemIntentionally(Item item)
    {
        if (!FreeItems.Remove(item)) return Result.Failure("Error");

        IntentionallyRemovedItems.Add(item);
        
        AddDomainEvent(new FreeItemRemovedFromCartEvent(this));

        return Result.Success();
    }

    private bool WasItemIntentionallyRemoved(Item item)
        => IntentionallyRemovedItems.Any(x => x.Id == item.Id);
}