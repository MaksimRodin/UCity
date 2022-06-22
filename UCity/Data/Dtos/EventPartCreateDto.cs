namespace UCity.Data.Dtos
{
    public class EventPartCreateDto
    {
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Place { get; set; }
    }
}