using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UCity.Data.Models
{
    public class EventPart
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public string Place { get; set; }

        public int EventId { get;set; }
        [JsonIgnore] 
        public Event Event { get; set; }
    }
}