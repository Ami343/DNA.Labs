using DNA.Labs.Labs7._02;
using DNA.Labs.Labs7._02.Policies;
using DNA.Labs.Labs7._02.Repositories;
using DNA.Labs.Labs7._02.Services;

namespace DNA.Labs.Tests.Labs7._02.Services;

public class CartFreeItemServiceTests
{
    private CartFreeItemService _sut;
    private ICartRepository _cartRepositoryMock;
    private IExtraItemPolicy _extraItemPolicyMock;

    [Fact]
    public void GivenIntentionallyRemoveFreeItem_WhenCalled_ThenRemovesItemFromCart()
    {
        // Arrange
        SetupSUT();
        SeedItem();

        // Act
        _sut.IntentionallyRemoveFreeItem(_freeItem, _cart.Id);

        // Assert 
        Assert.Contains(_cart.Items, x => x.Id == _mercedesItem.Id);
        Assert.DoesNotContain(_cart.FreeItems, x => x.Id == _freeItem.Id);
    }

    [Fact]
    public void GivenAddBackFreeItem_WhenCalled_ThenAddsBackFreeItemToCart()
    {
        // Arrange
        SetupSUT();
        SeedItem();

        _sut.IntentionallyRemoveFreeItem(_mercedesItem, _cart.Id);

        // Act
        _sut.AddBackFreeItem(_mercedesItem, _cart.Id);

        // Assert 
        Assert.Contains(_cart.Items, x => x.Id == _mercedesItem.Id);
        Assert.Contains(_cart.FreeItems, x => x.Id == _freeItem.Id);
    }

    private void SetupSUT()
    {
        _cartRepositoryMock = new CartRepository();
        _sut = new CartFreeItemService(_cartRepositoryMock);

        SeedCart();
    }

    private readonly Cart _cart = Cart.CreateCart();

    private readonly Item _mercedesItem = Item.CreateItem("Mercedes CLE 200 AMG");
    private readonly Item _freeItem = Item.CreateItem("BMW Series 4 420i");

    private void SeedCart()
    {
        _cartRepositoryMock.InsertCart(_cart);
    }
    
    private void SeedItem()
    {
        _cart.AddItem(_mercedesItem, new BuyOneGetSomeFreePolicy());
    }
}