using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoMaisDomain.ClockIn.Services;

namespace PontoMaisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToClockController : ControllerBase
    {
        private readonly IClockInService _clockInService;

        public ToClockController(IClockInService clockingService)
        {
            _clockInService = clockingService;
        }

        [HttpGet]
        [Authorize(Roles = "Employee")]
        [Route("GetByEmployee/{id}/{day}/{month}/{year}")]
        public async Task<ActionResult> GetByEmployee(Guid id, int day, int month, int year)
        {
            var list = await _clockInService.GetByEmployee(id, day, month, year);

            return Ok(list);

        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        [Route("input/{employeeId}")]
        public async Task<ActionResult> Input(Guid employeeId){
            await _clockInService.Input(employeeId);

            return Created(new Uri($"{Request.Path}/{employeeId}"),employeeId);
        }
    }
}
