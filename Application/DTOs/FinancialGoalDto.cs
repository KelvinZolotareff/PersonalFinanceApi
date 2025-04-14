using Microsoft.EntityFrameworkCore;
using System;

namespace Application.DTOs
{
    public class FinancialGoalDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        [Precision(18, 4)]
        public decimal TargetAmount { get; set; }
        [Precision(18, 4)]
        public decimal CurrentAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
