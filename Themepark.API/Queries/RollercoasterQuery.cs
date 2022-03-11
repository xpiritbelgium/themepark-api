using Themepark.API.Types;

namespace Themepark.API.Queries
{
    [ExtendObjectType(name: "Query")]
    public class RollercoasterQuery
    {
        public List<RollercoasterType> GetRollerCoasters()
        {


            var coasters = new List<RollercoasterType>()
            {
                new RollercoasterType("FLY","Flying Coaster","FLY.jpg"),
                new RollercoasterType("Nemesis","Flying Coaster","FLY.jpg"),
                new RollercoasterType("Furry","Launch coaster","FLY.jpg"),
            };

            return coasters;
        }
    }
}
