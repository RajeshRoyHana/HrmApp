using HrmApp.Services.Interfaces;
using HrmApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace HrmApp.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeListDto>>> GetAll([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetEmployeeListByClientId(clientId, cancellationToken);
            return Ok(employees);
        }

        [HttpGet("details")]
        public async Task<ActionResult<EmployeeDto>> GetById([FromQuery] int clientId, [FromQuery] int id, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetEmployeeAsync(clientId, id, cancellationToken);

            if (employee == null)
                return NotFound();

            return employee;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto, CancellationToken cancellationToken)
        {
            if (dto.IdClient <= 0)
            {
                return BadRequest(new
                {
                    Message = "Client is required."
                });
            }

            var id = await _employeeService.CreateEmployeeAsync(dto, cancellationToken);

            return Ok(new { EmployeeId = id });
        }


        [HttpPut]
        public async Task<IActionResult> Update(int clientId, int id, [FromBody] EmployeeDto dto, CancellationToken cancellationToken)
        {
            if (clientId <= 0 || id <= 0)
                return BadRequest("Invalid client or employee id.");

            if (dto.IdClient != clientId || dto.Id != id)
                return BadRequest("Mismatched ids.");

            var updated = await _employeeService.UpdateEmployeeAsync(dto, cancellationToken);

            if (!updated)
                return NotFound();

            return Ok(new { Message = "Employee updated successfully" });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int clientId, [FromQuery] int id, CancellationToken cancellationToken)
        {
            var deleted = await _employeeService.DeleteEmployee(clientId, id, cancellationToken);

            if (!deleted)
                return NotFound();

            return Ok(new { Message = "Employee deactivated successfully" });
        }


    }
}
