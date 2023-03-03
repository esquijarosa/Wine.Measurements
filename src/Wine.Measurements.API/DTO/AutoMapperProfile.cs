using AutoMapper;
using Wine.Measurements.Common.Models;

namespace Wine.Measurements.API.DTO;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterUserDTO, User>();
        CreateMap<User, RegisteredUserDTO>();
        CreateMap<AddMeasurementDTO, Measurement>();
        CreateMap<UpdateMeasurementDTO, Measurement>();
        CreateMap<Measurement, MeasurementDTO>();
        CreateMap<CatalogItem, CatalogItemDTO>();
    }
}
