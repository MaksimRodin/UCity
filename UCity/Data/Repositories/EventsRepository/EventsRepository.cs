using Microsoft.EntityFrameworkCore;
using UCity.Data.Models;

namespace UCity.Data.Repositories.EventsRepository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly AppDbContext _context;

        public EventsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateEvent(Event ev)
        {
            _context.Add(ev);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEvent(Event ev)
        {
            _context.Update(ev);
            await _context.SaveChangesAsync();
        }

        public async Task<Event?> GetEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            return ev;
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _context.Events.Include(e => e.Parts).ToListAsync();
        }

        public async Task DeleteEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if(ev == null)
            {
                throw new KeyNotFoundException($"Event with provided id '{id}' not found");
            }

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
        }
    }
}