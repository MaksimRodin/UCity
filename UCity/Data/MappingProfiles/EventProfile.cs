using AutoMapper;
using UCity.Data.Dtos.Event;
using UCity.Data.Models;

namespace UCity.Data.MappingProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventPart, EventPartReadDto>();
            CreateMap<EventPartCreateDto, EventPart>();
            CreateMap<EventPartUpdateDto, EventPart>();
            CreateMap<Event, EventReadDto>()
                .ForMember(dest => dest.Parts, opt => opt.MapFrom(src => src.Parts));
            CreateMap<EventCreateDto, Event>()
                .ForMember(dest => dest.Parts, opt => opt.MapFrom(src => src.Parts));
            CreateMap<EventUpdateDto, Event>()
                .ForMember(dest => dest.Parts, opt => opt.MapFrom(src => src.Parts));
        }
    }
}