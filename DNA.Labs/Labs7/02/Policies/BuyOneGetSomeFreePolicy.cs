namespace DNA.Labs.Labs7._02.Policies;

public class BuyOneGetSomeFreePolicy : IExtraItemPolicy
{
    private readonly HashSet<ExtraItem> _extraProducts;

    public BuyOneGetSomeFreePolicy()
    {
        _extraProducts = new HashSet<ExtraItem>();
    }
    
    public List<Item> GetExtraItemFor(Item item)
    {
        return _extraProducts.Where(x => x.For.Id == item.Id).Select(x => x.Free).ToList();
    }

    public void AddNewExtraItem(ExtraItem extraItem)
    {
        _extraProducts.Add(extraItem);
    }
}