using UCity.Data.Models;

namespace UCity.Data.Repositories.EventsRepository
{
    public interface IEventsRepository
    {
        Task CreateEvent(Event e);
        Task UpdateEvent(Event e);
        Task<Event?> GetEvent(int id);
        Task<IEnumerable<Event>> GetEvents();
        Task DeleteEvent(int id);
    }
}