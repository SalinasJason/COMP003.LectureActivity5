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


        // POST: api/products
        // This endpoint creates a new product.
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            // Find the maximum ID in the existing products and assign a new ID (max+1) to the new product
            product.Id = ProductStore.Products.Max(p => p.Id) + 1;
            // Add the new product to the ProductStore
            ProductStore.Products.Add(product);

            // Return a 201 Created response with the location of the new product
            return CreatedAtAction(nameof(GetProduct), new {id = product.Id }, product);
        }

        // PUT: api/products/{id}
        // This endpoint updates an existing product.
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            // Check if the product with the specified ID exists
            var existingProduct = ProductStore.Products.FirstOrDefault(p =>p.Id == id);

            // if the product is not found, return a 404 Not Found response
            if (existingProduct is null)
                return NotFound();

            // Update the existing product's properties with the new values
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            // Return a 204 No Content response to indicate success
            return NoContent();
        }

    }
}
