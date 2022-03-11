namespace Themepark.Domain.Entity
{
    public class Rollercoaster
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
    }
}
