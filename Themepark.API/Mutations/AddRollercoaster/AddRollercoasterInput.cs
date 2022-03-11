using System.ComponentModel.DataAnnotations;

namespace Themepark.API.Mutations.AddRollercoaster
{
    public class AddRollercoasterInput
    {
        [Required] // Does this do anything in graphql?
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? ImageUrl { get; set; }
    }
}
