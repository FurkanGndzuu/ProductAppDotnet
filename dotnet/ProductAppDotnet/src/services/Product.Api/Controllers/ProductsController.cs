using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Product.Api.Abstractions;
using Product.Api.Dtos;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [EnableQuery(PageSize = 5)]
        public IActionResult Get() => Ok(_productService.GetAllCategories());

        [EnableQuery]
        public IActionResult Get([FromODataUri] int key) => Ok(_productService.GetCategorieById(key));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto) => Ok(await _productService.CreateProduct(productDto));

        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] ProductDto product) => Ok(_productService.UpdateProduct(key, product));

        [HttpDelete]
        public async Task<IActionResult> Delete(int key) => Ok(await _productService.RemoveProduct(key));

    }
}
