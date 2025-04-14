using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts
                .Include(a => a.Transactions)
                .ToListAsync();
        }
        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Accounts
                .Include(a => a.Transactions)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task CreateAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var account = await GetByIdAsync(id);
            if (account == null) return false;
            account.IsDeleted = true;
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
