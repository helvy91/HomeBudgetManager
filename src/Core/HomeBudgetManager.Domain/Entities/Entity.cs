using System;

namespace HomeBudgetManager.Domain.Entities
{
    public class Entity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
