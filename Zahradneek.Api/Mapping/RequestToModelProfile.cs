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
    }
}