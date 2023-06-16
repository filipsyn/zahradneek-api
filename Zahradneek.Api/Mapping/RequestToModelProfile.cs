using AutoMapper;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Mapping;

public class RequestToModelProfile : Profile
{
    public RequestToModelProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();

        CreateMap<CreateParcelRequest, Parcel>();
        CreateMap<UpdateParcelRequest, Parcel>();

        CreateMap<CreateCoordinateRequest, Coordinate>();
        CreateMap<UpdateCoordinateRequest, Coordinate>();

        CreateMap<CreateWaterLogRequest, WaterLog>();
        CreateMap<UpdateCoordinateRequest, WaterLog>();
    }
}