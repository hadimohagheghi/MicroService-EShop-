#nullable enable
namespace ProductService.Model.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public ProductCategoryDto productCategory { get; set; }
    }


    /*public sealed record ProductDto
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public decimal Price { get; init; }
        public required ProductCategoryDto Category { get; init; }
    }*/


    public class ProductCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Category { get; set; }
    }
    /*
    public sealed record ProductCategoryDto(
        Guid Id,
        string Name
    );
    */

    public class AddNewProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }



    /// <summary>
    /// PUT: نمای کامل ریسورس را می‌فرستید؛ چیزهایی که نفرستید ممکن است پاک/پیش‌فرض شوند. (جایگزینی کامل)
    ///PATCH: فقط تغییرات را می‌فرستید؛ بقیه دست‌نخورده می‌مانند. (به‌روزرسانی جزئی)
    /// </summary>
    //مناسب Patch ها
    public sealed class UpdateProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
