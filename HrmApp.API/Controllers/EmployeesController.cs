using HrmApp.Services.Interfaces;
using HrmApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet("{clientId}")]
        public async Task<ActionResult<List<EmployeeListDto>>> GetAll(int clientId)
        {
            var employees = await _employeeService.GetEmployeeListByClientId(clientId);
            return Ok(employees);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto)
        {
            if (dto.IdClient <= 0)
            {
                return BadRequest(new
                {
                    Message = "Client is required."
                });
            }

            var id = await _employeeService.CreateEmployeeAsync(dto);

            return Ok(new { EmployeeId = id });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted =
                await _employeeService.DeleteEmployee(id);

            if (!deleted)
                return NotFound();

            return Ok(new { Message = "Employee deactivated successfully" });
        }


    }
}
