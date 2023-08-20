using CRUD_Demo_Api.Model;
using CRUD_Demo_Api.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Demo_Api.Controllers
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
        [HttpGet]
        public async Task<ActionResult<List<Product>>>GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>GetProductById(int id)
        {
            var result = await _productService.GetProductById(id);
            if (result == null)
                return NotFound("Hero Not Found");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            var result = await _productService.AddProduct(product);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>>UpdateProduct(int id, Product request)
        {
            var result = await _productService.UpdateProduct(id, request);
            if (result == null)
                return NotFound("Hero Not Found");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result == null)
                return NotFound("Hero Not Found");
            return Ok(result);
        }
    }
}
