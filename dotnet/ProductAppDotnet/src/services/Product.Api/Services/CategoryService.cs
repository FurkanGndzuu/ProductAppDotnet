using Microsoft.EntityFrameworkCore;
using Product.Api.Abstractions;
using Product.Api.Dtos;
using Product.Api.Models.Contexts;
using Product.Api.Models.Entities;

namespace Product.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private ProductDbContext _context { get; set; }

        public CategoryService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategory(CategoryDTO categoryDTO)
        {
            Category category = new()
            {
                Name = categoryDTO.Name,
            };

           await _context.Categories.AddAsync(category);  
            await _context.SaveChangesAsync();
            return true;

        }

        public IQueryable<Category> GetAllCategories() => _context.Categories.Where(x => true);

        public IQueryable<Category> GetCategorieById(int Id) => _context.Categories.Where(x => x.Id.Equals(Id));

        public async Task<bool> RemoveCategory(int categoryId)
        {
           var catgory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
            if(catgory == null) throw new ArgumentNullException(nameof(categoryId));
            _context.Categories.Remove(catgory);
           await _context.SaveChangesAsync();
            return true;
        }
    }
}
