using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public AccountType Type { get; set; }
        [Precision(18, 4)]
        public decimal Balance { get; set; }
        public DateTime OpenedDate { get; set; }
        public int UserId { get; set; }
    }
}
