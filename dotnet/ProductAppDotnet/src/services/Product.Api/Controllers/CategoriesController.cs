using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Product.Api.Abstractions;
using Product.Api.Dtos;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [EnableQuery]
        public IActionResult Get() => Ok(_categoryService.GetAllCategories());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO category) => Ok(await _categoryService.CreateCategory(category));
    }
}
