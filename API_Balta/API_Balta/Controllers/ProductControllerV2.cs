using API_Balta.Data;
using API_Balta.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Balta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControllerV2 : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductControllerV2(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("/api/GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _dataContext.Products.Include(x => x.Category).ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        [Route("/api/AddProduct")]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var teste = product.CategoryId;
            product.Category = new Category();
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Products.ToListAsync());
        }
    }
}
