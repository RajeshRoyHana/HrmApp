using HrmApp.Services.Interfaces;
using HrmApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HrmApp.API.Controllers
{
    [Route("api/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        [HttpGet("departmentdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> DepartmentDropDown([FromQuery] int clientId,CancellationToken cancellationToken)
        {
            var data = await _commonService.GetDepartmentsAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("educationlevelsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> EducationLevelsDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.EducationLevelsAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("designationdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> DesignationDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetDesignationsAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("employeetypesdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> EmployeeTypesDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetEmployeeTypesAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("gendersdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> GendersDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetGendersAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("jobtypesdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> JobTypesDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetJobTypesAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("maritalstatusesdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> MaritalStatusesDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetMaritalStatusesAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("religionsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> ReligionsDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetReligionsAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("sectionsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> SectionsDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetSectionsAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("weekoffsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> WeekOffsDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetWeeekOffsAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("relationshipsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> RelationshipsDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.RelationshipsAsync(clientId, cancellationToken);
            return Ok(data);
        }

        [HttpGet("educationexaminationsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> EducationExaminationsDropDown([FromQuery] int clientId, CancellationToken cancellationToken)
        {
            var data = await _commonService.EducationExaminationsAsync(clientId, cancellationToken);
            return Ok(data);
        }
    }
}
