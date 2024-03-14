using JsonWebToken.Dtos;
using JsonWebToken.Entity;
using JsonWebToken.Interfaces;

namespace JsonWebToken.Services
{
    public class ProductService : IProductService
    {
        private static readonly List<Product> products = new()
        {
            new (){Id=1,Name="Iphone 15",Quantity=50,Price=50000,CreatedDate=DateTime.Now},
            new (){Id=2,Name="Samsung Galaxy S23",Quantity=100,Price=40000,CreatedDate=DateTime.Now},
            new() {Id=3,Name="Huawei P10 Pro",Quantity=120,Price=20000,CreatedDate=DateTime.Now},
        };

        public Task<List<ProductResponse>> GetProductAsync()
        {
            var productList = products.Select(s => new ProductResponse { Name = s.Name }).ToList();

            return Task.FromResult(productList);
        }

        public Task<ProductQuantityResponse> GetProductQuantityAsync(ProductQuantityRequest request)
        {
            var productQuantity = products.FirstOrDefault(f => f.Id == request.Id);

            ProductQuantityResponse productQuantityResponse = new ProductQuantityResponse()
            {
                Name = productQuantity.Name,
                Quantity = productQuantity.Quantity,
            };

            return Task.FromResult(productQuantityResponse);
        }
    }
}
