using System.ComponentModel.DataAnnotations;

namespace UCity.Data.Models
{
    public class Event
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public ICollection<EventPart> Parts { get;set; }
    }
}