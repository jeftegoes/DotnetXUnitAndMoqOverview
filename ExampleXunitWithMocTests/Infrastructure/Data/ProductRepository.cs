using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;

        }

        public async Task<Product> GetProductByIdAsync(int id)
            => await _storeContext.Product.FindAsync(id);

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
            => await _storeContext.Product.ToListAsync();
    }
}