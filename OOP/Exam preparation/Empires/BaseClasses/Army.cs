using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Empires.Libraries;

namespace Empires.BaseClasses
{
    public class Army
    {
        private List<Unit> army = new List<Unit>();
        private Dictionary<string, int> count = new Dictionary<string, int>();

        public void Add(Unit unit)
        {
            this.army.Add(unit);
            if (!this.count.ContainsKey(unit.ID))
            {
                this.count[unit.ID] = 0;
            }
            this.count[unit.ID]++;
        }

        public override string ToString()
        {
            return DictionaryPrinter.Print("Units", count);
        }
    }
}
