using COMP003.LectureActivity5.Data;
using COMP003.LectureActivity5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003.LectureActivity5.Controllers
{
    // This controller handles product-related API requests.
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: api/products
        // This endpoint retrieves all products.
        [HttpGet]
        public ActionResult<List<ProductsController>> GetProducts()
        {
            // returns all products from the ProductStore
            return Ok(ProductStore.Products);
        }

        // GET: api/products/{id}
        // This endpoint retrieves a specific product by its ID.
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            // Find the product with the specifed ID
            var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);

            // if the product is not found, return a 404 Not Found response
            if (product == null)
                return NotFound();

            // if the product is found, return it with a 200 OK respone
            return Ok(product);
        }

    }
}
