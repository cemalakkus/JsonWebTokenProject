using JsonWebToken.Dtos;

namespace JsonWebToken.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductResponse>> GetProductAsync();
        public Task<ProductQuantityResponse> GetProductQuantityAsync(ProductQuantityRequest request);
    }
}
