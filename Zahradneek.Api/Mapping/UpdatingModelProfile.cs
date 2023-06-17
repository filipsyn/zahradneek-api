using AutoMapper;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Mapping;

public class UpdatingModelProfile : Profile
{
    public UpdatingModelProfile()
    {
        CreateMap<User, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

        CreateMap<Parcel, Parcel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.OwnerId, opt => opt.Ignore())
            .ForMember(dest => dest.WaterLogs, opt => opt.Ignore())
            .ForMember(dest => dest.Coordinates, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

        CreateMap<Coordinate, Coordinate>();

        CreateMap<WaterLog, WaterLog>()
            .ForMember(
                dest => dest.CreatedAt,
                opt => opt.Ignore()
            );
    }
}