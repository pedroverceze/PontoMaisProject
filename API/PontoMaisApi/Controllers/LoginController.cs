using Microsoft.AspNetCore.Mvc;
using PontoMaisDomain.Employees.Services;
using PontoMaisDomain.Token;

namespace PontoMaisApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ITokenService _tokenService;
        private readonly IEmployeeService _employeeService;

        public LoginController(ITokenService tokenService,
                               IEmployeeService employeeService)
        {
            _tokenService = tokenService;
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("login/{employeeId}")]
        public async Task<ActionResult<dynamic>> Authenticate(string employeeId)
        {
            var employee = await _employeeService.Get(Guid.Parse(employeeId));

            if (employee == null)
            {
                return NotFound(new { Message = "Employee not found" });
            }

            var token = _tokenService.GenerateToken(employee);

            return new
            {
                Employee = employee,
                Token = token
            };
        }
    }
}
