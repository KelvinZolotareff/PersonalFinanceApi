using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FinancialGoalService : IFinancialGoalService
    {
        private readonly IFinancialGoalRepository _goalRepository;
        public FinancialGoalService(IFinancialGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }
        public async Task<IEnumerable<FinancialGoalDto>> GetAllByUserAsync(int userId)
        {
            var goals = await _goalRepository.GetAllByUserAsync(userId);
            return goals.Select(g => new FinancialGoalDto
            {
                Id = g.Id,
                UserId = g.UserId,
                Description = g.Description,
                TargetAmount = g.TargetAmount,
                CurrentAmount = g.CurrentAmount,
                StartDate = g.StartDate,
                CompletionDate = g.CompletionDate
            });
        }
        public async Task<FinancialGoalDto?> GetByIdAsync(int id)
        {
            var goal = await _goalRepository.GetByIdAsync(id);
            if (goal == null) return null;
            return new FinancialGoalDto
            {
                Id = goal.Id,
                UserId = goal.UserId,
                Description = goal.Description,
                TargetAmount = goal.TargetAmount,
                CurrentAmount = goal.CurrentAmount,
                StartDate = goal.StartDate,
                CompletionDate = goal.CompletionDate
            };
        }
        public async Task<FinancialGoalDto> CreateAsync(FinancialGoalDto dto)
        {
            var goal = new FinancialGoal
            {
                UserId = dto.UserId,
                Description = dto.Description,
                TargetAmount = dto.TargetAmount,
                CurrentAmount = dto.CurrentAmount,
                StartDate = dto.StartDate,
                CompletionDate = dto.CompletionDate
            };
            await _goalRepository.CreateAsync(goal);
            dto.Id = goal.Id;
            return dto;
        }
        public async Task<bool> UpdateAsync(int id, FinancialGoalDto dto)
        {
            var goal = await _goalRepository.GetByIdAsync(id);
            if (goal == null) return false;
            goal.Description = dto.Description;
            goal.TargetAmount = dto.TargetAmount;
            goal.CurrentAmount = dto.CurrentAmount;
            goal.StartDate = dto.StartDate;
            goal.CompletionDate = dto.CompletionDate;
            return await _goalRepository.UpdateAsync(goal);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _goalRepository.DeleteAsync(id);
        }
    }
}
