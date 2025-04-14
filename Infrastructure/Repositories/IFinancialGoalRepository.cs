using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IFinancialGoalRepository
    {
        Task<IEnumerable<FinancialGoal>> GetAllByUserAsync(int userId);
        Task<FinancialGoal?> GetByIdAsync(int id);
        Task CreateAsync(FinancialGoal goal);
        Task<bool> UpdateAsync(FinancialGoal goal);
        Task<bool> DeleteAsync(int id);
    }
}
