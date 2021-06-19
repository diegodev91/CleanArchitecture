namespace CleanArchitecture.Store.Application.Features.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public int CategoryId { get; set; }
    }
}