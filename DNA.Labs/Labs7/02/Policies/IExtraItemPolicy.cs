namespace DNA.Labs.Labs7._02.Policies;

public interface IExtraItemPolicy
{
    List<Item> GetExtraItemFor(Item item);
    void AddNewExtraItem(ExtraItem extraItem);
}