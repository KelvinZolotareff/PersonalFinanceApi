using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<AccountDto?> GetByIdAsync(int id);
        Task<AccountDto> CreateAsync(AccountDto accountDto);
        Task<bool> UpdateAsync(int id, AccountDto accountDto);
        Task<bool> DeleteAsync(int id);
        Task<object> GetDashboardDataAsync();
    }
}
