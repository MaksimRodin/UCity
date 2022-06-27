using Microsoft.AspNetCore.Mvc;
using UCity.Data.Dtos.Event;
using UCity.Data.Models.Auth;
using UCity.Logic;

namespace UCity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventsLogic _eventsLogic;

        public EventsController(IEventsLogic eventsLogic)
        {
            _eventsLogic = eventsLogic;
        }

        [HttpPost]
        [Authorize(Role.Admin, Role.Moderator)]
        public async Task<ActionResult> CreateEvent(EventCreateDto ev)
        {
            await _eventsLogic.CreateEvent(ev);
            return Ok();
        }

        [HttpPut]
        [Authorize(Role.Admin, Role.Moderator)]
        public async Task<ActionResult> UpdateEvent(EventUpdateDto ev)
        {
            await _eventsLogic.UpdateEvent(ev);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventReadDto>> GetEvent(int id)
        {
            return Ok(await _eventsLogic.GetEvent(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventReadDto>>> GetEvents()
        {
            return Ok(await _eventsLogic.GetEvents());
        }

        [HttpDelete]
        [Authorize(Role.Admin, Role.Moderator)]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            await _eventsLogic.DeleteEvent(id);
            return Ok();
        }
    }
}