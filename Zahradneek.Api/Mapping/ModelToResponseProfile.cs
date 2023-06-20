using AutoMapper;
using Zahradneek.Api.Contracts.v1.Responses;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Mapping;

public class ModelToResponseProfile : Profile
{
    public ModelToResponseProfile()
    {
        CreateMap<User, UserInfoResponse>();
        CreateMap<User, UserBriefInfoResponse>();
        CreateMap<Parcel, ParcelInfoResponse>();
        CreateMap<Coordinate, CoordinateInfoResponse>();
        CreateMap<WaterLog, WaterLogInfoResponse>();
        CreateMap<News, NewsInfoResponse>();
    }
}