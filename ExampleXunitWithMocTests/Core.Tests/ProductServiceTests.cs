using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Moq;
using Xunit;

namespace Core.Tests;

public class ProductServiceTests
{

    [Fact]
    public void ShouldReturnProducts()
    {
        var productService = Mock.Of<IProductService>();
        var productRepository = Mock.Of<IProductRepository>();
        var storeContext = Mock.Of<StoreContext>();

        var product = new Product("Name Test", "Description Test", 10);

        var productInDB = productService.Add(product);

        Assert.NotNull(productInDB);
        Assert.IsType<Product>(productInDB);
        Assert.Equal(productInDB.Name, product.Name);
    }

    [Fact]
    public void ShouldReturnProductById()
    {

    }

    [Fact]
    public void ShouldAddNewProduct()
    {

    }
}