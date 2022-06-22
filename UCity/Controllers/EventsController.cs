using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UCity.Data.Dtos;
using UCity.Data.Models;
using UCity.Data.Repositories.EventsRepository;
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
        public async Task<ActionResult> CreateEvent(EventCreateDto ev)
        {
            await _eventsLogic.CreateEvent(ev);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEvent(EventUpdateDto ev)
        {
            await _eventsLogic.UpdateEvent(ev);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventReadDto>> GetEvent(int id)
        {
            try
            {
                return Ok(await _eventsLogic.GetEvent(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Desired event not found");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventReadDto>>> GetEvents()
        {
            return Ok(await _eventsLogic.GetEvents());
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            await _eventsLogic.DeleteEvent(id);
            return Ok();
        }
    }
}