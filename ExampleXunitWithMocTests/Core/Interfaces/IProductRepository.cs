using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Product Add(Product product);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);

    }
}