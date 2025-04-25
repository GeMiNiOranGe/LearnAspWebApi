using AutoMapper;
using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.DTOs;

namespace LearnAspWebApi.UseCases.Mappings;

class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeDto, Employee>().ReverseMap();
    }
}
