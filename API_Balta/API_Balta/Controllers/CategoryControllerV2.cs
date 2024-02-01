using API_Balta.Data;
using API_Balta.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Balta.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class CategoryControllerV2 : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CategoryControllerV2(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("/api/GetAllCategories")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _dataContext.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost]
        [Route("/api/AddCategory")]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Categories.ToListAsync());
        }
    }
}
