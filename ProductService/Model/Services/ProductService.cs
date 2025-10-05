using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Contexts;
using ProductService.Model.Dto;
using ProductService.Model.Entities;
using ProductService.Model.Services.Interface;

namespace ProductService.Model.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDatabaseContext context;

        public ProductService(ProductDatabaseContext context)
        {
            this.context = context;
        }

        public void AddNewProduct(AddNewProductDto addNewProduct)
        {
            var category = context.Categories.Find(addNewProduct.CategoryId);
            if (category == null)
                throw new Exception("Category Not Found...!");
            Product product = new Product()
            {
                Category = category,
                Description = addNewProduct.Description,
                ImageUrl = addNewProduct.ImageUrl,
                Name = addNewProduct.Name,
                Price = addNewProduct.Price
            };
            context.Products.Add(product);
            context.SaveChanges();
        }

        public ProductDto GetProduct(Guid Id)
        {
            var product = context.Products.Include(p => p.Category)
               .SingleOrDefault(p => p.Id == Id);
            if (product == null)
                throw new Exception("Product Note Found...!");
            ProductDto data = new ProductDto()
            {
                Description = product.Description,
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                productCategory = new ProductCategoryDto
                {
                    Category = product.Category.Name,
                    CategoryId = product.Category.Id
                }
            };
            return data;
        }

        public List<ProductDto> GetProductList()
        {
            var data = context.Products
                 .Include(p => p.Category)
                 .OrderByDescending(p => p.Id)
                 .Select(p => new ProductDto
                 {
                     Description = p.Description,
                     Id = p.Id,
                     ImageUrl = p.ImageUrl,
                     Name = p.Name,
                     Price = p.Price,
                     productCategory = new ProductCategoryDto
                     {
                         Category = p.Category.Name,
                         CategoryId = p.Category.Id
                     }
                 }).ToList();
            return data;
        }
    }
}
