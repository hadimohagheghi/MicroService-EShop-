using ProductService.Model.Dto;

namespace ProductService.Model.Services.Interface
{
    public interface IProductService
    {
        List<ProductDto> GetProductList();
        ProductDto GetProduct(Guid Id);
        void AddNewProduct(AddNewProductDto addNewProduct);
    }
}
