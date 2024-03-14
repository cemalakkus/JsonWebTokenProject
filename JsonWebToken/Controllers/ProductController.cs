using JsonWebToken.Dtos;
using JsonWebToken.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("GetProducts")]
        [AllowAnonymous]
        public async Task<ActionResult<List<ProductResponse>>> GetProduct()
        {
            var result = await _productService.GetProductAsync();

            return result;
        }

        [HttpPost("GetProductQuantity")]
        [Authorize]
        public async Task<ActionResult<ProductQuantityResponse>> GetProductQuantity([FromBody] ProductQuantityRequest request)
        {
            var result = await _productService.GetProductQuantityAsync(request);

            return result;
        }
    }
}
