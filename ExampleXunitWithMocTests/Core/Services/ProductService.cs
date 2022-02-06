using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}