using Application.DTOs;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionDto?> GetByIdAsync(int id);
        Task<TransactionDto> CreateAsync(TransactionDto transactionDto);
    }
}
