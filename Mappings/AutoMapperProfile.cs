using AutoMapper;
using FishReportApi.DTOs;
using FishReportApi.Models;

namespace FishReportApi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Species, SpeciesDTO>().ReverseMap();
        }
    }
}