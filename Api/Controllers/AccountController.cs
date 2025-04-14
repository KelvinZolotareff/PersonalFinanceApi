using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _accountService.GetAllAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountDto accountDto)
        {
            var created = await _accountService.CreateAsync(accountDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AccountDto accountDto)
        {
            if (!await _accountService.UpdateAsync(id, accountDto))
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _accountService.DeleteAsync(id))
                return NotFound();
            return NoContent();
        }
        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard() =>
            Ok(await _accountService.GetDashboardDataAsync());
    }
}
