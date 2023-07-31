using Product.Api.Dtos;
using Product.Api.Models.Entities;

namespace Product.Api.Abstractions
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories();
        IQueryable<Category> GetCategorieById(int Id);
        Task<bool> RemoveCategory(int categoryId);
        Task<bool> CreateCategory(CategoryDTO categoryDTO);
    }
}
