namespace Themepark.API.Types
{
    public class RollercoasterType
    {
        public RollercoasterType(string name, string type, string imageUrl)
        {
            Name = name;
            Type = type;
            ImageUrl = imageUrl;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
    }
}
