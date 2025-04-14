using Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public AccountType Type { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
