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
        [HttpGet("departmentdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> DepartmentDropDown(int clientId)
        {
            var data = await _commonService.GetDepartmentsAsync(clientId);
            return Ok(data);
        }

        [HttpGet("educationlevelsdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> EducationLevelsDropDown(int clientId)
        {
            var data = await _commonService.EducationLevelsAsync(clientId);
            return Ok(data);
        }

        [HttpGet("designationdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> DesignationDropDown(int clientId)
        {
            var data = await _commonService.GetDesignationsAsync(clientId);
            return Ok(data);
        }

        [HttpGet("employeetypesdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> EmployeeTypesDropDown(int clientId)
        {
            var data = await _commonService.GetEmployeeTypesAsync(clientId);
            return Ok(data);
        }

        [HttpGet("gendersdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> GendersDropDown(int clientId)
        {
            var data = await _commonService.GetGendersAsync(clientId);
            return Ok(data);
        }

        [HttpGet("jobtypesdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> JobTypesDropDown(int clientId)
        {
            var data = await _commonService.GetJobTypesAsync(clientId);
            return Ok(data);
        }

        [HttpGet("maritalstatusesdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> MaritalStatusesDropDown(int clientId)
        {
            var data = await _commonService.GetMaritalStatusesAsync(clientId);
            return Ok(data);
        }

        [HttpGet("religionsdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> ReligionsDropDown(int clientId)
        {
            var data = await _commonService.GetReligionsAsync(clientId);
            return Ok(data);
        }

        [HttpGet("sectionsdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> SectionsDropDown(int clientId)
        {
            var data = await _commonService.GetSectionsAsync(clientId);
            return Ok(data);
        }

        [HttpGet("weekoffsdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> WeekOffsDropDown(int clientId)
        {
            var data = await _commonService.GetWeeekOffsAsync(clientId);
            return Ok(data);
        }

        [HttpGet("relationshipsdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> RelationshipsDropDown(int clientId)
        {
            var data = await _commonService.RelationshipsAsync(clientId);
            return Ok(data);
        }

        [HttpGet("educationexaminationsdropdown/{clientId}")]
        public async Task<ActionResult<List<DropdownDto>>> EducationExaminationsDropDown(int clientId)
        {
            var data = await _commonService.EducationExaminationsAsync(clientId);
            return Ok(data);
        }
    }
}
