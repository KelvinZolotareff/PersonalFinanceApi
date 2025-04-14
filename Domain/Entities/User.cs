using System.Collections.Generic;
using System.Security.Principal;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public ICollection<FinancialGoal> FinancialGoals { get; set; } = new List<FinancialGoal>();
    }
}
