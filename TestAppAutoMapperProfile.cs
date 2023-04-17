using AutoMapper;
using Test_App.App.Domain;
using Test_App.Data.Entities;
using Test_App.Models.Dto;

namespace Test_App;

public class TestAppAutoMapperProfile : Profile
{
    public TestAppAutoMapperProfile()
    {
        CreateMap<PersonEntity, Person>().ReverseMap()
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Id));
        CreateMap<Person, PersonEntity>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId));

        CreateMap<SkillEntity, Skill>().ReverseMap();
        CreateMap<Skill, SkillDto>().ReverseMap();

        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<PersonCreateDto, Person>().ReverseMap();
    }
}