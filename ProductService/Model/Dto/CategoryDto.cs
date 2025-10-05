#nullable enable
namespace ProductService.Model.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; init; }
        public required string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
    }
    /*
    public sealed record CategoryDto(
        Guid Id,
        string Name,
        string? Description
    );*/
}
