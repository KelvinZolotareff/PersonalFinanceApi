using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialGoalController : ControllerBase
    {
        private readonly IFinancialGoalService _goalService;
        public FinancialGoalController(IFinancialGoalService goalService)
        {
            _goalService = goalService;
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllByUser(int userId) =>
            Ok(await _goalService.GetAllByUserAsync(userId));
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var goal = await _goalService.GetByIdAsync(id);
            if (goal == null) return NotFound();
            return Ok(goal);
        }
        [HttpPost]
        public async Task<IActionResult> Create(FinancialGoalDto goalDto)
        {
            var created = await _goalService.CreateAsync(goalDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FinancialGoalDto goalDto)
        {
            if (!await _goalService.UpdateAsync(id, goalDto))
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _goalService.DeleteAsync(id))
                return NotFound();
            return NoContent();
        }
    }
}
