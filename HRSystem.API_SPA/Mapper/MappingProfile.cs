using AutoMapper;
using HRSystem.DTO;
using HRSystem.Model;

namespace HRSystem.API_SPA.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, Employee>()
                .ForMember(dest => dest.Employee_Address, o => o.MapFrom(src => src.Address))
                .ForMember(dest => dest.Employee_BithDate, o => o.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Employee_EmailAddress, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.Employee_ID, o => o.MapFrom(src => src.Id))
                .ForMember(dest => dest.Employee_Mobile, o => o.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.Employee_Name, o => o.MapFrom(src => src.Username))
                .ForMember(dest => dest.Employee_type, o => o.MapFrom(src => src.Type))
                .ForMember(dest => dest.ManagerId, o => o.MapFrom(src => src.ManagerId))
                .ReverseMap();

            CreateMap<Employee, UserRegisterDto>()
                .ForMember(dest => dest.Address, o => o.MapFrom(src => src.Employee_Address))
                .ForMember(dest => dest.BirthDate, o => o.MapFrom(src => src.Employee_BithDate))
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Employee_EmailAddress))
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Employee_ID))
                .ForMember(dest => dest.Mobile, o => o.MapFrom(src => src.Employee_Mobile))
                .ForMember(dest => dest.Username, o => o.MapFrom(src => src.Employee_Name))
                .ForMember(dest => dest.Type, o => o.MapFrom(src => src.Employee_type))
                .ForMember(dest => dest.ManagerId, o => o.MapFrom(src => src.ManagerId))
                .ReverseMap();

            CreateMap<UserDataBrowseDto, Employee>()
                
                .ForMember(dest => dest.Employee_EmailAddress, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.Employee_Name, o => o.MapFrom(src => src.Username))
                .ForMember(dest => dest.Employee_ID, o => o.MapFrom(src => src.userID))
                .ForMember(dest => dest.Employee_type, o => o.MapFrom(src => src.userType))
                 .ReverseMap();

            CreateMap<Employee, UserDataBrowseDto>()
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Employee_EmailAddress))
                .ForMember(dest => dest.Username, o => o.MapFrom(src => src.Employee_Name))
                .ForMember(dest => dest.userID, o => o.MapFrom(src => src.Employee_ID))
                .ForMember(dest => dest.userType, o => o.MapFrom(src => src.Employee_type))
               .ReverseMap();

            CreateMap<UserLoginDto, Employee>()
                .ForMember(dest => dest.Employee_EmailAddress, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.Employee_EmailAddress, o => o.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<Employee, UserLoginDto>()
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Employee_EmailAddress))
                .ReverseMap();

        }
    }
}