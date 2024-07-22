using System.Net.Sockets;
using DNA.Labs.Labs7._02.Events;
using DNA.Labs.Labs7._02.SharedKernel;

namespace DNA.Labs.Labs7._02;

public class Cart : AggregateRoot
{
    public Guid Id { get; private set; }
    public ICollection<Item> Items { get; private set; }
    
    public ICollection<Item> RemovedItems { get; private set; }
    
    public static Cart CreateCart() => new(Guid.NewGuid());

    private Cart(Guid id)
    {
        Id = id;
        Items = new List<Item>();
        RemovedItems = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
        
        AddDomainEvent(new ItemAddedToCartEvent(this));
    }

    public Result AddBackFreeItem(Item item)
    {
        if (FreeItemWasIntentionallyRemoved(item))
        {
            AddItem(item);
            return Result.Success();
        }

        return Result.Failure("Error");
    }

    public Result RemoveItem(Item item)
    {
        if (!Items.Remove(item)) return Result.Failure("Error");
        
        AddDomainEvent(new ItemRemovedFromCartEvent(this));
        
        return Result.Success();
    }

    public Result RemoveFreeItemIntentionally(Item item)
    {
        var result = RemoveItem(item);

        if (result.IsSuccess && !FreeItemWasIntentionallyRemoved(item))
        {
            RemovedItems.Add(item);
        }

        return result;
    }

    private bool FreeItemWasIntentionallyRemoved(Item item)
        => RemovedItems.Any(x => x.Id == item.Id);
}