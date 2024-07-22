namespace DNA.Labs.Labs7._02;

public class Item
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public static Item CreateItem(string name)
        => new Item(Guid.NewGuid(), name);
    
    private Item(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}