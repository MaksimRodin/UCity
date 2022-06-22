using UCity.Data.Dtos;

namespace UCity.Logic
{
    public interface IEventsLogic
    {
        public Task CreateEvent(EventCreateDto ev);
        public Task UpdateEvent(EventUpdateDto ev);
        public Task<EventReadDto> GetEvent(int id);
        public Task<IEnumerable<EventReadDto>> GetEvents();
        public Task DeleteEvent(int id);
    }
}