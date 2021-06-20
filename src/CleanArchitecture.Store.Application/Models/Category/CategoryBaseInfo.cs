using System.Collections.Generic;
using CleanArchitecture.Store.Domain.Entities;

namespace CleanArchitecture.Store.Application.Models.Category
{
    public class CategoryBaseInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}