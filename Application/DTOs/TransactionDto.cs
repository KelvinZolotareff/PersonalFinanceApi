using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime TransactionDate { get; set; }
        [Precision(18, 4)]
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
