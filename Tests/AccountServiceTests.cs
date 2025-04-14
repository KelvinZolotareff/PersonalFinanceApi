using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Domain.Entities.Enums;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class AccountServiceTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task CreateAccount_ShouldReturnAccountWithId()
        {
            var context = GetInMemoryDbContext();
            var accountRepository = new AccountRepository(context);
            var transactionRepository = new TransactionRepository(context);
            var service = new AccountService(accountRepository, transactionRepository);

            var newAccount = new AccountDto
            {
                Name = "Checking Account",
                Type = AccountType.Checking,
                Balance = 1000,
                OpenedDate = DateTime.UtcNow,
                UserId = 1  
            };

            var result = await service.CreateAsync(newAccount);

            Assert.True(result.Id > 0);
        }
    }
}
