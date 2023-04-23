using AutoMapper;
using Zahradneek.Api.Contracts.v1;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Mapping;

public class RequestToModelProfile : Profile
{
    public RequestToModelProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());


        CreateMap<CreateParcelRequest, Parcel>();
        CreateMap<UpdateParcelRequest, Parcel>();
        CreateMap<Parcel, Parcel>();
    }
}