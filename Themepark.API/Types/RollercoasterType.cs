using Themepark.Domain.Entity;

namespace Themepark.API.Types
{
    public class RollercoasterType : ObjectType<Rollercoaster>
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
    }
}
