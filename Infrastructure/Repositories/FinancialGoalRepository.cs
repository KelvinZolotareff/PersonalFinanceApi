using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class FinancialGoalRepository : IFinancialGoalRepository
    {
        private readonly AppDbContext _context;
        public FinancialGoalRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FinancialGoal>> GetAllByUserAsync(int userId)
        {
            return await _context.FinancialGoals
                .Where(g => g.UserId == userId)
                .ToListAsync();
        }
        public async Task<FinancialGoal?> GetByIdAsync(int id)
        {
            return await _context.FinancialGoals.FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task CreateAsync(FinancialGoal goal)
        {
            _context.FinancialGoals.Add(goal);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(FinancialGoal goal)
        {
            _context.FinancialGoals.Update(goal);
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var goal = await GetByIdAsync(id);
            if (goal == null) return false;
            _context.FinancialGoals.Remove(goal);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
