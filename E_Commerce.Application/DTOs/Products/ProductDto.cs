namespace E_Commerce.Application.DTOs.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
        public string PrductBrand { get; set; } = default!;
        public string PrductType { get; set; } = default!;
        public decimal Price { get; set; }

    }
}
