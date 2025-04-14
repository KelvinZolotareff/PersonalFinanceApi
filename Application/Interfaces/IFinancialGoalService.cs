using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFinancialGoalService
    {
        Task<IEnumerable<FinancialGoalDto>> GetAllByUserAsync(int userId);
        Task<FinancialGoalDto?> GetByIdAsync(int id);
        Task<FinancialGoalDto> CreateAsync(FinancialGoalDto goalDto);
        Task<bool> UpdateAsync(int id, FinancialGoalDto goalDto);
        Task<bool> DeleteAsync(int id);
    }
}
