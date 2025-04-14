using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction?> GetByIdAsync(int id);
        Task CreateAsync(Transaction transaction);
    }
}
