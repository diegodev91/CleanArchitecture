using System;

namespace CleanArchitecture.Store.Application.Models.Cache
{
    public class CategoryCacheInfo
    {
        public int CategoryId { get; set; }
        public string Provider { get; set; }
        public DateTime EndOfContract { get; set; }
    }
}