using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public Task<IReadOnlyList<Product>> GetProductsAsync()
            => _productRepository.GetProductsAsync();

        public Task<Product> GetProductByIdAsync(int id)
            => _productRepository.GetProductByIdAsync(id);
    }
}