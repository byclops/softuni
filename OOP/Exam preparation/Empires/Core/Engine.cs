using Empires.Buildings;
using Empires.BaseClasses;
using Empires.Libraries;
using Empires.Interfaces;

namespace Empires.Core
{
    class Engine
    {
        private IO io;
        private IGameDB db;

        public Engine(IO io, IGameDB db)
        {
            this.io = io;
            this.db = db;
        }

        public void Run()
        {
            while (true)
            {
                string line = io.ReadLine();
                if (line == "armistice") break;
                try
                {
                    this.executeCommand(line);
                }
                catch(InvalidCommandException e)
                {
                    io.WriteLine(e.Message);
                }
            }
        }

        private void executeCommand(string command)
        {
            switch (command)
            {
                case "skip":
                    this.ProcessTurn();
                    return;
                case "build barracks":
                    this.ProcessTurn();
                    db.AddBuilding(new Barracks());
                    //buildings.Add(new Barracks());
                    break;
                case "build archery":
                    this.ProcessTurn();
                    db.AddBuilding(new Archery());
                    //buildings.Add(new Archery());
                    break;
                case "empire-status":
                    this.ShowStatus();
                    this.ProcessTurn();
                    break;
                default:
                    throw new InvalidCommandException("Invalid Command");
            }
        }

        private void ShowStatus()
        {
            io.WriteLine(this.db.GetTreasury().ToString());
            io.WriteLine("Buildings:");
            if (this.db.GetBuildings().Count == 0)
                io.WriteLine("N/A");
            foreach (var building in this.db.GetBuildings())
                io.WriteLine(building.ToString());
            io.WriteLine(this.db.GetArmy().ToString());
        }

        private void ProcessTurn()
        {
            db.IncrementBuildingsCounter();
            foreach (Building building in this.db.GetBuildings())
            {
                //building.Tick();
                try
                {
                    db.AddUnit(building.GetUnit());
                }
                catch  { }
                try
                {
                    db.AddResource(building.GetResource());
                }
                catch { }
            }
        }
    }
}
