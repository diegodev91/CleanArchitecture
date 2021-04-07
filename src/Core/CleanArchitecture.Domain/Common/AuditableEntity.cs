using System;

namespace CleanArchitecture.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBY { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
