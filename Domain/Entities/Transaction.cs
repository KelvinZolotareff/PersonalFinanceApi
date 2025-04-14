using Domain.Entities.Enums;
using System;

namespace Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
