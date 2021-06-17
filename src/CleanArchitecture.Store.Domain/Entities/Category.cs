using System;
using System.Collections.Generic;
using CleanArchitecture.Store.Domain.Common;

namespace CleanArchitecture.Store.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public DateTime EndOfContract { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}