using ProductService.Model.Dto;

namespace ProductService.Model.Services.Interface
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();
        void AddNewCategory(CategoryDto category);
    }
}
