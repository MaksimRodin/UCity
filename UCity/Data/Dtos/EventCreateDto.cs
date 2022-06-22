using UCity.Data.Models;

namespace UCity.Data.Dtos
{
    public class EventCreateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<EventPartCreateDto> Parts { get;set; }
    }
}