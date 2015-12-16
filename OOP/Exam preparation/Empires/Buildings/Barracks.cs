using Empires.BaseClasses;
using Empires.Units;

namespace Empires.Buildings
{
    class Barracks: Building 
    {
        public Barracks(): base(
            new Resource(ResourceType.Steel, 10), 3,
            new Swordsman(), 4)
        {
        }
    }
}
