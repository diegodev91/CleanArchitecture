using System;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public string Name { get; set; }
        public string Provider { get; set; }
        public DateTime EndOfContract { get; set; }
        public int Id { get; set; }
    }
}