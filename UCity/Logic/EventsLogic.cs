using AutoMapper;
using UCity.Data.Dtos.Event;
using UCity.Data.Models;
using UCity.Data.Repositories.EventsRepository;

namespace UCity.Logic
{
    public class EventsLogic : IEventsLogic
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly IMapper _mapper;

        public EventsLogic(IEventsRepository eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }

        public async Task CreateEvent(EventCreateDto ev)
        {
            await _eventsRepository.CreateEvent(_mapper.Map<Event>(ev));
        }

        public async Task UpdateEvent(EventUpdateDto ev)
        {
            await _eventsRepository.UpdateEvent(_mapper.Map<Event>(ev));
        }

        public async Task DeleteEvent(int id)
        {
            try
            {
                await _eventsRepository.DeleteEvent(id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Event with provided id '{id}' couldn't be delete for the reason '{ex.Message}'");
            }
        }

        public async Task<EventReadDto> GetEvent(int id)
        {
            var ev = await _eventsRepository.GetEvent(id);
            if (ev == null)
            {
                throw new KeyNotFoundException($"Event with provided id '{id}' not found");
            }

            return _mapper.Map<EventReadDto>(ev);
        }

        public async Task<IEnumerable<EventReadDto>> GetEvents()
        {
            var events = await _eventsRepository.GetEvents();
            return _mapper.Map<IEnumerable<EventReadDto>>(events);
        }
    }
}