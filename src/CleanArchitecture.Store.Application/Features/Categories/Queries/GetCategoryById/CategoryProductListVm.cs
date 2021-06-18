using System.Collections.Generic;

namespace CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryById
{
    public class CategoryProductListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public string EndOfContract { get; set; }
        public ICollection<CategoryProductDto> Products { get; set; }

    }
}