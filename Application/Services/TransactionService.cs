using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Enums;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }
        public async Task<TransactionDto?> GetByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null)
                return null;
            return new TransactionDto
            {
                Id = transaction.Id,
                AccountId = transaction.AccountId,
                CategoryId = transaction.CategoryId,
                TransactionDate = transaction.TransactionDate,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Description = transaction.Description
            };
        }
        public async Task<TransactionDto> CreateAsync(TransactionDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(dto.AccountId);
            if (account == null)
                throw new System.Exception("Account not found.");
            // Update account balance based on transaction type
            if (dto.Type == TransactionType.Credit)
                account.Balance += dto.Amount;
            else if (dto.Type == TransactionType.Debit)
            {
                if (account.Balance < dto.Amount)
                    throw new System.Exception("Insufficient balance.");
                account.Balance -= dto.Amount;
            }
            var transaction = new Transaction
            {
                AccountId = dto.AccountId,
                CategoryId = dto.CategoryId,
                TransactionDate = dto.TransactionDate,
                Amount = dto.Amount,
                Type = dto.Type,
                Description = dto.Description
            };
            await _transactionRepository.CreateAsync(transaction);
            await _accountRepository.UpdateAsync(account);
            dto.Id = transaction.Id;
            return dto;
        }
    }
}
