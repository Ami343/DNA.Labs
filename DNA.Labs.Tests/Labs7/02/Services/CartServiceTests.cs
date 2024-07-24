using DNA.Labs.Labs7._02;
using DNA.Labs.Labs7._02.Policies;
using DNA.Labs.Labs7._02.Repositories;
using DNA.Labs.Labs7._02.Services;

namespace DNA.Labs.Tests.Labs7._02.Services;

public class CartServiceTests
{
    private CartService _sut;
    private ICartRepository _cartRepositoryMock;
    private IExtraItemPolicy _extraItemPolicyMock;

    [Fact]
    public void GivenAddItem_WhenCalled_ThenAddsItemToCart()
    {
        // Arrange
        SetupSUT();

        // Act
        _sut.AddItem(_mercedesItem, _cart.Id);

        // Assert 
        Assert.Contains(_cart.Items, x => x.Id == _mercedesItem.Id);
    }

    [Fact]
    public void GivenRemoveItem_WhenCalled_ThenRemovesItemFromCart()
    {
        // Arrange
        SetupSUT();
        _sut.AddItem(_mercedesItem, _cart.Id);

        // Act
        _sut.RemoveItem(_mercedesItem, _cart.Id);

        // Assert 
        Assert.DoesNotContain(_cart.Items, x => x.Id == _mercedesItem.Id);
    }

    [Fact]
    public void GivenAddItem_WhenCalledAndHasExtraItemPolicy_ThenAddsItemAndAddFreeItem()
    {
        // Arrange
        SetupSUT();
        SeedExtraItemPolicy();

        // Act
        _sut.AddItem(_mercedesItem, _cart.Id);

        // Assert 
        Assert.Contains(_cart.Items, x => x.Id == _mercedesItem.Id);
        Assert.Contains(_cart.FreeItems, x => x.Id == _freeItem.Id);
    }

    [Fact]
    public void GivenRemoveItem_WhenCalledAndHasExtraItemPolicy_ThenRemovesItemAndRemovesFreeItem()
    {
        // Arrange
        SetupSUT();
        SeedExtraItemPolicy();
        _sut.AddItem(_mercedesItem, _cart.Id);

        // Act
        _sut.RemoveItem(_mercedesItem, _cart.Id);

        // Assert 
        Assert.DoesNotContain(_cart.Items, x => x.Id == _mercedesItem.Id);
        Assert.DoesNotContain(_cart.FreeItems, x => x.Id == _freeItem.Id);
    }

    private void SetupSUT()
    {
        _cartRepositoryMock = new CartRepository();
        _extraItemPolicyMock = new BuyOneGetSomeFreePolicy();
        _sut = new CartService(_cartRepositoryMock, _extraItemPolicyMock);

        SeedCart();
    }

    private readonly Cart _cart = Cart.CreateCart();

    private readonly Item _mercedesItem = Item.CreateItem("Mercedes CLE 200 AMG");
    private readonly Item _freeItem = Item.CreateItem("BMW Series 4 420i");

    private void SeedCart()
    {
        _cartRepositoryMock.InsertCart(_cart);
    }

    private void SeedExtraItemPolicy()
    {
        _extraItemPolicyMock.AddNewExtraItem(new ExtraItem(_mercedesItem, _freeItem));
    }
}