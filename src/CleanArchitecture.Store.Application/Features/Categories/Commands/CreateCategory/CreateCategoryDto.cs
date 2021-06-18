using System;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public DateTime EndOfContract { get; set; }
    }
}