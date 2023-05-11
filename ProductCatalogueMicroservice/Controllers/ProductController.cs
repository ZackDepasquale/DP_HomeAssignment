using Microsoft.AspNetCore.Mvc;
using ProductCatalogueMicroservice.Services;
using System.Threading.Tasks;

namespace ProductCatalogueMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string category)
        {
            var products = await _productService.GetProductsByCategory(category);

            if (products != null)
            {
                return Ok(products);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }
    }
}
