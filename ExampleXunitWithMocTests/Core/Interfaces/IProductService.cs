using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Product Add(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}