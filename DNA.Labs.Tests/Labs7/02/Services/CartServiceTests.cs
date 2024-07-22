using DNA.Labs.Labs7._02;
using DNA.Labs.Labs7._02.Services;

namespace DNA.Labs.Tests.Labs7._02;

public class CartServiceTests
{
    private CartService _sut;

    [Fact]
    public void GivenAddItem_WhenCalled_ThenAddsItemToCart()
    {
        // Arrange
        SetupSUT();
        var cartId = SeedCart();
        var item = Item.CreateItem("Mercedes CLE 200 AMG");

        // Act
        _sut.AddItem(item, cartId);

        // Assert 
        var cart = _sut.GetCart(cartId);

        Assert.Contains(cart.Value.Items, x => x.Id == item.Id);
    }
    
    [Fact]
    public void GivenRemoveItem_WhenCalled_ThenRemovesItemFromCart()
    {
        // Arrange
        SetupSUT();
        var cartId = SeedCart();
        var item = Item.CreateItem("Mercedes CLE 200 AMG");
        _sut.AddItem(item, cartId);

        // Act
        _sut.RemoveItem(item, cartId);
        
        // Assert 
        var cart = _sut.GetCart(cartId);

        Assert.DoesNotContain(cart.Value.Items, x => x.Id == item.Id);
    }
    
    [Fact]
    public void GivenIntentionallyRemoveFreeItem_WhenCalled_ThenRemovesItemFromCart()
    {
        // Arrange
        SetupSUT();
        var cartId = SeedCart();
        var item = Item.CreateItem("Mercedes CLE 200 AMG");
        _sut.AddItem(item, cartId);

        // Act
        _sut.IntentionallyRemoveFreeItem(item, cartId);
        
        // Assert 
        var cart = _sut.GetCart(cartId);

        Assert.DoesNotContain(cart.Value.Items, x => x.Id == item.Id);
        Assert.Contains(cart.Value.RemovedItems, x => x.Id == item.Id);
    }
    
    [Fact]
    public void GivenAddBackFreeItem_WhenCalled_ThenAddsBackFreeItemToCart()
    {
        // Arrange
        SetupSUT();
        var cartId = SeedCart();
        var item = Item.CreateItem("Mercedes CLE 200 AMG");
        _sut.AddItem(item, cartId);
        _sut.IntentionallyRemoveFreeItem(item, cartId);

        // Act
        _sut.AddBackFreeItem(item, cartId);
        
        // Assert 
        var cart = _sut.GetCart(cartId);

        Assert.Contains(cart.Value.Items, x => x.Id == item.Id);
        Assert.Contains(cart.Value.RemovedItems, x => x.Id == item.Id);
    }

    private void SetupSUT()
    {
        _sut = new CartService();
    }

    private Guid SeedCart()
    {
        var cart = Cart.CreateCart();
        _sut.AddCart(cart);

        return cart.Id;
    }

}