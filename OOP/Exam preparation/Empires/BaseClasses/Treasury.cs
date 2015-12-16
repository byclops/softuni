using System;
using System.Collections.Generic;
using Empires.Libraries;

namespace Empires.BaseClasses
{
    public class Treasury
    {
        private Dictionary<ResourceType,int> treasury = new Dictionary<ResourceType,int>();
        public Treasury ()
    	{
            foreach(var resource in Enum.GetValues(typeof(ResourceType)))
            {
                treasury[(ResourceType)resource]= 0;
            }
	    }
        public void Add(Resource resource)
        {
            treasury[resource.ResourceType] += resource.Quantity;
        }
        public override string ToString()
        {
            return DictionaryPrinter.Print("Treasury", treasury);
        }

    }
}
