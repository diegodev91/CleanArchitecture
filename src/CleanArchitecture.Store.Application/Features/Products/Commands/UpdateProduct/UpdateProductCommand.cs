using System;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
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