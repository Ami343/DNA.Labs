namespace DNA.Labs.Labs7._02.Policies;

public class ExtraItem
{
    public Item For { get; private set; }
    public Item Free { get; private set; }
    
    public ExtraItem(Item @for, Item free)
    {
        For = @for;
        Free = free;
    }
}