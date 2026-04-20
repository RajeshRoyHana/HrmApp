using AutoMapper;
using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
