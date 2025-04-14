using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return accounts.Select(a => new AccountDto
            {
                Id = a.Id,
                Name = a.Name,
                Type = a.Type,
                Balance = a.Balance,
                OpenedDate = a.OpenedDate,
                UserId = a.UserId
            });
        }
        public async Task<AccountDto?> GetByIdAsync(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null)
                return null;
            return new AccountDto
            {
                Id = account.Id,
                Name = account.Name,
                Type = account.Type,
                Balance = account.Balance,
                OpenedDate = account.OpenedDate,
                UserId = account.UserId
            };
        }
        public async Task<AccountDto> CreateAsync(AccountDto accountDto)
        {
            var account = new Account
            {
                Name = accountDto.Name,
                Type = accountDto.Type,
                Balance = accountDto.Balance,
                OpenedDate = accountDto.OpenedDate,
                UserId = accountDto.UserId
            };
            await _accountRepository.CreateAsync(account);
            accountDto.Id = account.Id;
            return accountDto;
        }
        public async Task<bool> UpdateAsync(int id, AccountDto accountDto)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null)
                return false;
            account.Name = accountDto.Name;
            account.Type = accountDto.Type;
            account.Balance = accountDto.Balance;
            account.OpenedDate = accountDto.OpenedDate;
            return await _accountRepository.UpdateAsync(account);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _accountRepository.DeleteAsync(id);
        }
        public async Task<object> GetDashboardDataAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            var dashboard = accounts.Select(a => new
            {
                a.Id,
                a.Name,
                a.Balance,
                TransactionCount = a.Transactions.Count
            });
            return dashboard;
        }
    }
}
