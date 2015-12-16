using Empires.Units;
using Empires.BaseClasses;

namespace Empires.Buildings
{
    class Archery : Building
    {
        public Archery(): base(
            new Resource(ResourceType.Gold, 5), 2,
            new Archer(), 3)
        {
        }
    }
}