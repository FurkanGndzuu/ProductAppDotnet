using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Product.Api.Abstractions;
using Product.Api.Dtos;
using Product.Api.Models.Contexts;
using Product.Api.Models.Entities;

namespace Product.Api.Services
{
    public class ProductService : IProductService
    {
        private ProductDbContext _context;

        public ProductService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProduct(ProductDto productDto)
        {
            Models.Entities.Product product = new()
            {
                Description = productDto.Description,
                Name = productDto.Name,
                Price = productDto.Price,   
            };

           var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id.ToString().Equals(productDto.CategoryId));

            if(category is not null) product.CategoryId = category.Id;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;

        }

        public IQueryable<Models.Entities.Product> GetAllCategories() => _context.Products.Where(x => true).AsQueryable();

        public IQueryable<Models.Entities.Product> GetCategorieById(int Id) => _context.Products.Where(x => x.Id.Equals(Id)).AsQueryable();


        public async Task<bool> RemoveProduct(int pId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == pId);
            if (product == null) throw new ArgumentNullException(nameof(pId));
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateProduct(int Id, ProductDto productDto)
        {
            productDto.Id = Id;

            _context.Entry(productDto).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

       
    }
}
