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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<EmployeeDto>> GetById(int id)
        //{
        //    var employee = await _employeeService.GetByIdAsync(id);

        //    if (employee == null)
        //    {
        //        return NotFound(new { message = $"Employee with id {id} not found" });
        //    }

        //    return Ok(employee);
        //}

    }
}
