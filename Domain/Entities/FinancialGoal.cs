using System;

namespace Domain.Entities
{
    public class FinancialGoal : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
