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
        public async Task<ActionResult<List<DropdownDto>>> DepartmentDropDown([FromQuery] int idClient,CancellationToken cancellationToken)
        {
            var data = await _commonService.GetDepartmentsAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("educationlevelsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> EducationLevelsDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.EducationLevelsAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("designationdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> DesignationDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetDesignationsAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("employeetypesdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> EmployeeTypesDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetEmployeeTypesAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("gendersdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> GendersDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetGendersAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("jobtypesdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> JobTypesDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetJobTypesAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("maritalstatusesdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> MaritalStatusesDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetMaritalStatusesAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("religionsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> ReligionsDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetReligionsAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("sectionsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> SectionsDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetSectionsAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("weekoffsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> WeekOffsDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.GetWeeekOffsAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("relationshipsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> RelationshipsDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.RelationshipsAsync(idClient, cancellationToken);
            return Ok(data);
        }

        [HttpGet("educationexaminationsdropdown")]
        public async Task<ActionResult<List<DropdownDto>>> EducationExaminationsDropDown([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var data = await _commonService.EducationExaminationsAsync(idClient, cancellationToken);
            return Ok(data);
        }
    }
}
