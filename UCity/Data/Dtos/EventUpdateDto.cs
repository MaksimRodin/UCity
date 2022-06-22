using UCity.Data.Models;

namespace UCity.Data.Dtos
{
    public class EventUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<EventPartUpdateDto> Parts { get;set; }
    }
}