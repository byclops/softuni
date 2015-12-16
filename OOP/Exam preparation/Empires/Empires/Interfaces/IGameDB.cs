using System.Collections.Generic;
using Empires.BaseClasses;

namespace Empires.Interfaces
{
    public interface IGameDB
    {
        void AddBuilding(Building building);
        void AddUnit(Unit unit);
        void AddResource(Resource resource);
        void IncrementBuildingsCounter();
        ICollection<Building> GetBuildings();
        Army GetArmy();
        Treasury GetTreasury();
    }
}
