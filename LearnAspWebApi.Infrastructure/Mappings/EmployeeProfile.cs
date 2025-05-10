using AutoMapper;
using LearnAspWebApi.Core.Entities;

namespace LearnAspWebApi.Infrastructure.Mappings;

class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Models.Employee, Employee>().ReverseMap();
    }
}
