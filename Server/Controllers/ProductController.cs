using Microsoft.AspNetCore.Mvc;
using BlazorEcommerce.Shared;
using BlazorEcommerce.Server.Data;



/* Here is the explanation for the code.
1. We defined the route and the controller name. 
2. We defined the DataContext class as _context.
3. We defined the constructor of ProductController and we passed the DataContext.
4. We created a method GetProducts to get the list of products.
We used the await keyword to wait for the request to finish and we set the result to Products.
Then, we returned the result as an OkObjectResult. OkObjectResult is a status code 200. */
namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };
            return Ok(response);
        }


    }
}


