using Product.Api.Dtos;
using Product.Api.Models.Entities;

namespace Product.Api.Abstractions
{
    public interface IProductService
    {
        IQueryable<Models.Entities.Product> GetAllCategories();
        IQueryable<Models.Entities.Product> GetCategorieById(int Id);
        Task<bool> RemoveProduct(int categoryId);

        Task<bool> CreateProduct(ProductDto productDto);
        Task UpdateProduct(int Id , ProductDto productDto);
    }
}
